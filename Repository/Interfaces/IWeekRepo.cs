using Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IWeekRepo
    {
        Task AddWeek(Week week);
        Task<Week> LoadWeek(int weekID);
        Task<Week[]> LoadWeeks();
    }
}
