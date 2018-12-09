using Sqr.Common.Response;
using Sqr.DC.EF.Interface;
using Sqr.DC.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sqr.DC.EF
{
    public class BaseRepository<T> where T : BaseMo,new()
    {
        /// <summary>
        /// 判断是否存在 by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Exists(int id)
        {
            return this.GetById(id) != null;
        }

        /// <summary>
        /// 判断是否存在 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual bool Exists(Expression<Func<T, bool>> where)
        {
            using (var dbContext = new DcContext())
            {
                return dbContext.Set<T>().Any(where);
            }
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll(params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DcContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                foreach (var path in paths)
                {
                    query = query.Include(path);
                }
                return query.ToList();
            }
        }

        /// <summary>
        /// 获取所有实体

        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll<S>(Expression<Func<T, S>> orderBy, bool IsAsc)
        {
            using (var dbContext = new DcContext())
            {
                if (IsAsc)
                {
                    return dbContext.Set<T>().OrderBy(orderBy).ToList();
                }
                else
                {
                    return dbContext.Set<T>().OrderByDescending(orderBy).ToList();
                }
            }
        }

        /// <summary>
        /// 获取实体 by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(long id)
        {
            using (var dbContext = new DcContext())
            {
                return dbContext.Set<T>().Find(id);
            }
        }

        /// <summary>
        /// 获取一个实体 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            using (var dbContext = new DcContext())
            {
                return dbContext.Set<T>().SingleOrDefault(where);
            }
        }

        /// <summary>
        /// 获取多个实体 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual List<T> GetMany(Expression<Func<T, bool>> where,  params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DcContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                foreach (var path in paths)
                {
                    query = query.Include(path);
                }
                return query.Where(where).ToList();
            }
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            using (var dbContext = new DcContext())
            {
                return dbContext.Set<T>().Count(where);
            }
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Add(T entity)
        {
            using (var dbContext = new DcContext())
            {
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
        }
        //public virtual int Add(IEnumerable<T> entities, bool isUseBulkInsert = false)
        //{
        //    using (var dbContext = new DcContext())
        //    {
        //        if (isUseBulkInsert)
        //        {
        //            dbContext.BulkInsert(entities);
        //        }
        //        else
        //        {
        //            foreach (var entity in entities)
        //            {
        //                dbContext.Set<T>().Add(entity);
        //            }
        //        }
        //        return dbContext.SaveChanges();
        //    }
        //}

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Update(T entity)
        {
            using (var dbContext = new DcContext())
            {
                if (!dbContext.Set<T>().Local.Contains(entity))
                {
                    dbContext.Set<T>().Attach(entity);
                }
                dbContext.Entry(entity).State = EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }

        public virtual int Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            using (var dbContext = new DcContext())
            {
                //entity=dbContext.Set<T>().Where(c => c.Id == 1).FirstOrDefault();
                var dbEntityEntry=dbContext.Entry(entity);
                if (dbEntityEntry.Entity == null || dbEntityEntry.State== EntityState.Detached) {
                    var dbEntityAttach = dbContext.Set<T>().Attach(entity);
                    dbEntityEntry = dbContext.Entry(entity);
                }
                
                if (updatedProperties.Any())
                {
                    foreach (var property in updatedProperties)
                    {
                        dbEntityEntry.Property(property).IsModified = true;
                    }
                }
                else
                {
                    foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                    {
                        var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                        var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                        if (original != null && !original.Equals(current))
                        {
                            dbEntityEntry.Property(property).IsModified = true;
                        }
                    }
                }
                return dbContext.SaveChanges();
            }
        }


        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int ExecuteUpdata(string sql, params object[] paramItem)
        {
            using (var dbContext = new DcContext())
            {
                return dbContext.Database.ExecuteSqlCommand(sql, paramItem);
            }
        }

        public virtual int Update(IEnumerable<T> entitys)
        {
            using (var dbContext = new DcContext())
            {
                foreach (var entity in entitys)
                {
                    if (!dbContext.Set<T>().Local.Contains(entity))
                    {
                        dbContext.Set<T>().Attach(entity);
                    }
                    dbContext.Entry(entity).State = EntityState.Modified;
                }
                return dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Delete(T entity)
        {
            using (var dbContext = new DcContext())
            {
                if (!dbContext.Set<T>().Local.Contains(entity))
                {
                    dbContext.Set<T>().Attach(entity);
                }
                if (entity is ISoftDelete)
                {
                    (entity as ISoftDelete).IsDeleted = true;
                    dbContext.Entry<T>(entity).State = EntityState.Modified;
                }
                else
                {
                    if (!dbContext.Set<T>().Local.Contains(entity))
                    {
                        dbContext.Set<T>().Attach(entity);
                    }
                    dbContext.Set<T>().Remove(entity);
                }
                return dbContext.SaveChanges();
            }
        }

        public virtual int Delete(long id)
        {
            using (var dbContext = new DcContext())
            {
                var dbEntityEntry=dbContext.Entry(new T()
                {
                    Id = id,
                    IsDeleted=1
                });
                dbEntityEntry.Property("Id").IsModified = true;
                return dbContext.SaveChanges();
                
            }
        }

        /// <summary>
        /// 批量删除实体 by some where
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Deletes(Expression<Func<T, bool>> where)
        {
            using (var dbContext = new DcContext())
            {
                foreach (var entity in dbContext.Set<T>().Where(where))
                {
                    if (entity is ISoftDelete)
                    {
                        (entity as ISoftDelete).IsDeleted = true;
                        dbContext.Entry<T>(entity).State = EntityState.Modified;
                    }
                    else
                    {
                        dbContext.Set<T>().Remove(entity);
                    }
                }
                return dbContext.SaveChanges();
            }
        }

        public virtual List<TObj> Query<TObj>(string sql, params object[] parameters)
        {
            using (var dbContext = new DcContext())
            {
                return dbContext.Database.SqlQuery<TObj>(sql, parameters).ToList();
            }
        }



        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DcContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                return paths.Aggregate(query, (current, path) => current.Include(path)).FirstOrDefault(filter);
            }
        }

        public virtual T FirstOrDefault<S>(Expression<Func<T, bool>> filter, Expression<Func<T, S>> orderBy, params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DcContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                return paths.Aggregate(query, (current, path) => current.Include(path)).OrderByDescending(orderBy).FirstOrDefault(filter);
            }
        }


        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order,
           params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DcContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                query = paths.Aggregate(query, (current, path) => current.Include(path));
                return order(query).FirstOrDefault(filter);
            }
        }


        public virtual T SingleOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DcContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                return paths.Aggregate(query, (current, path) => current.Include(path)).SingleOrDefault(filter);
            }
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order,
            params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DcContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                query = paths.Aggregate(query, (current, path) => current.Include(path));
                return order(query).SingleOrDefault(filter);
            }
        }



        public List<T> Query(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths)
        {
            using (var dbCotext = new DcContext())
            {
                var query = dbCotext.Set<T>().Where(filter);
                if (paths != null)
                {
                    foreach (var path in paths)
                    {
                        query = query.Include(path);
                    }
                }
                return query.ToList();
            }
        }
        public List<T> Query(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order,
            int top = int.MaxValue, params Expression<Func<T, object>>[] paths)
        {
            using (var dbCotext = new DcContext())
            {

                // this._dbContext.Database.Log = m => this.Log(m);
                var query = dbCotext.Set<T>().Where(filter);
                query = paths.Aggregate(query, (current, path) => current.Include(path));
                return order(query)
                    .Take(top)
                    .ToList();
            }
        }

        public async Task<PageResult<T>> QueryPagedAsync(PageRequest pageInput,Expression<Func<T,bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order)
        {
            PageResult<T> pageResult = new PageResult<T>();
            using (var dbCotext = new DcContext())
            {
                pageResult.Total = dbCotext.Set<T>().Where(filter).Count();

                pageResult.Rows= await order(dbCotext.Set<T>().Where(filter))
                    .Skip((pageInput.PageIndex-1)*pageInput.PageSize)
                    .Take(pageInput.PageSize)
                    .ToListAsync();
            }
            return pageResult;
        }

    }
}
