using Sqr.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Cache
{
    public sealed class CacheManager
    {
        private static ICache _cache = null;
        private static object _lockObj = new object();
        public static ICache CurrentCache()
        {
            if (_cache == null)
            {
                lock (_lockObj)
                {
                    if (_cache == null)
                    {
                        string _cacheName = ConfigUtil.GetSection("CacheSetting").Value;
                        if ("Default".Equals(_cacheName, StringComparison.CurrentCultureIgnoreCase))
                            _cache = new DefaultCache();
                        else
                            _cache = new RedisCache();
                    }
                }

            }
            return _cache;

        }
        
        
    }
}
