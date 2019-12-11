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

        public string TotalSql { get; set; }

        public bool IsPaged { get; set; }

        public override string Sql
        {
            get {
                if (IsPaged)
                    return _select + _from + _join + _where + _order;
                else
                    return "";
            }
            protected set { }
        }


        public virtual SelectSqlFactory Paged(int pageIndex, int pageSize)
        {
            _paged = $" LIMIT {(pageIndex - 1) * pageSize},{pageSize}";
            IsPaged = true;

            TotalSql = $"SELECT COUNT(1) FROM ({Sql}) PageTab";

            return this;
        }
    }
    public class SelectSqlFactory<T1> : SelectSqlFactory
    {
        public SelectSqlFactory<T1> From<T>()
        {
            var type = typeof(T);
            _from = $" From {type.Name} {GetAlias(type.FullName)}";
            return this;
        }

        public SelectSqlFactory<T1> LeftJoin<T>(Expression<Func<T1, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" LEFT JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1> InnerJoin<T>(Expression<Func<T1, bool>> joinConditon)
        {
            var type = typeof(T);
            _join += $" JOIN {type.Name} {GetAlias(type.FullName)} ON  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)}";
            return this;
        }

        public SelectSqlFactory<T1> Select(Expression<Func<T1, dynamic>> joinConditon)
        {
            _select = $" SELECT  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1> Where(Expression<Func<T1, dynamic>> joinConditon)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1> OrderBy(Expression<Func<T1, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1> OrderByDesc(Expression<Func<T1, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} DESC ";
            return this;
        }

    }

    public class SelectSqlFactory<T1, T2> : SelectSqlFactory
    {

        List<string> _myTypes = null;

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
        public SelectSqlFactory<T1, T2> Where(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2> OrderBy(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2> OrderByDesc(Expression<Func<T1, T2, dynamic>> joinConditon)
        {
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
        public SelectSqlFactory<T1, T2, T3> Where(Expression<Func<T1, T2, T3, bool>> joinConditon)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3> OrderBy(Expression<Action<T1, T2, T3>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3> OrderByDesc(Expression<Action<T1, T2, T3>> joinConditon)
        {
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
        public SelectSqlFactory<T1, T2, T3, T4> Where(Expression<Func<T1, T2, T3, T4>> joinConditon)
        {
            _where = $" WHERE  {ReplaceAlias(Linq2SqlHelper.DealExpress(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3, T4> OrderBy(Expression<Action<T1, T2, T3, T4>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} ";
            return this;
        }

        public SelectSqlFactory<T1, T2, T3, T4> OrderByDesc(Expression<Action<T1, T2, T3, T4>> joinConditon)
        {
            _order = $" ORDER BY  {ReplaceAlias(Linq2SqlHelper.DealMemberExpresion(joinConditon, _paramsList), joinConditon.Parameters)} DESC ";
            return this;
        }


    }
}
