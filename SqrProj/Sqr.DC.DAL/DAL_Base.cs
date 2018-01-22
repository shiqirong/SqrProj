using Sqr.DC.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.DC.DAL
{
    public class DAL_Base<T> where T: class
    {
        /// <summary>
        /// 判断是否存在 by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Exists(object id)
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
            using (var dbContext = new DBContext())
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
            using (var dbContext = new DBContext())
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
        public virtual T GetById(object id)
        {
            using (var dbContext = new DBContext())
            {
                return dbContext.Set<T>().Find(id);
            }
        }

        /// <summary>
        /// 获取一个实体 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual T GetOne(Expression<Func<T, bool>> where)
        {
            using (var dbContext = new DBContext())
            {
                return dbContext.Set<T>().SingleOrDefault(where);
            }
        }

        /// <summary>
        /// 获取多个实体 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual List<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DBContext())
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
            using (var dbContext = new DBContext())
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
            using (var dbContext = new DBContext())
            {
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
        }
        public virtual int Add(IEnumerable<T> entities, bool isUseBulkInsert = false)
        {
            using (var dbContext = new DBContext())
            {
                if (isUseBulkInsert)
                {
                    dbContext.BulkInsert(entities);
                }
                else
                {
                    foreach (var entity in entities)
                    {
                        dbContext.Set<T>().Add(entity);
                    }
                }
                return dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Update(T entity)
        {
            using (var dbContext = new DBContext())
            {
                if (!dbContext.Set<T>().Local.Contains(entity))
                {
                    dbContext.Set<T>().Attach(entity);
                }
                dbContext.Entry(entity).State = EntityState.Modified;
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
            using (var dbContext = new DBContext())
            {
                return dbContext.Database.ExecuteSqlCommand(sql, paramItem);
            }
        }

        public virtual int Update(IEnumerable<T> entitys)
        {
            using (var dbContext = new DBContext())
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
            using (var dbContext = new DBContext())
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

        /// <summary>
        /// 批量删除实体 by some where
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Deletes(Expression<Func<T, bool>> where)
        {
            using (var dbContext = new DBContext())
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
            using (var dbContext = new DBContext())
            {
                return dbContext.Database.SqlQuery<TObj>(sql, parameters).ToList();
            }
        }


        #region 查询第一条
        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DBContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                return paths.Aggregate(query, (current, path) => current.Include(path)).FirstOrDefault(filter);
            }
        }

        public virtual T FirstOrDefault<S>(Expression<Func<T, bool>> filter, Expression<Func<T, S>> orderBy, params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DBContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                return paths.Aggregate(query, (current, path) => current.Include(path)).OrderByDescending(orderBy).FirstOrDefault(filter);
            }
        }


        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order,
           params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DBContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                query = paths.Aggregate(query, (current, path) => current.Include(path));
                return order(query).FirstOrDefault(filter);
            }
        }
        #endregion

        #region 查询唯一

        public virtual T SingleOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DBContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                return paths.Aggregate(query, (current, path) => current.Include(path)).SingleOrDefault(filter);
            }
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order,
            params Expression<Func<T, object>>[] paths)
        {
            using (var dbContext = new DBContext())
            {
                var query = dbContext.Set<T>().AsQueryable();
                query = paths.Aggregate(query, (current, path) => current.Include(path));
                return order(query).SingleOrDefault(filter);
            }
        }
        #endregion

        #region 集合查询
        public List<T> Query(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths)
        {
            using (var dbCotext = new DBContext())
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
            using (var dbCotext = new DBContext())
            {

                // this._dbContext.Database.Log = m => this.Log(m);
                var query = dbCotext.Set<T>().Where(filter);
                query = paths.Aggregate(query, (current, path) => current.Include(path));
                return order(query)
                    .Take(top)
                    .ToList();
            }
        }
        #endregion
    }
}
