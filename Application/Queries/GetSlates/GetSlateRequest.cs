using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetSlates
{
    public class GetSlateRequest: IRequest<List<GetSlateResponse>>
    {
        public string Site { get; }
        public string Sport { get; }

        public GetSlateRequest(string site, string sport)
        {
            Site = site;
            Sport = sport;
        }

    }
}
