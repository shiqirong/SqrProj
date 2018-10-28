using Sqr.Common.Paging;
using Sqr.DC.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sqr.DC.EF
{
    public interface IRepository<T> where T : BaseMo
    {

        /// <summary>
        /// 判断是否存在 by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(int id);

        /// <summary>
        /// 判断是否存在 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<T, bool>> where);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        List<T> GetAll(params Expression<Func<T, object>>[] paths);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        List<T> GetAll<S>(Expression<Func<T, S>> orderBy, bool IsAsc);

        /// <summary>
        /// 获取实体 by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(long id);

        /// <summary>
        /// 获取一个实体 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T SingleOrDefault(Expression<Func<T, bool>> where);

        /// <summary>
        /// 获取多个实体 by some where
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] paths);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> where);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        int Add(IEnumerable<T> entities/*, bool isUseBulkInsert = false*/);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int ExecuteUpdata(string sql, params object[] paramItem);

        int Update(IEnumerable<T> entitys);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(T entity);

        /// <summary>
        /// 批量删除实体 by some where
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Deletes(Expression<Func<T, bool>> where);

        int Remove(T entity);

        List<TObj> Query<TObj>(string sql, params object[] parameters);


        T FirstOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths);

        T FirstOrDefault<S>(Expression<Func<T, bool>> filter, Expression<Func<T, S>> orderBy, params Expression<Func<T, object>>[] paths);


        T FirstOrDefault(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order, params Expression<Func<T, object>>[] paths);


        T SingleOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths);

        T SingleOrDefault(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order, params Expression<Func<T, object>>[] paths);

        List<T> Query(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] paths);

        List<T> Query(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> order,

        int top = int.MaxValue, params Expression<Func<T, object>>[] paths);

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
        PagingOutput<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> keySelector = null, bool isAsc = true);

    }
}
