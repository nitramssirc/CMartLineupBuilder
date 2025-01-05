using Common.Enums;

using Domain.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayerForSlateRequest: IRequest<List<GetPlayerForSlateResponse>>
    {
        public SlateID SlateID { get; private set; }

        public GetPlayerForSlateRequest(SlateID slateID)
        {
            SlateID = slateID;
        }
    }
}
