using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Admin.App
{
    public abstract class BaseBusiness<T> where T : class, new()
    {
        static T _instance = null;
        public static T Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }
}
