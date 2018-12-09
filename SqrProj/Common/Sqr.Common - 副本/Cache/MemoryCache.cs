using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Cache
{
    public class MemoryCache : ICache
    {
        private readonly TimeSpan _defaultExpireTimeSpan = TimeSpan.FromDays(1);
        private System.Runtime.Caching.MemoryCache _memoryCache;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Unique name of the cache</param>
        public MemoryCache(string name)
        {
            _memoryCache = new System.Runtime.Caching.MemoryCache(name);
        }


        public double Decrease(string key, double num)
        {
            double operatorValue = 0;
            var value = _memoryCache.Get(key);
            if (value != null)
            {
                operatorValue = (double)value;
            }

            operatorValue -= num;
            _memoryCache.Set(
               key,
               value,
               new CacheItemPolicy
               {
                   SlidingExpiration = _defaultExpireTimeSpan
               });
            return operatorValue;
        }

        public T Get<T>(string key, Func<string, T> factory = null)
        {
            var value = _memoryCache.Get(key);
            if (value != null)
            {
                return (T)value;
            }
            if( factory != null)
            {
                var value2 = factory(key);
                if (value2 != null)
                {
                    Set(key, value2);
                }
                return value2;
            }
            return default(T);
        }

        public double Increase(string key, double num)
        {
            double operatorValue = 0;
            var value = _memoryCache.Get(key);
            if (value != null)
            {
                operatorValue = (double)value;
            }
               
            operatorValue += num;
            _memoryCache.Set(
               key,
               value,
               new CacheItemPolicy
               {
                   SlidingExpiration = _defaultExpireTimeSpan
               });
            return operatorValue;
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T value, TimeSpan? slidingExpireTime = default(TimeSpan?))
        {
            if (value == null)
            {
                throw new Exception("Can not insert null values to the cache!");
            }

            _memoryCache.Set(
                key,
                value,
                new CacheItemPolicy
                {
                    SlidingExpiration = slidingExpireTime ?? _defaultExpireTimeSpan
                });
        }

        public bool SetNX<T>(string key, T value, TimeSpan? slidingExpireTime = default(TimeSpan?))
        {
            if (value == null)
            {
                throw new Exception("Can not insert null values to the cache!");
            }

            return _memoryCache.AddOrGetExisting(
                key,
                value,
                new CacheItemPolicy
                {
                    SlidingExpiration = slidingExpireTime ?? _defaultExpireTimeSpan
                })!=null;
        }
    }
}
