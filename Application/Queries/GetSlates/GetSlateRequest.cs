using MediatR;

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
