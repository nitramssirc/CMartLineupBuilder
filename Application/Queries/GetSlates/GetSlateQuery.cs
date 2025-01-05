using System.Linq;

using Application.Common.Repositories;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Queries.GetSlates
{
    public class GetSlateQuery : IRequestHandler<GetSlateRequest, List<GetSlateResponse>>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate, SlateID> _dbContext;

        #endregion

        #region Constructor

        public GetSlateQuery(IQueryRepository<Slate, SlateID> dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        public async Task<List<GetSlateResponse>> Handle(GetSlateRequest request, CancellationToken cancellationToken)
        {
            var slates = (await _dbContext.FindAsync(s => 
                s.DFSSite.ToString() == request.Site && 
                s.Sport.ToString() == request.Sport)).OrderByDescending(s => s.Date);

            return slates.Select(s => new GetSlateResponse(s.Id, $"{s.Sport} - {s.DFSSite} - {s.GameType} - {s.Name}")).ToList();
        }
    }
}
