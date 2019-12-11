using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.Dapper.Linq
{
    public class DeleteSqlFactory<T> : Linq2SqlFactory
    {


        public override string Sql
        {
            get
            {
                return $"Delete {_from}   WHERE {_where}";
            }
        }

        public DeleteSqlFactory<T> Delete(Expression<Func<T, bool>> whereExpression)
        {
            var type = typeof(T);
            _from = $" FROM {type.Name} {GetAlias(type.FullName)}";


            _where = ReplaceAlias(Linq2SqlHelper.DealExpress(whereExpression, _paramsList), whereExpression.Parameters);

            return this;
        }
    }
}
