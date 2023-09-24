using CsvHelper;

using Domain;
using Domain.Projections;

using Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tewr.Blazor.FileReader;

namespace Application.Commands.ImportProjection
{
    public class ImportProjectionCommand : IImportProjectionCommand
    {
        #region Dependencies

        private readonly IProjectionRepo _projectionRepo;

        #endregion

        #region Constructor

        public ImportProjectionCommand(IProjectionRepo projectionRepo)
        {
            _projectionRepo = projectionRepo;
        }

        #endregion

        public async Task<ImportedProjections> Execute(Week week, IFileReference importFile)
        {
            RotoGrindersProjection[] rotoGrindersProjections;
            using var memoryStream = await importFile.CreateMemoryStreamAsync();
            {
                rotoGrindersProjections = await LoadCSV(memoryStream);
            }

            var importedProjections = new ImportedProjections
            {
                ImportDateTime = DateTime.Now,
                RotoGrindersProjections = rotoGrindersProjections.Where(p=>p.fpts.HasValue).ToArray()
            };

            await _projectionRepo.SaveProjectionsForWeek(week.ID, importedProjections);
            return importedProjections;

        }

        public async Task<RotoGrindersProjection[]> LoadCSV(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            RotoGrindersProjection[] records = null;
            await Task.Run(() => records = csv.GetRecords<RotoGrindersProjection>().ToArray());
            return records;
        }
    }
}
