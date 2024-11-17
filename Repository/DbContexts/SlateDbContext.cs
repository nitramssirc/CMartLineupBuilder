using Application.Common.Repositories;
using Application.Queries.GetSlates;

using Common.Enums;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using Microsoft.EntityFrameworkCore;

namespace Repository.DbContexts
{
    public class SlateDbContext(DbContextOptions<SlateDbContext> options) : DbContext(options),
            ICommandRepository<Slate, SlateID>,
            IQueryRepository<Slate, SlateID>
    {
        public DbSet<Slate> Slates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SlateDbContext).Assembly);
        }

        Task ICommandRepository<Slate, SlateID>.AddAsync(Slate model)
        {
            Slates.Add(model);
            return Task.CompletedTask;
        }

        Task<Slate?> ICommandRepository<Slate, SlateID>.GetByIdAsync(SlateID id)
        {
            throw new NotImplementedException();
        }

        async Task ICommandRepository<Slate, SlateID>.SaveAsync()
        {
            await SaveChangesAsync();
        }

        public Task<Slate?> GetByIdAsync(SlateID id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Slate>> GetAllAsync()
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
    }
}
