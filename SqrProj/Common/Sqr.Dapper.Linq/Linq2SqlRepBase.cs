using Dapper;
using Sqr.Dapper.Linq.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Dapper.Linq
{
    public class Linq2SqlRepBase
    {
        protected string _connectionString = string.Empty;

        public Linq2SqlRepBase()
        {

        }

        public Linq2SqlRepBase(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #region Query

        public T QuerySingle<T>(Expression<Func<T,bool>> whereExp)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<T>(linq2Sql.Sql, linq2Sql.ParamsList).Single();
            }
        }

        public async Task<T> QuerySingleAsync<T>(Expression<Func<T, bool>> whereExp)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<T>(linq2Sql.Sql, linq2Sql.ParamsList)).Single();
            }
        }

        public T QuerySingleOrDefault<T>(Expression<Func<T, bool>> whereExp)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<T>(linq2Sql.Sql, linq2Sql.ParamsList);
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(Expression<Func<T, bool>> whereExp)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QuerySingleOrDefaultAsync<T>(linq2Sql.Sql, linq2Sql.ParamsList));
            }
        }

        public T QueryFirstOrDefault<T>(Expression<Func<T, bool>> whereExp)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<T>(linq2Sql.Sql, linq2Sql.ParamsList);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(Expression<Func<T, bool>> whereExp, Expression<Func<T, IList<dynamic>>>  orderBy)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp).OrderBy(orderBy);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryFirstOrDefaultAsync<T>(linq2Sql.Sql, linq2Sql.ParamsList));
            }
        }

        public IList<T> QueryList<T>(Expression<Func<T, bool>> whereExp)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Query<T>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
            }
        }

        public async Task<IList<T>> QueryListAsync<T>(Expression<Func<T, bool>> whereExp)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<T>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
            }
        }

        public PagedList<T> QueryPaged<T>(Expression<Func<T, bool>> whereExp, PagedQueryParams pagedParams)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp).Paged(pagedParams.PageIndex, pagedParams.PageSize);
            PagedList <T> pl = new PagedList<T>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = connection.Query<T>(linq2Sql.Sql, linq2Sql.ParamsList).ToList();
                pl.Total = connection.ExecuteScalar<long>(linq2Sql.TotalSql, linq2Sql.ParamsList);
            }
            return pl;
        }
        public async Task<PagedList<T>> QueryPagedAsync<T>(Expression<Func<T, bool>> whereExp, PagedQueryParams pagedParams )
        {
            return await QueryPagedAsync<T>(whereExp, null,pagedParams);
        }
        public async Task<PagedList<T>> QueryPagedAsync<T>(Expression<Func<T, bool>> whereExp, Expression<Func<T, IList<dynamic>>> orderBy=null, PagedQueryParams pagedParams=null)
        {
            var linq2Sql = new SelectSqlFactory<T>().Where(whereExp)/*.OrderBy(orderBy)*/.Paged(pagedParams.PageIndex, pagedParams.PageSize);
            PagedList<T> pl = new PagedList<T>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = (await connection.QueryAsync<T>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
                pl.Total = (await connection.ExecuteScalarAsync<long>(linq2Sql.TotalSql, linq2Sql.ParamsList));
            }
            return pl;
        }

        public TOut QuerySigle<TOut, T1,T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QuerySingle<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }
        }

        public async Task<TOut> QuerySigleAsync<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QuerySingleAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
            }
        }

        public TOut QuerySingleOrDefault<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }

        }

        public async Task<TOut> QuerySingleOrDefaultAsync<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QuerySingleOrDefaultAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
            }

        }

        public TOut QueryFirstOrDefault<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }

        }

        public async Task<TOut> QueryFirstOrDefaultAsync<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryFirstOrDefaultAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
            }

        }
        

        public async Task<IList<TOut>> QueryListAsync<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
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

        public async  Task<PagedList<TOut>> QueryPagedAsync<TOut, T1, T2>(Action<SelectSqlFactory<T1, T2>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2>();
            act(linq2Sql);
            PagedList<TOut> pl = new PagedList<TOut>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = (await connection.QueryAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
                pl.Total = (await connection.ExecuteScalarAsync<long>(linq2Sql.TotalSql, linq2Sql.ParamsList));
            }
            return pl;
        }

        public async Task<TOut> QuerySigleAsync<TOut, T1, T2,T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList)).Single();
            }
        }

        public TOut QuerySingleOrDefault<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }

        }

        public async Task<TOut> QuerySingleOrDefaultAsync<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QuerySingleOrDefaultAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
            }

        }

        public TOut QueryFirstOrDefault<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }

        }

        public async Task<TOut> QueryFirstOrDefaultAsync<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryFirstOrDefaultAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
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

        public async Task<IList<TOut>> QueryListAsync<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
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

        public async Task<PagedList<TOut>> QueryPagedAsync<TOut, T1, T2, T3>(Action<SelectSqlFactory<T1, T2, T3>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3>();
            act(linq2Sql);
            PagedList<TOut> pl = new PagedList<TOut>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = (await connection.QueryAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
                pl.Total = (await connection.ExecuteScalarAsync<long>(linq2Sql.TotalSql, linq2Sql.ParamsList));
            }
            return pl;
        }



        public TOut QuerySingle<TOut, T1, T2, T3,T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QuerySingle<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }
        }

        public async Task<TOut> QuerySingleAsync<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QuerySingleAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
            }
        }

        public TOut QuerySingleOrDefault<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }

        }

        public async Task<TOut> QuerySingleOrDefaultAsync<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QuerySingleOrDefaultAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
            }

        }


        public TOut QueryFirstOrDefault<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<TOut>(linq2Sql.Sql, linq2Sql.ParamsList);
            }

        }

        public async Task<TOut> QueryFirstOrDefaultAsync<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryFirstOrDefaultAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList));
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

        public async Task<IList<TOut>> QueryListAsync<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
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

        public async Task< PagedList<TOut>> QueryPagedAsync<TOut, T1, T2, T3, T4>(Action<SelectSqlFactory<T1, T2, T3, T4>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1, T2, T3, T4>();
            act(linq2Sql);
            PagedList<TOut> pl = new PagedList<TOut>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                pl.Data = (await connection.QueryAsync<TOut>(linq2Sql.Sql, linq2Sql.ParamsList)).ToList();
                pl.Total = (await connection.ExecuteScalarAsync<long>(linq2Sql.TotalSql, linq2Sql.ParamsList));
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

        public async Task<int> InsertAsync<T>(T entity)
        {
            var insertFactory = new InsertSqlFactory<T>().Insert(entity);

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.ExecuteAsync(insertFactory.Sql, insertFactory.ParamsList));
            }
        }

        #endregion

        #region Update

        public int Update<T>(Expression<Func<T, dynamic>> setExp, Expression<Func<T, bool>> whereExp)
        {
            var updateFactory = new UpdateSqlFactory<T>().Update(setExp, whereExp);

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Execute(updateFactory.Sql, updateFactory.ParamsList);
            }
        }

        public  async Task<int> UpdateAsync<T>(Expression<Func<T,dynamic>> setExp ,Expression<Func<T,bool>> whereExp)
        {
            var updateFactory = new UpdateSqlFactory<T>().Update(setExp,whereExp);
            
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.ExecuteAsync(updateFactory.Sql, updateFactory.ParamsList));
            }
        }

        #endregion

        #region Delete

        public int Delete<T>(Expression<Func<T, bool>> whereExp)
        {
            var deleteFactory = new DeleteSqlFactory<T>().Delete(whereExp);

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return connection.Execute (deleteFactory.Sql, deleteFactory.ParamsList);
            }
        }
        public async Task<int> DeleteAsync<T>( Expression<Func<T, bool>> whereExp)
        {
            var deleteFactory = new DeleteSqlFactory<T>().Delete( whereExp);

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                return (await connection.ExecuteAsync(deleteFactory.Sql, deleteFactory.ParamsList));
            }
        }

        #endregion
    }
}
