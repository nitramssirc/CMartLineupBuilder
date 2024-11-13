using Domain.Common.Models;
using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface ICommandRepository<TModel, TKey> where TModel : AggregateRoot<TKey> where TKey : EntityID
    {

    }
}
