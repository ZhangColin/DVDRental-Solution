using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DVDRenatal.Infrastructure.Repository
{
    public class EfRepository<TEntity>: IRepository<TEntity> where TEntity : class {
        private readonly DbContext _context;

        public EfRepository(DbContext context) {
            AssertionConcern.NotNull(context, "");

            _context = context;
        }

        public void Dispose() {
            if (_context == null) {
                return;
            }
            _context.Dispose();
        }

        public void Add(TEntity entity) {
            AssertionConcern.NotNull(entity, "");

            try {
                _context.Set<TEntity>().Add(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }

        }

        public void Add(IEnumerable<TEntity> entities) {
            AssertionConcern.NotNull(entities, "");

            try {
                foreach (TEntity entity in entities) {
                    _context.Set<TEntity>().Add(entity);
                }

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public async Task<object> AddAsync(TEntity entity) {
            AssertionConcern.NotNull(entity, "");

            _context.Set<TEntity>().Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<object> AddAsync(IEnumerable<TEntity> entities) {
            AssertionConcern.NotNull(entities, "");

            foreach (TEntity entity in entities) {
                _context.Set<TEntity>().Add(entity);
            }

            await _context.SaveChangesAsync();

            return entities;
        }

        public void Save(TEntity entity) {
            try {
                AssertionConcern.NotNull(entity, "");

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Save(IEnumerable<TEntity> entities) {
            try {
                AssertionConcern.NotNull(entities, "");

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public async Task<object> SaveAsync(TEntity entity) {
            AssertionConcern.NotNull(entity, "");

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<object> SaveAsync(IEnumerable<TEntity> entities) {
            AssertionConcern.NotNull(entities, "");

            await _context.SaveChangesAsync();

            return entities;
        }

        public void Delete(object key) {
            AssertionConcern.NotNull(key, "");

            Delete(Get(key));
        }

        public void Delete(TEntity entity) {
            AssertionConcern.NotNull(entity, "");

            try {
                _context.Set<TEntity>().Remove(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }

        }

        public void Delete(Expression<Func<TEntity, bool>> predicate) {
            AssertionConcern.NotNull(predicate, "");

            try {
                foreach (TEntity entity in Query(predicate)) {
                    _context.Set<TEntity>().Remove(entity);
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public async Task<object> DeleteAsync(object key) {
            AssertionConcern.NotNull(key, "");

            await DeleteAsync(Get(key));

            return null;
        }

        public async Task<object> DeleteAsync(TEntity entity) {
            AssertionConcern.NotNull(entity, "");

            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<object> DeleteAsync(Expression<Func<TEntity, bool>> predicate) {
            AssertionConcern.NotNull(predicate, "");

            foreach (TEntity entity in Query(predicate)) {
                _context.Set<TEntity>().Remove(entity);
            }
            await _context.SaveChangesAsync();

            return null;
        }

        public TEntity Get(object key) {
            AssertionConcern.NotNull(key, "");

            return _context.Set<TEntity>().Find(key);
        }

        //        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includePaths)  {
        //            AssertionConcern.NotNull(predicate, "");
        //
        //            return GetSetWithIncludePaths(includePaths).SingleOrDefault(predicate);
        //        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) {
            AssertionConcern.NotNull(predicate, "");

            return GetSetWithIncludeProperties(includeProperties).SingleOrDefault(predicate);
        }

        //        public IQueryable<TEntity> All(params string[] includePaths)  {
        //            return Query(null, includePaths);
        //        }

        public IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] includeProperties) {
            return Query(null, includeProperties);
        }

        //        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params string[] includePaths)  {
        //            var query = GetSetWithIncludePaths(includePaths);
        //            if (predicate!=null) {
        //                return query.Where(predicate);
        //            }
        //            return query;
        //        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) {
            var query = GetSetWithIncludeProperties(includeProperties);
            if (predicate != null) {
                return query.Where(predicate);
            }
            return query;
        }

        public Paginated<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector) {
            return Paginate(pageIndex, pageSize, keySelector, null);
        }

        //        public Paginated<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector, Expression<Func<TEntity, bool>> predicate,
        //            params string[] includePaths) {
        //            throw new NotImplementedException();
        //        }

        public Paginated<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector, Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties) {
            var query = Query(predicate, includeProperties);
            query = query.OrderBy(keySelector);

            return query.ToPaginated(pageIndex, pageSize);
        }

        //        private IQueryable<TEntity> GetSetWithIncludePaths(IEnumerable<string> includePaths) {
        //            IQueryable<TEntity> query = _context.Set<TEntity>();
        //
        //            foreach (string path in includePaths ?? Enumerable.Empty<string>()) {
        //                query = query.Include(path);
        //            }
        //
        //            return query;
        //        }

        private IQueryable<TEntity> GetSetWithIncludeProperties(Expression<Func<TEntity, object>>[] includeProperties) {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> expression in includeProperties ?? Enumerable.Empty<Expression<Func<TEntity, object>>>()) {
                query = query.Include(expression);
            }

            return query;
        }
    }
}