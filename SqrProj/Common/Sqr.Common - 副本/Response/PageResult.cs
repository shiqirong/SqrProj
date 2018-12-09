using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Response
{
    public class PageResult<T>
    {
        public long Total { get; set; }

        public IList<T> Rows { get; set; }
    }
}
