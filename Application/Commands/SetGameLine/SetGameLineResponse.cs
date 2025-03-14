using Application.Common.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.SetGameLine
{
    public class SetGameLineResponse : CommandResultResponse
    {
        public SetGameLineResponse()
        {
        }
        public SetGameLineResponse(string error) : base(error)
        {
        }
    }
}
