using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqr.Common.Cache
{
    public interface ICache
    {
        /// <summary>
        /// Gets an item from the cache.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="factory">Factory method to create cache item if not exists</param>
        /// <returns>Cached item</returns>
        T Get<T>(string key, Func<T> factory = null,TimeSpan ts=default(TimeSpan));

        /// <summary>
        /// Saves/Overrides an item in the cache by a key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">Sliding expire time</param>
        bool Set<T>(string key, T value, TimeSpan slidingExpireTime = default(TimeSpan));

        bool SetNX<T>(string key, T value, TimeSpan slidingExpireTime = default(TimeSpan));

        double Increase(string key, double num);

        double Decrease(string key, double num);

        /// <summary>
        /// Removes a cache item by it's key.
        /// </summary>
        /// <param name="key">Key</param>
        bool Remove(string key);
    }
}
