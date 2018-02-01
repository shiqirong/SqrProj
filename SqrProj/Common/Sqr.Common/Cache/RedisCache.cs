using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqr.Common.Cache
{
    public class RedisCache : ICache
    {
        private readonly TimeSpan _defaultExpireTimeSpan = TimeSpan.FromDays(1);
        private readonly ConnectionMultiplexer _redisConnections;
        private readonly IDatabase _database;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public RedisCache(string name)
        {
            _redisConnections = ConnectionMultiplexer.Connect(name);
            _database = _redisConnections.GetDatabase();
            _jsonSerializerSettings =
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                };
        }

        public double Decrease(string key, double num)
        {
            return _database.StringDecrement(key, num);
        }

        public T Get<T>(string key, Func<string, T> factory = null)
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
                var value = factory(key);
                if (value != null)
                {
                    Set(key, value);

                    return value;
                }
            }
            return default(T);
        }

        public double Increase(string key, double num)
        {
            return _database.StringIncrement(key, num);
        }

        public bool Remove(string key)
        {
            return _database.KeyDelete(key);
        }

        public void Set<T>(string key, T value, TimeSpan? slidingExpireTime = default(TimeSpan?))
        {
            if (value == null)
            {
                throw new Exception("Can not insert null values to the cache!");
            }

            _database.StringSet(
                key,
                JsonConvert.SerializeObject(
                    value,
                    Formatting.Indented,
                    _jsonSerializerSettings),
                slidingExpireTime ?? _defaultExpireTimeSpan);
        }

        public bool SetNX<T>(string key, T value, TimeSpan? slidingExpireTime = default(TimeSpan?))
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
                slidingExpireTime ?? _defaultExpireTimeSpan,
                When.NotExists
            );
        }
    }
}
