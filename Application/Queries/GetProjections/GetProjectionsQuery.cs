using Domain;
using Domain.Projections;

using Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetProjections
{
    public class GetProjectionsQuery : IGetProjectionsQuery
    {
        private readonly IProjectionRepo _projectionRepo;

        public GetProjectionsQuery(IProjectionRepo projectionRepo)
        {
            _projectionRepo = projectionRepo;
        }

        public async Task<ImportedProjections> Execute(Week week)
        {
            return await _projectionRepo.LoadProjectionsForWeek(week.ID);
        }
    }
}
