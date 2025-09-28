using Domain.Aggregates;

using Microsoft.EntityFrameworkCore;

namespace Repository.DbContexts
{
    public class CMartDbContext(DbContextOptions<CMartDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CMartDbContext).Assembly);
        }
    }
}
