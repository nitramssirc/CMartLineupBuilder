using Application.Common.Repositories;

using Common.Enums;

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
            var players = new List<Player>()
            {
                Player.Create("Emmitt", "Smith", Sport.NFL),
                Player.Create("Jerry", "Rice", Sport.NFL),
                Player.Create("Joe", "Montana", Sport.NFL),
                Player.Create("Taysom", "Hill", Sport.NFL),
            };

            players[0].AddSalary(Salary.Create(new SlateID(), players[0].Id, new[] { PlayerPosition.RB }, Team.DAL, 9000, "123"));
            players[1].AddSalary(Salary.Create(new SlateID(), players[0].Id, new[] { PlayerPosition.WR}, Team.SF, 9500, "456"));
            players[2].AddSalary(Salary.Create(new SlateID(), players[0].Id, new[] { PlayerPosition.QB }, Team.SF, 8000, "765"));
            players[3].AddSalary(Salary.Create(new SlateID(), players[0].Id, new[] { PlayerPosition.TE, PlayerPosition.QB }, Team.NO, 6000, "51651"));

            return Task.FromResult(players as IEnumerable<Player>);
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
