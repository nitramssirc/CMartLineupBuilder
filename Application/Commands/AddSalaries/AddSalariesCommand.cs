using Domain.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddSalaries
{
    public class AddSalariesCommand:IRequest<AddSalariesResponse>
    {
        public SlateID SlateID { get; private set; }

        public List<SalaryData> Salaries { get; private set; }

        public AddSalariesCommand(SlateID slateID, 
            List<SalaryData> salaries)
        {
            SlateID = slateID;
            Salaries = salaries;
        }
    }
}
