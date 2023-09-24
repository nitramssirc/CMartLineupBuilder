using Blazored.LocalStorage;

using Domain;

using Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LocalStorageImpl
{
    public class WeekRepo : IWeekRepo
    {
        #region Dependecnies

        private readonly ILocalStorageService _localStorageService;

        #endregion

        #region Fields  

        private const string _weeksKey = "weeks";

        #endregion

        #region Constructor

        public WeekRepo(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        #endregion

        #region IWeekRepo IMplementation

        public async Task AddWeek(Week week)
        {
            var allWeeks = (await LoadWeeks()).ToList();
            SetWeekID(week, allWeeks);
            allWeeks.Add(week);
            await _localStorageService.SetItemAsync(_weeksKey, allWeeks);
        }

        public async Task<Week> LoadWeek(int weekID)
        {
            var allWeeks = await LoadWeeks();
            return allWeeks.FirstOrDefault(w => w.ID == weekID);
        }

        public async Task<Week[]> LoadWeeks()
        {
            var weeks = await _localStorageService.GetItemAsync<List<Week>>(_weeksKey);
            if (weeks == null)
            {
                weeks = new List<Week>();
            }
            return weeks.ToArray();
        }

        #endregion

        #region Private Methods

        private void SetWeekID(Week week, List<Week> allWeeks)
        {
            if (allWeeks.Count == 0)
            {
                week.ID = 1;
            }
            else
            {
                week.ID = allWeeks.Max(w => w.ID) + 1;
            }
        }

        #endregion
    }
}
