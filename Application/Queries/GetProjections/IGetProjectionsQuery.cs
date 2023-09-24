using Domain;
using Domain.Projections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetProjections
{
    public interface IGetProjectionsQuery
    {
        Task<ImportedProjections> Execute(Week week);
    }
}
