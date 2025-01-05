using Application.Common.Repositories;

using Domain.Entities;
using Domain.ValueTypes;

namespace Repository.Repositories
{
    internal class PlayerRepository :
        ICommandRepository<Player, PlayerID>,
        IQueryRepository<Player, PlayerID>
    {
        private static readonly List<Player> _players = new List<Player>();

        Task ICommandRepository<Player, PlayerID>.AddAsync(Player model)
        {
            _players.Add(model);
            return Task.CompletedTask;
        }

        Task<IEnumerable<Player>> IQueryRepository<Player, PlayerID>.FindAsync(Func<Player, bool> predicate)
        {
            return Task.FromResult(_players.Where(predicate));
        }

        Task<IEnumerable<Player>> IQueryRepository<Player, PlayerID>.GetAllAsync()
        {
            return Task.FromResult(_players.AsEnumerable());
        }

        Task<Player?> IQueryRepository<Player, PlayerID>.GetByIdAsync(PlayerID id)
        {
            return Task.FromResult(_players.FirstOrDefault(p => p.Id == id));
        }

        Task<Player?> ICommandRepository<Player, PlayerID>.GetByIdAsync(PlayerID id)
        {
            return Task.FromResult(_players.FirstOrDefault(p => p.Id == id));
        }

        Task ICommandRepository<Player, PlayerID>.SaveAsync()
        {
            return Task.CompletedTask;
        }
    }
}
