using System;

namespace DVDRenatal.Infrastructure.Domain
{
    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity<TId> where TId : IComparable {
        /// <summary>
        /// 实体标识
        /// </summary>
        TId Id { get; set; }
    }
}