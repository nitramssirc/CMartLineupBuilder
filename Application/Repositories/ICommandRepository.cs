using Application.Specifications;

using Domain.Common.Entities;

namespace Application.Repositories
{
    /// <summary>
    /// Repository for command operations
    /// </summary>
    /// <typeparam name="TEntity">Type of aggregate root the repository manages</typeparam>
    /// <typeparam name="TKey">Type of ID for the aggregate</typeparam>
    public interface ICommandRepository<TEntity, TKey> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// Adds a new model to the repository`
        /// </summary>
        /// <param name="model">Model to add</param>
        Task AddAsync(TEntity model);

        /// <summary>
        /// Gets an entity that matches the given specification
        /// </summary>
        Task<TEntity?> GetEntity(ISpecification<TEntity> specification);

        /// <summary>
        /// Pushes changes made to the repository to the underlying data store
        /// </summary>
        Task SaveAsync();
    }
}
