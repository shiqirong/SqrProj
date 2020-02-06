using System;
using Microsoft.Extensions.Caching.Memory;
namespace Sqr.Common.Cache
{
    public class DefaultCache : ICache
    {
        private static readonly MemoryCache m_Cache = new MemoryCache(new MemoryCacheOptions());

        public T Get<T>(string key, Func<T> factory = null, TimeSpan ts = default(TimeSpan))
        {
            if (!m_Cache.TryGetValue<T>(key, out T obj))
            {
                if (factory != null)
                {
                    obj = factory();
                    Set<T>(key, obj, ts);
                }
            }
            return obj;
        }

        /// <summary> 
        /// 添加时间段过期缓存
        /// 如果存在则更新
        /// </summary>
        /// <typeparam name="T">添加缓存对象类型</typeparam>
        /// <param name="key">添加对象的key</param>
        /// <param name="obj">值</param>
        /// <param name="slidingExpiration">相对过期的TimeSpan</param>
        /// <returns>是否添加成功</returns>
        public bool Set<T>(string key, T obj, TimeSpan slidingExpiration)
        {
            var opt = new MemoryCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            };

            m_Cache.Set(key, obj, opt);
            return true;
        }


        public bool SetNX<T>(string key, T value, TimeSpan slidingExpireTime = default(TimeSpan))
        {
            if (value == null)
            {
                throw new Exception("Can not insert null values to the cache!");
            }
            if (!m_Cache.TryGetValue(key, out T obj))
            {
                return Set(key, value, slidingExpireTime);
            }
            return false;
        }

        public double Increase(string key, double num)
        {
            if (m_Cache.TryGetValue(key, out double obj))
            {
                obj += num;
            }
            else
            {
                obj = num;
            }
            m_Cache.Set(key, obj);
            return obj;
        }
        public double Decrease(string key, double num)
        {
            if (m_Cache.TryGetValue(key, out double obj))
            {
                obj -= num;
            }
            else
            {
                obj = num;
            }
            m_Cache.Set(key, obj);
            return obj;
        }
        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns>是否成功</returns>
        public bool Remove(string key)
        {
            m_Cache.Remove(key);
            return true;
        }
        public void Dispose()
        {
            m_Cache.Dispose();
        }

        
    }
}
