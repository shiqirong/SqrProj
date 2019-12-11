using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Dapper.Linq
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

    public class PagedQuery
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
