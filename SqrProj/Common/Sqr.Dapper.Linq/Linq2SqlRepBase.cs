using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.Dapper.Linq
{
    public class Linq2SqlRepBase
    {
        private string _connectionString = string.Empty;
        public Linq2SqlRepBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Query

        public TOut QuerySigle<TOut, T1>(Action<SelectSqlFactory<T1>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).Single();
            }
        }

        public TOut QuerySingleOrDefault<TOut, T1>(Action<SelectSqlFactory<T1>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).SingleOrDefault();
            }

        }

        public IList<TOut> QueryList<TOut, T1>(Action<SelectSqlFactory<T1>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
            }
        }

        public PagedList<TOut> QueryPaged<TOut, T1>(Action<SelectSqlFactory<T1>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1>();
            act(linq2Sql);
            PagedList<TOut> pl = new PagedList<TOut>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
                pl.Total = connection.ExecuteScalar<long>(linq2Sql.TotalSql, linq2Sql.ParamsList);
            }
            return pl;
        }

        public TOut QuerySigle<TOut, T1,T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).Single();
            }
        }

        public TOut QuerySingleOrDefault<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).SingleOrDefault();
            }

        }

        public IList<TOut> QueryList<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
            }
        }

        public PagedList<TOut> QueryPaged<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            PagedList<TOut> pl = new PagedList<TOut>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
                pl.Total = connection.ExecuteScalar<long>(linq2Sql.TotalSql, linq2Sql.ParamsList);
            }
            return pl;
        }


        public TOut QuerySigle<TOut, T1, T2,T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).Single();
            }
        }

        public TOut QuerySingleOrDefault<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).SingleOrDefault();
            }

        }

        public IList<TOut> QueryList<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
            }
        }

        public PagedList<TOut> QueryPaged<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            PagedList<TOut> pl = new PagedList<TOut>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
                pl.Total = connection.ExecuteScalar<long>(linq2Sql.TotalSql, linq2Sql.ParamsList);
            }
            return pl;
        }



        public TOut QuerySigle<TOut, T1, T2, T3,T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).Single();
            }
        }

        public TOut QuerySingleOrDefault<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).SingleOrDefault();
            }

        }

        public IList<TOut> QueryList<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
            }
        }

        public PagedList<TOut> QueryPaged<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            PagedList<TOut> pl = new PagedList<TOut>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = connection.Query<TOut>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
                pl.Total = connection.ExecuteScalar<long>(linq2Sql.TotalSql, linq2Sql.ParamsList);
            }
            return pl;
        }

        #endregion

        #region Insert

        public int Insert<T>(T entity)
        {
            var insertFactory = new InsertSqlFactory<T>().Insert(entity);

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Execute(insertFactory.Sql, insertFactory.ParamsList);
            }
        }

        #endregion

        #region Update

        public int Update<T>(Expression<Func<T,dynamic>> setExp ,Expression<Func<T,bool>> whereExp)
        {
            var updateFactory = new UpdateSqlFactory<T>().Update(setExp,whereExp);
            
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Execute(updateFactory.Sql, updateFactory.ParamsList);
            }
        }

        #endregion

        #region Delete

        public int Delete<T>( Expression<Func<T, bool>> whereExp)
        {
            var deleteFactory = new DeleteSqlFactory<T>().Delete( whereExp);

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Execute(deleteFactory.Sql, deleteFactory.ParamsList);
            }
        }

        #endregion
    }
}
