using Application.Specifications;

using Domain.Common.Entities;
using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    /// <summary>
    /// Defines a repository for looking up entities without tracking
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TId">Type of ID used by the entity</typeparam>
    public interface IQueryRepository<TEntity, TId> where TEntity : Entity<TId> where TId : EntityID
    {
        /// <summary>
        /// Gets an entity that matches the given specification
        /// </summary>
        Task<TEntity?> GetEntity(ISpecification<TEntity> specification);

        /// <summary>
        /// Gets all entities that match the given specification
        /// </summary>
        Task<IEnumerable<TEntity>> GetEntities(ISpecification<TEntity> specification);

    }
}
