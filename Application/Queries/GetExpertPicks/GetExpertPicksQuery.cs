using Domain;
using Domain.Projections;

using Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetExpertPicks
{
    public class GetExpertPicksQuery : IGetExpertPicksQuery
    {
        private readonly IProjectionRepo _projectionRepo;

        public GetExpertPicksQuery(IProjectionRepo projectionRepo)
        {
            _projectionRepo = projectionRepo;
        }

        public async Task<RotoGrindersProjection[]> Execute(Week week)
        {
            var projections = await _projectionRepo.LoadProjectionsForWeek(week.ID);
            return projections.RotoGrindersProjections.Where(p => p.min_exposure > 0).ToArray();
        }
    }
}
