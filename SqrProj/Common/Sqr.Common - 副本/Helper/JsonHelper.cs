using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Helper
{
    public static class JsonHelper 
    {
        public static string ToJson(this object obj)
        {
            if (obj == null)
                return string.Empty;
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return default(T);
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
            }
            catch
            {
                return default(T);
            }
        }

    }
}
