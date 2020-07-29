using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Dtos
{
    public class PagingOutput<T>
    {
        public int PageIndex { get; set; } 

        public int PageSize { get; set; }

        public int Total { get; set; }

        public IList<T> Rows { get; set; }
             
    }
}
