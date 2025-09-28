using Domain.Aggregates;

using Repository.DbContexts;

namespace Repository.Repositories
{
    public class PlayerRepository(CMartDbContext context) :
        BaseRepository<Player>(context)
    {

    }
}
