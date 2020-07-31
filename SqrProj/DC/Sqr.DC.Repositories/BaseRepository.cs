using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sqr.Common.Utils;
using Sqr.Dapper.Linq;
using Sqr.Dapper.Linq.Common;
using Sqr.DC.Entities;

namespace Sqr.DC.Repositories
{
    public class BaseRepository<TRespositry, TEntity> : Linq2SqlRepBase where TEntity : BaseMo where TRespositry:class ,new()
    {
        static TRespositry _instance = null;
        public static TRespositry Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TRespositry();
                return _instance;
            }
        }
        public BaseRepository()
        {
            _connectionString = ConfigUtil.GetConnectionString("comp");
        }

    

        protected bool WhereIf<T>(bool condition, Expression<Func<bool>> where)
        {
            return true;

        }

        public TEntity GetByIdSingle(long Id)
        {
            return QuerySingle<TEntity>(w => w.Id == Id && w.IsDeleted==0);
        }

        public async Task< TEntity> GetByIdSingleAsync(long Id)
        {
            return await QuerySingleAsync<TEntity>(w => w.Id == Id && w.IsDeleted == 0);
        }

        public TEntity GetByIdSingleOrDefault(long Id)
        {
            return QuerySingleOrDefault<TEntity>(w => w.Id == Id && w.IsDeleted == 0);
        }

        public async Task<TEntity> GetByIdSingleOrDefaultAsync(long Id)
        {
            return await QuerySingleOrDefaultAsync<TEntity>(w => w.Id == Id && w.IsDeleted == 0);
        }

        protected TEntity GetSingle(Expression<Func<TEntity, bool>> whereExp)
        {
            return QuerySingle<TEntity>(whereExp);
        }

        protected async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereExp)
        {
            return await QuerySingleAsync<TEntity>(whereExp);
        }

        protected TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> whereExp)
        {
            return QuerySingleOrDefault<TEntity>(whereExp);
        }

        protected async  Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereExp)
        {
            return await QuerySingleOrDefaultAsync<TEntity>(whereExp);
        }

        protected IList<TEntity> GetList(Expression<Func<TEntity, bool>> whereExp)
        {
            return QueryList<TEntity>(whereExp);
        }

        protected async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> whereExp)
        {
            return await QueryListAsync<TEntity>(whereExp);
        }

        protected PagedList<TEntity> GetPaged(Expression<Func<TEntity, bool>> whereExp, PagedQueryParams pagedParams)
        {
            return QueryPaged<TEntity>(whereExp, pagedParams);
        }

        protected async Task< PagedList<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> whereExp, PagedQueryParams pagedParams)
        {
            return await  QueryPagedAsync<TEntity>(whereExp, pagedParams);
        }

        public int Insert(TEntity entity)
        {
            return Insert<TEntity>(entity);
        }

        public async Task< int> InsertAsync (TEntity entity)
        {
            return await InsertAsync<TEntity>(entity);
        }

        public int Update(Expression<Func<TEntity, dynamic>> setExp, Expression<Func<TEntity, bool>> whereExp)
        {
            return Update<TEntity>(setExp, whereExp);
        }

        public async Task<int> UpdateAsync(Expression<Func<TEntity, dynamic>> setExp, Expression<Func<TEntity, bool>> whereExp)
        {
            return await UpdateAsync<TEntity>(setExp, whereExp);
        }

        public int Delete(Expression<Func<TEntity, bool>> whereExp)
        {
            return Delete<TEntity>(whereExp);
        }

        public async Task<int> Delete<TEntity>(TEntity mo) where TEntity : BaseMo
        {
            return await UpdateAsync<TEntity>(c => new { IsDeleted=1,mo.DeleteUser,DeleteTime=DateTime.Now},c=>c.Id==mo.Id);
        }

        public async Task<int> Remove<TEntity>(long id) where TEntity : BaseMo
        {
            return await DeleteAsync(c => c.Id == id);
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExp)
        {
            return await DeleteAsync<TEntity>(whereExp);
        }
    }
}
