using Domain.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetGamesForSlate
{
    public class GetGamesForSlateQuery:IRequest<GetGamesForSlateResponse>
    {
        public SlateID SlateID { get; private set; }
        public GetGamesForSlateQuery(SlateID slateID)
        {
            SlateID = slateID;
        }
    }
}
