using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Paging
{
    public class PagingInput<T>
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public T InputData { get; set; }


    }
}
