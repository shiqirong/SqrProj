using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Paging
{
    public class PagingInput<T>
    {
        int _page = 1;
        int _limit = 1;

        public int Page
        {
            get
            {

                return _page;
            }
            set
            {
                if (value <= 0)
                    value = 1;
                _page = value;
            }
        }


        public int Limit
        {
            get
            {

                return _limit;
            }
            set
            {
                if (value <= 0)
                    value = 1;
                _limit = value;
            }
        }

        public T InputData { get; set; }


    }
}
