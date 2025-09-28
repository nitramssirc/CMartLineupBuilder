using Domain.Aggregates;

using Repository.DbContexts;

namespace Repository.Repositories
{
    public class GameRepository(CMartDbContext context) :
        BaseRepository<Game>(context)
    {

    }
}
