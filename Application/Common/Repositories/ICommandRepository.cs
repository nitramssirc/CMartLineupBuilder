using Domain.Common.Models;

namespace Application.Common.Repositories
{
    /// <summary>
    /// Repository for command operations
    /// </summary>
    /// <typeparam name="TModel">Type of aggregate root the repository manages</typeparam>
    /// <typeparam name="TKey">Type of ID for the aggregate</typeparam>
    public interface ICommandRepository<TModel, TKey> where TModel : IAggregateRoot
    {
        /// <summary>
        /// Adds a new model to the repository`
        /// </summary>
        /// <param name="model">Model to add</param>
        Task AddAsync(TModel model);

        /// <summary>
        /// Looks up a model by ID. So that it can be updated.
        /// </summary>
        /// <param name="id">ID of the model being looked up</param>
        /// <returns>The model if found, otherwise false</returns>
        Task<TModel?> GetByIdAsync(TKey id);

        /// <summary>
        /// Pushes changes made to the repository to the underlying data store
        /// </summary>
        Task SaveAsync();
    }
}
