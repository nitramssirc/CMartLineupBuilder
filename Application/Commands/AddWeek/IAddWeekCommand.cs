using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddWeek
{
    public interface IAddWeekCommand
    {
        Task Execute(int weekNumber, DateTime date);
    }
}
