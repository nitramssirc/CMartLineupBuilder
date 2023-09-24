using Blazored.LocalStorage;

using Domain.Projections;

using Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LocalStorageImpl
{
    public class ProjectionRepo : IProjectionRepo
    {
        #region Dependecnies

        private readonly ILocalStorageService _localStorageService;

        #endregion

        #region Constructor

        public ProjectionRepo(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        #endregion

        #region Fields  

        private const string _localStorageKeyFormat = "ImportedProj_Week{0}";

        #endregion

        public async Task<ImportedProjections> LoadProjectionsForWeek(int weekID)
        {
            return await _localStorageService.GetItemAsync<ImportedProjections>
                (string.Format(_localStorageKeyFormat, weekID));
        }

        public async Task SaveProjectionsForWeek(int weekID, ImportedProjections importedProjections)
        {
            await _localStorageService.SetItemAsync
                (string.Format(_localStorageKeyFormat, weekID), importedProjections);
        }
    }
}
