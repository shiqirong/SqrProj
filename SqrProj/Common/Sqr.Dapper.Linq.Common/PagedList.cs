using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Dapper.Linq.Common
{
    public class PagedList<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public long Total { get; set; }
        /// <summary>
        /// 数据列表
        /// </summary>
        public IList<T> Data { get; set; }
    }

    public class PagedQueryParams
    {
        int _pageIndex = 1;
        int _pageSize = 1;

        public int PageIndex
        {
            get
            {

                return _pageIndex;
            }
            set
            {
                if (value <= 0)
                    value = 1;
                _pageIndex = value;
            }
        }


        public int PageSize
        {
            get
            {

                return _pageSize;
            }
            set
            {
                if (value <= 0)
                    value = 1;
                _pageSize = value;
            }
        }
    }
}
