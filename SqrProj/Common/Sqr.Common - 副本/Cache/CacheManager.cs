using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Cache
{
    public class CacheManager
    {
        ICache cache = new RedisCache();
        

        public double Decrease(string key, double num)
        {
            return cache.Decrease(key, num);
        }

        public T Get<T>(string key, Func<string, T> factory = null)
        {
            return cache.Get<T>(key, factory);
        }

        public double Increase(string key, double num)
        {
            return cache.Increase(key, num);
        }

        public bool Remove(string key)
        {
            return cache.Remove(key);
        }

        public void Set<T>(string key, T value, TimeSpan? slidingExpireTime = default(TimeSpan?))
        {
            cache.Set<T>(key, value, slidingExpireTime);
        }

        public bool SetNX<T>(string key, T value, TimeSpan? slidingExpireTime = default(TimeSpan?))
        {
            return cache.SetNX(key, value, slidingExpireTime);
        }
    }
}
