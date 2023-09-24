using Domain;
using Domain.Projections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetExpertPicks
{
    public interface IGetExpertPicksQuery
    {
        Task<RotoGrindersProjection[]> Execute(Week week);
    }
}
