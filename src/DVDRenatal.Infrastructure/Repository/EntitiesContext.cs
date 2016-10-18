using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace DVDRenatal.Infrastructure.Repository
{
    public abstract class EntitiesContext<T>: DbContext where T : DbContext {
        static EntitiesContext() {
            //Database.SetInitializer<T>(null);
        }

        protected EntitiesContext() { }
        protected EntitiesContext(DbCompiledModel model)
            : base(model) { }
        protected EntitiesContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }
        protected EntitiesContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }
        protected EntitiesContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model) { }
        protected EntitiesContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection) { }
        protected EntitiesContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //            IEnumerable<Type> typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //                .Where(type => !string.IsNullOrEmpty(type.Namespace))
            //                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
            //                    type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //
            //            foreach(var type in typesToRegister) {
            //                dynamic configurationInstance = Activator.CreateInstance(type);
            //                modelBuilder.Configurations.Add(configurationInstance);
            //            }

            base.OnModelCreating(modelBuilder);
        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class {
            return base.Set<TEntity>();
        }

        //        public void SetAsAdded<TEntity>(TEntity entity) where TEntity: class {
        //            DbEntityEntry dbEntityEntry = this.GetDbEntityEntrySafely(entity);
        //            dbEntityEntry.State = EntityState.Added;
        //        }
        //
        //        public void SetAsModified<TEntity>(TEntity entity) where TEntity: class {
        //            DbEntityEntry dbEntityEntry = this.GetDbEntityEntrySafely(entity);
        //            dbEntityEntry.State = EntityState.Modified;
        //        }
        //
        //        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity: class {
        //            DbEntityEntry dbEntityEntry = this.GetDbEntityEntrySafely(entity);
        //            dbEntityEntry.State = EntityState.Deleted;
        //        }
        //
        //        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity)
        //            where TEntity: class {
        //            DbEntityEntry<TEntity> dbEntityEntry = Entry<TEntity>(entity);
        //            if (dbEntityEntry.State == EntityState.Detached) {
        //                this.Set<TEntity>().Attach(entity);
        //            }
        //
        //            return dbEntityEntry;
        //        }
    }
}