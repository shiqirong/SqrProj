using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.Dapper.Linq
{
    public class SelectSqlFactory : Linq2SqlFactory
    {

        protected string _paged = string.Empty;

        public string TotalSql {
            get
            {
                return $"SELECT COUNT(1) FROM ({ _select + _from + _join + _where }) PageTab";;
            }
            protected set { }
        }

        public bool IsPaged { get; set; }

        public override string Sql
        {
            get {
                if (IsPaged)
                    return _select + _from + _join + _where + _order +_paged;
                else
                    return _select + _from + _join + _where + _order;
            }
            protected set { }
        }


        public virtual SelectSqlFactory Paged(int pageIndex, int pageSize)
        {
            _paged = $" LIMIT {(pageIndex - 1) * pageSize},{pageSize}";
            IsPaged = true;

            return this;
        }
    }
    public class SelectSqlFactory<T1> : SelectSqlFactory
    {

        public SelectSqlFactory<T1> Where(Expression<Func<T1, bool>> whereExp)
        {
            var alias=whereExp.Parameters.First();

            var type = typeof(T1);
            _from = $" from {type.Name} {alias.Name}";

            var i = 0;
            var ps = type.GetProperties();
            foreach (var p in ps)
            {
                if (i == 0)
                {
                    _select += $"{alias.Name}.{p.Name}";
                }
                else
                {
                    _select += $",{alias.Name}.{p.Name}";
                }
                i++;
            }
            _select = $"SELECT {_select}";

            _where = $" WHERE  {Linq2SqlHelper.DealMemberExpresion(whereExp, _paramsList)} ";
            return this;
        }

        public SelectSqlFactory<T1> OrderBy(Expression<Func<T1, IList<dynamic>>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList)} ";
            return this;
        }

        public SelectSqlFactory<T1> OrderByDesc(Expression<Func<T1, dynamic>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList)} DESC ";
            return this;
        }

    }

    public class SelectSqlFactory<T1, T2> : SelectSqlFactory
    {

        public SelectSqlFactory<T1, T2> From<T>()
        {
            var type = typeof(T);
            _from = $" From {type.Name} {GetAlias(type.FullName)}";
            return this;
        }

        public SelectSqlFactory<T1, T2> LeftJoin<T>(Expression<Func<T1, T2, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" LEFT JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1, T2> InnerJoin<T>(Expression<Func<T1, T2, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1, T2> Select(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            _select = $" SELECT  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }
        public SelectSqlFactory<T1, T2> Where(Expression<Func<T1, T2, bool>> whereExp)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(whereExp, _paramsList), whereExp.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2> OrderBy(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2> OrderByDesc(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} DESC ";
            return this;
        }
    }

    public class SelectSqlFactory<T1, T2, T3> : SelectSqlFactory
    {

        public SelectSqlFactory<T1, T2, T3> From<T>()
        {
            var type = typeof(T);
            _from = $" From {type.Name} {GetAlias(type.FullName)}";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3> LeftJoin<T>(Expression<Func<T1, T2, T3, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" LEFT JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3> InnerJoin<T>(Expression<Func<T1, T2, T3, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3> Select(Expression<Func<T1, T2, T3, dynamic>> joinConditon)
        {
            _select = $" SELECT  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }
        public SelectSqlFactory<T1, T2, T3> Where(Expression<Func<T1, T2, T3, bool>> whereExp)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealExpress(whereExp, _paramsList), whereExp.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3> OrderBy(Expression<Action<T1, T2, T3>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3> OrderByDesc(Expression<Action<T1, T2, T3>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} DESC ";
            return this;
        }


    }

    public class SelectSqlFactory<T1, T2, T3, T4> : SelectSqlFactory
    {

        public SelectSqlFactory<T1, T2, T3, T4> From<T>()
        {
            var type = typeof(T);
            _from = $" From {type.Name} {GetAlias(type.FullName)}";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3, T4> LeftJoin<T>(Expression<Func<T1, T2, T3, T4>> joinConditon)
        {
            var type = typeof(T);
            _join += $" LEFT JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3, T4> InnerJoin<T>(Expression<Func<T1, T2, T3, T4>> joinConditon)
        {
            var type = typeof(T);
            _join += $" JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3, T4> Select(Expression<Func<T1, T2, T3, T4, dynamic>> joinConditon)
        {
            _select = $" SELECT  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }
        public SelectSqlFactory<T1, T2, T3, T4> Where(Expression<Func<T1, T2, T3, T4, bool>> whereExp)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealExpress(whereExp, _paramsList), whereExp.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3, T4> OrderBy(Expression<Action<T1, T2, T3, T4>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3, T4> OrderByDesc(Expression<Action<T1, T2, T3, T4>> joinConditon)
        {
            if (joinConditon != null)
                _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} DESC ";
            return this;
        }


    }
}
