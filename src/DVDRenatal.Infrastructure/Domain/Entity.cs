using System;
using System.Collections.Generic;

namespace DVDRenatal.Infrastructure.Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="TId">实体标识（主键）的类型</typeparam>
    public abstract class Entity<TId>: IEntity<TId> where TId : IComparable {
        private object _id;

        /// <summary>
        /// 实体标识
        /// </summary>
        public virtual TId Id {
            get {
                if (_id == null && typeof(TId) == typeof(Guid)) {
                    _id = Guid.NewGuid();
                }

                return _id == null ? default(TId) : (TId)_id;
            }

            set {
                _id = value;
            }
            //            protected set { _id = value; }
        }

        /// <summary>
        /// 检查对象是否是瞬时的
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsTransient(IEntity<TId> obj) {
            return obj != null && Equals(obj.Id, default(TId));
        }

        private Type GetUnproxiedType() {
            return GetType();
        }

        public bool Equals(Entity<TId> other) {
            // 如果比较实体是Null，则不相等
            if (other == null)
                return false;

            // 如果与比较实体是同一引用，则相等
            if (ReferenceEquals(this, other))
                return true;

            // 两个实体都不是瞬时的
            // 且两个实体的Id相等
            // 且本实体能从比较实体分配或比较实体能从本实体分配
            // 则相等
            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id)) {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            // 以上条件皆不成立，不相等
            return false;
        }

        public override bool Equals(object entity) {
            return Equals(entity as Entity<TId>);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right) {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right) {
            return !(left == right);
        }

        public override int GetHashCode() {
            if (Equals(Id, default(TId))) {
                return base.GetHashCode();
            }
            return EqualityComparer<TId>.Default.GetHashCode(this.Id);
        }
    }

    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class Entity: Entity<long> { }
}