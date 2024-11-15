using Domain.Common.Models;

namespace Application.Common.Repositories
{
    public interface ICommandRepository<TModel, TKey> where TModel : IAggregateRoot
    {

    }
}
