using Microsoft.EntityFrameworkCore;
using Sqr.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sqr.DC.Repository.Core
{
    public class BaseRepository<T>:IRepository<T> where T : ModelBase
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
        public virtual List<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] paths)
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
                entity.CreateTime = DateTime.Now;
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
        }
        public virtual int Add(IEnumerable<T> entities/*, bool isUseBulkInsert = false*/)
        {
            using (var dbContext = new DcContext())
            {
                //if (isUseBulkInsert)
                //{
                //    dbContext.BulkInsert(entities);
                //}
                //else
                //{
                    foreach (var entity in entities)
                    {
                        dbContext.Set<T>().Add(entity);
                    }
                //}
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
            using (var dbContext = new DcContext())
            {
                if (!dbContext.Set<T>().Local.Contains(entity))
                {
                    dbContext.Set<T>().Attach(entity);
                }
                entity.UpdateTime = DateTime.Now;
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
                    entity.UpdateTime = DateTime.Now;
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
                    (entity as ISoftDelete).IsDeleted = true;
                    dbContext.Entry<T>(entity).State = EntityState.Modified;
       
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

        public virtual int Remove(T entity)
        {
            using (var dbContext = new DcContext())
            {
                if (!dbContext.Set<T>().Local.Contains(entity))
                {
                    dbContext.Set<T>().Attach(entity);
                }
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges();
            }
        }
        
        //public virtual List<TObj> Query<TObj>(string sql, params object[] parameters)
        //{
        //    using (var dbContext = new DcContext())
        //    {
        //        return dbContext.Database.<TObj>(sql, parameters).ToList();
        //    }
        //}


        #region 查询第一条
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
        #endregion

        #region 查询唯一

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
        #endregion

        #region 集合查询
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
        #endregion

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <param name="keySelector"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public virtual PagingOutput<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> keySelector=null, bool isAsc=true)
        {
            PagingOutput<T> output = new PagingOutput<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            using (var dbContext = new DcContext())
            {
                var query= dbContext.Set<T>().Where(where);
                output.Total = query.Count();
                if (keySelector != null)
                {
                    if (isAsc)
                        query = query.OrderBy(keySelector);
                    else
                        query = query.OrderByDescending(keySelector);
                }
                output.Rows= query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            return output;
        }

        //public static PagedList<UsersDTO> GetUsers(int pageIndex, int pageSize, string orderBy, bool ascending, Companys company, string email, string nickName, bool? isAdmin, UserStatus userStatus)
        //{
        //    PagedList<UsersDTO> result = new PagedList<UsersDTO>(pageIndex, pageSize);
        //    int totalRecord = 0;
        //    Expression<Func<Users, bool>> where = PredicateExtensionses.True<Users>();
        //    if (company != Companys.All) where = where.And(u => u.Company == (int)company);
        //    if (!string.IsNullOrEmpty(email)) where = where.And(u => u.Email.Contains(email));
        //    if (!string.IsNullOrEmpty(nickName)) where = where.And(u => u.NickName.Contains(nickName));
        //    if (isAdmin.HasValue)
        //    {
        //        if (isAdmin.Value) where = where.And(u => u.IsAdmin == 1);
        //        else where = where.And(u => u.IsAdmin == 0);
        //    }
        //    if (userStatus != UserStatus.All) where = where.And(u => u.UserStatus == (int)userStatus);

        //    if (string.IsNullOrEmpty(orderBy))
        //        orderBy = MapHelper.GetMappedName<UsersDTO, Users>(u => u.UserId);
        //    else
        //        orderBy = MapHelper.GetMappedName<UsersDTO, Users>(orderBy);

        //    List<Users> list = _usersDao.GetMany(where, orderBy, ascending, pageIndex, pageSize, out totalRecord);
        //    result.TotalRecordCount = totalRecord;
        //    foreach (var data in list)
        //    {
        //        result.Items.Add(Mapper.Map<Users, UsersDTO>(data));
        //    }
        //    return result;
        //}
    }
}
