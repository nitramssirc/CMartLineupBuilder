using Domain.Common.Models;
using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    /// <summary>
    /// Defines a repository for looking up entities 
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TId">Type of ID used by the entity</typeparam>
    public interface IQueryRepository<TEntity, TId> where TEntity : Entity<TId> where TId : EntityID
    {
        /// <summary>
        /// Looks up an entity by ID
        /// </summary>
        /// <param name="id">id to look up</param>
        /// <returns>Entity with the given id</returns>
        Task<TEntity?> GetByIdAsync(TId id);

        /// <summary>
        /// Gets all entities in the repository
        /// </summary>
        /// <returns>Enumerable list of enitities</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Finds entities that match a given predicate
        /// </summary>
        /// <param name="predicate">look up filter</param>
        /// <returns>Enumerable list of entitites that match the predicate</returns>
        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);

    }
}
