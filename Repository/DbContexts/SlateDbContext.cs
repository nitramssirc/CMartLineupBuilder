using Application.Common.Repositories;
using Application.Queries.GetSlates;

using Common.Enums;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using Microsoft.EntityFrameworkCore;

namespace Repository.DbContexts
{
    public class SlateDbContext : DbContext,
        ICommandRepository<Slate, SlateID>,
        IQueryRepository<Slate, SlateID>
    {
        public Task AddAsync(Slate model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Slate>> FindAsync(Func<Slate, bool> predicate)
        {
            return Task.FromResult<IEnumerable<Slate>>([
                    Slate.Create(DateTime.Now.AddDays(-7), Sport.NFL, GameType.Cash, DFSSite.DraftKings, "Week 1"),
                    Slate.Create(DateTime.Now, Sport.NFL, GameType.Cash, DFSSite.DraftKings, "Week 2")
                ]);
        }

        public Task<IEnumerable<Slate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }         

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        Task<Slate?> ICommandRepository<Slate, SlateID>.GetByIdAsync(SlateID id)
        {
            throw new NotImplementedException();
        }

        Task<Slate?> IQueryRepository<Slate, SlateID>.GetByIdAsync(SlateID id)
        {
            throw new NotImplementedException();
        }
    }
}
