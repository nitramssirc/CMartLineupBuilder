using Application.Common.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections
{
    internal class AddProjectionsResponse:CommandResultResponse
    {
        public AddProjectionsResponse() : base()
        {
        }
        public AddProjectionsResponse(string error) : base(error)
        {
        }
    }
}
