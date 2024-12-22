using Application.Common.Repositories;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class PlayerRepository :
        ICommandRepository<Player, PlayerID>,
        IQueryRepository<Player, PlayerID>
    {
        Task ICommandRepository<Player, PlayerID>.AddAsync(Player model)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Player>> IQueryRepository<Player, PlayerID>.FindAsync(Func<Player, bool> predicate)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Player>> IQueryRepository<Player, PlayerID>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Player?> IQueryRepository<Player, PlayerID>.GetByIdAsync(PlayerID id)
        {
            throw new NotImplementedException();
        }

        Task<Player?> ICommandRepository<Player, PlayerID>.GetByIdAsync(PlayerID id)
        {
            throw new NotImplementedException();
        }

        Task ICommandRepository<Player, PlayerID>.SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
