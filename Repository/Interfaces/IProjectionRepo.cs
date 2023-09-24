using Blazored.LocalStorage;

using Domain.Projections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProjectionRepo
    {
        Task SaveProjectionsForWeek(int weekID, ImportedProjections importedProjections);

        Task<ImportedProjections> LoadProjectionsForWeek(int weekID);
    }
}
