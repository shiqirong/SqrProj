using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common
{
    public class IdHelper
    {
        public static long GetNewId()
        {
            var id = DateTime.Now.Year * 10000000000000;
            id += DateTime.Now.Month * 100000000000;
            id += DateTime.Now.Day * 1000000000;
            id += DateTime.Now.Hour * 10000000;
            id += DateTime.Now.Minute * 100000;
            id += DateTime.Now.Second * 1000;
            id += DateTime.Now.Millisecond;
            return id;
        }
    }
}
