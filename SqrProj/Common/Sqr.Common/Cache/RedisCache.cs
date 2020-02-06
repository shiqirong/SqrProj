using Newtonsoft.Json;
using Sqr.Common.Utils;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqr.Common.Cache
{
    public class RedisCache : ICache, IDisposable
    {
        private readonly TimeSpan _defaultExpireTimeSpan = TimeSpan.FromDays(1);
        private readonly ConnectionMultiplexer _redisConnections;
        private readonly IDatabase _database;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public RedisCache()
        {
            var redisConnectStr =ConfigUtil.GetSection("redis").Value;

            _redisConnections = ConnectionMultiplexer.Connect(redisConnectStr);
            _database = _redisConnections.GetDatabase();
            _jsonSerializerSettings =
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                };
        }
        

        public T Get<T>(string key, Func<T> factory = null,TimeSpan ts =default(TimeSpan))
        {
            var redisObject = _database.StringGet(key);
            if (redisObject.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(
                    redisObject,
                    _jsonSerializerSettings);
            }
            if (factory != null)
            {
                var value = factory();
                if (value != null)
                {
                    Set(key, value,ts);

                    return value;
                }
            }
            return default(T);
        }
        
        public bool Set<T>(string key, T value, TimeSpan slidingExpireTime = default(TimeSpan))
        {
            if (value == null)
            {
                throw new Exception("Can not insert null values to the cache!");
            }

            return _database.StringSet(
                key,
                JsonConvert.SerializeObject(
                    value,
                    Formatting.Indented,
                    _jsonSerializerSettings),
                slidingExpireTime );
        }

        public bool SetNX<T>(string key, T value, TimeSpan slidingExpireTime = default(TimeSpan))
        {
            if (value == null)
            {
                throw new Exception("Can not insert null values to the cache!");
            }
            return _database.StringSet(
                key,
                JsonConvert.SerializeObject(
                    value,
                    Formatting.Indented,
                    _jsonSerializerSettings),
                slidingExpireTime ,
                When.NotExists
            );
        }
        public double Increase(string key, double num)
        {
            return _database.StringIncrement(key, num);
        }
        public double Decrease(string key, double num)
        {
            return _database.StringDecrement(key, num);
        }
        public bool Remove(string key)
        {
            return _database.KeyDelete(key);
        }
        public void Dispose()
        {
            _redisConnections.Close();
            _redisConnections.Dispose();
        }
    }
}
