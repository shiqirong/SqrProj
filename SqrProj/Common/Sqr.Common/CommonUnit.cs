using Sqr.Common.Cache;
using Sqr.Common.IOC;
using Sqr.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqr.Common
{
    public sealed class CommonUnit
    {
        
        static WeakReference<ICache> _Cache = new WeakReference<ICache>(AutofacConfig.Resolve<ICache>());
        public static ICache Cache
        {
            get
            {
                ICache target = null;
                if(!_Cache.TryGetTarget(out target))
                {
                    _Cache.SetTarget(AutofacConfig.Resolve<ICache>());
                }
                return target;
            }
        }


        static WeakReference<ILogger> _Logger = new WeakReference<ILogger>(AutofacConfig.Resolve<ILogger>());
        public static ILogger Logger
        {
            get
            {
                ILogger target = null;
                if (!_Logger.TryGetTarget(out target))
                {
                    _Logger.SetTarget(AutofacConfig.Resolve<ILogger>());
                }
                return target;
            }
        }
    }
}
