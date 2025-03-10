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
    public class GetPlayersForSlateQuery: IRequest<GetPlayersForSlateResponse>
    {
        public SlateID SlateID { get; private set; }

        public GetPlayersForSlateQuery(SlateID slateID)
        {
            SlateID = slateID;
        }
    }
}
