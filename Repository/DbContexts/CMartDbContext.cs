using Application.Common.Repositories;
using Application.Queries.GetSlates;

using Common.Enums;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using Microsoft.EntityFrameworkCore;

namespace Repository.DbContexts
{
    public class CMartDbContext(DbContextOptions<CMartDbContext> options) : DbContext(options)
    {
        public DbSet<Slate> Slates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CMartDbContext).Assembly);
        }
    }
}
