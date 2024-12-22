using Domain.SlateAggregate.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddSalaries
{
    public class AddSalariesRequest:IRequest<AddSalariesResponse>
    {
        public SlateID SlateID { get; private set; }

        public List<SalaryData> Salaries { get; private set; }

        public AddSalariesRequest(SlateID slateID, 
            List<SalaryData> salaries)
        {
            SlateID = slateID;
            Salaries = salaries;
        }
    }
}
