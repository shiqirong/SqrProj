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

    public abstract class Linq2Sql
    {
        protected string _sql = string.Empty;
        protected string _select = string.Empty;
        protected string _from = string.Empty;
        protected string _join = string.Empty;
        protected string _where = string.Empty;
        protected string _order = string.Empty;
        protected List<string> _myTypes = null;

        public Linq2Sql()
        {
            _myTypes = this.GetType().GetGenericArguments().Select(c => c.FullName).ToList();
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

        public string Excute()
        {
            return _select + _from + _join + _where + _order;
        }
    }

    public class Linq2Sql<T1>:Linq2Sql
    {


        public Linq2Sql<T1> From<T>()
        {
            var type = typeof(T);
            _from = $" From {type.Name} {GetAlias(type.FullName)}";
            return this;
        }

        public Linq2Sql<T1> LeftJoin<T>(Expression<Func<T1, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" LEFT JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon), joinConditon.Parameters)}";
            return this;
        }

        public Linq2Sql<T1> InnerJoin<T>(Expression<Func<T1, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon), joinConditon.Parameters)}";
            return this;
        }

        public Linq2Sql<T1> Select(Expression<Func<T1, dynamic>> joinConditon)
        {
            _select = $" SELECT  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} ";
            return this;
        }
        public Linq2Sql<T1> Where(Expression<Func<T1, dynamic>> joinConditon)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} ";
            return this;
        }

        public Linq2Sql<T1> OrderBy(Expression<Func<T1, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} ";
            return this;
        }

        public Linq2Sql<T1> OrderByDesc(Expression<Func<T1, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} DESC ";
            return this;
        }

        public string Excute()
        {
            return _select + _from + _join + _where + _order;
        }


    }

    public class Linq2Sql<T1, T2> : Linq2Sql
    {

        List<string> _myTypes = null;

        public Linq2Sql()
        {
            _myTypes = this.GetType().GetGenericArguments().Select(c => c.FullName).ToList();
        }

        public Linq2Sql<T1, T2> From<T>()
        {
            var type = typeof(T);
            _from = $" From {type.Name} {GetAlias(type.FullName)}";
            return this;
        }

        public Linq2Sql<T1, T2> LeftJoin<T>(Expression<Func<T1, T2, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" LEFT JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon), joinConditon.Parameters)}";
            return this;
        }

        public Linq2Sql<T1, T2> InnerJoin<T>(Expression<Func<T1, T2, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon), joinConditon.Parameters)}";
            return this;
        }

        public Linq2Sql<T1, T2> Select(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            _select = $" SELECT  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} ";
            return this;
        }
        public Linq2Sql<T1, T2> Where(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} ";
            return this;
        }

        public Linq2Sql<T1, T2> OrderBy(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} ";
            return this;
        }

        public Linq2Sql<T1, T2> OrderByDesc(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} DESC ";
            return this;
        }
    }

    public  class Linq2Sql<T1, T2, T3>:Linq2Sql
    {

        public Linq2Sql<T1, T2, T3> From<T>() {
            var type = typeof(T);
            _from = $" From {type.Name} {GetAlias(type.FullName)}";
            return this;
        }

        public Linq2Sql<T1, T2, T3> LeftJoin<T>(Expression<Func<T1, T2, T3, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" LEFT JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias( Linq2SqlHelper.DealExpress(joinConditon),joinConditon.Parameters)}";
            return this;
        }

        public Linq2Sql<T1, T2, T3> InnerJoin<T>(Expression<Func<T1, T2, T3, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon), joinConditon.Parameters)}";
            return this;
        }

        public Linq2Sql<T1, T2, T3> Select(Expression<Func<T1, T2, T3,dynamic>> joinConditon)
        {
            _select=$" SELECT  {ReplaceAlias( Linq2SqlHelper.DealMemberExpresion(joinConditon),joinConditon.Parameters)} ";
            return this;
        }
        public Linq2Sql<T1, T2, T3> Where(Expression<Func<T1, T2, T3, dynamic>> joinConditon)
        {
            _where=$" WHERE  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon),joinConditon.Parameters)} ";
            return this;
        }

        public Linq2Sql<T1, T2, T3> OrderBy(Expression<Func<T1, T2, T3, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} ";
            return this;
        }

        public Linq2Sql<T1, T2, T3> OrderByDesc(Expression<Func<T1, T2, T3, dynamic>> joinConditon)
        {
            _order=$" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon), joinConditon.Parameters)} DESC ";
            return this;
        }


    }

    public class Linq2Sql<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        string _sql = string.Empty;

        public Linq2Sql<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> joinConditon) 
        {
            AppendSql($" SELECT  {Linq2SqlHelper.DealMemberExpresion(joinConditon)} ");
            return this;
        }

        public Linq2Sql<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> RightJoin<T>(Expression<Func<T1,T>> joinConditon) where T : T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15
        {
            AppendSql($" Right JOIN {typeof(T).Name} ON {GetJoinCondition(joinConditon)} ");
            return this;
        }

        public Linq2Sql<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LeftJoin<T>(Expression<Func<T1, T>> joinConditon) where T : T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15
        {
            AppendSql($" LEFT JOIN {typeof(T).Name} ON {GetJoinCondition(joinConditon)} ");
            return this;
        }

        protected void AppendSql(string sql)
        {
            _sql +=  sql;
        }

        protected string GetJoinCondition(Expression joinExpression)
        {
            
            return string.Empty;
        }
    }
}
