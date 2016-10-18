using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DVDRenatal.Infrastructure.Repository
{
    public interface IRepository<TEntity>: IDisposable where TEntity : class {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);

        Task<object> AddAsync(TEntity entity);
        Task<object> AddAsync(IEnumerable<TEntity> entities);

        void Save(TEntity entity);
        void Save(IEnumerable<TEntity> entities);

        Task<object> SaveAsync(TEntity entity);
        Task<object> SaveAsync(IEnumerable<TEntity> entities);

        void Delete(object key);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);

        Task<object> DeleteAsync(object key);
        Task<object> DeleteAsync(TEntity entity);
        Task<object> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(object key);
        //        TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includePaths);
        TEntity Get(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        //        IQueryable<TEntity> All(params string[] includePaths);
        IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] includeProperties);
        //        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params string[] includePaths);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Paginated<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector);
        //        Paginated<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector,
        //            Expression<Func<TEntity, bool>> predicate, params string[] includePaths);
        Paginated<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector,
            Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}