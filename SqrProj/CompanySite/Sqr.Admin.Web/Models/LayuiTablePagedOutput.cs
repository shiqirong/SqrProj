using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Models
{
    public class LayuiTablePagedOutput<T> where T:class
    {
        public int Code { get; set; } = 0;

        public string Msg { get; set; }

        public long Count { get; set; }

        public IList<T> Data { get; set; }
    }
}
