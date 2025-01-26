using Domain.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetSlateById
{
    public class GetSlateByIdQuery:IRequest<GetSlateByIdResponse>
    {
        public GetSlateByIdQuery(SlateID slateId)
        {
            SlateId = slateId;
        }
        public SlateID SlateId { get; private set; }
    }
}
