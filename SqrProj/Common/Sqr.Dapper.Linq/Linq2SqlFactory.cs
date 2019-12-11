using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace Sqr.Dapper.Linq
{
    public interface IJoinExpression
    {

        IJoinExpression Join<T1>(Expression<Func<IJoinExpression, T1, bool>> joinConditon);
    }
    public  class JoinExporession : IJoinExpression
    {
        IJoinExpression _JoinExpression = null;

        public IJoinExpression Join<T>(Expression<Func<IJoinExpression,T, bool>> joinConditon)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Linq2SqlFactory
    {
        protected string _sql = string.Empty;
        protected string _select = string.Empty;
        protected string _from = string.Empty;
        protected string _join = string.Empty;
        protected string _where = string.Empty;
        protected string _order = string.Empty;
        protected List<string> _myTypes = null;
        protected IList<KeyValuePair<string, object>> _paramsList = new List<KeyValuePair<string, object>>() ;

        public Linq2SqlFactory()
        {
            _myTypes = this.GetType().GetGenericArguments().Select(c => c.FullName).ToList();
        }

        public virtual IList<KeyValuePair<string, object>> ParamsList
        {
            get
            {
                return _paramsList;
            }
            protected set { }
        }

        public virtual string Sql
        {
            get;
            protected set;
        }

        protected string ReplaceAlias(string sql, IList<ParameterExpression> paramers)
        {
            for (var i = 0; i < paramers.Count; i++)
            {
                sql = sql.Replace($" {paramers[i].Name}.", $" T{i}.");
            }
            return sql;
        }

        protected string GetAlias(string typeFullName)
        {
            for (var i = 0; i < _myTypes.Count; i++)
            {
                if (_myTypes[i] == typeFullName)
                    return $"T{i}";
            }
            return string.Empty;
        }
    }


}
