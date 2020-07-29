using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Services
{
    public class ServiceBase<TService> where TService:class,new ()
    {
        static TService _instance = null;
        public static TService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TService();
                return _instance;
            }
        }
    }
}
