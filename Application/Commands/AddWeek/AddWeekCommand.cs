using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddWeek
{
    public class AddWeekCommand:IAddWeekCommand
    {
        private readonly IWeekRepo _weekRepo;

        public AddWeekCommand(IWeekRepo weekRepo)
        {
            _weekRepo = weekRepo;
        }

        public async Task Execute(int weekNumber, DateTime date)
        {
            var week = new Week(weekNumber, date);
            await _weekRepo.AddWeek(week);    
        }
    }
}
