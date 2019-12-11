

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.Dapper.Linq
{
    public class UpdateSqlFactory<T>:Linq2SqlFactory
    {

        protected string _set = string.Empty;


        public override string Sql
        {
            get
            {
                return $"UPDATE {_from} SET {_set} WHERE {_where}";
            }
        }

        public UpdateSqlFactory<T> Update(Expression<Func<T,dynamic>> setExp, Expression< Func<T, bool>> whereExpression)
        {
            var type = typeof(T);
            _from = $"  {type.Name} {GetAlias(type.FullName)}";

            _set = ReplaceAlias(Linq2SqlHelper.DealExpress(setExp, _paramsList,CommandType.UPDATE), setExp.Parameters);

            _where = ReplaceAlias(Linq2SqlHelper.DealExpress(whereExpression, _paramsList,CommandType.UPDATE),whereExpression.Parameters);

            return this;
        }
    }
}


