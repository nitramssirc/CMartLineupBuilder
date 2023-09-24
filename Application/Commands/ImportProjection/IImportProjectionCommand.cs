using Domain;
using Domain.Projections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tewr.Blazor.FileReader;

namespace Application.Commands.ImportProjection
{
    public interface IImportProjectionCommand
    {
        Task<ImportedProjections> Execute(Week week, IFileReference importFile);
    }
}
