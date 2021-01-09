using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.Dapper.Linq
{
    public enum OrderByEnum
    {
        ASC,
        DESC
    }
    public class OrderByItem
    {
        public MemberExpression ColumnName { get; set; }

        public OrderByEnum OrderBy { get; set; }

    }

    public class OrderByBuilder<T>
    {
        public  OrderByBuilder<T> OrderBy(Expression<Func<T, dynamic>> exp)
        {
            return this;
        }
        public OrderByBuilder<T> OrderByDesc(Expression<Func<T, dynamic>> exp)
        {
            return this;
        }
    }
}
