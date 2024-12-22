using Application.Common.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddSalaries
{
    public class AddSalariesResponse : CommandResultResponse
    {
        public AddSalariesResponse()
        {
        }

        public AddSalariesResponse(string error) : base(error)
        {
        }
    }
}
