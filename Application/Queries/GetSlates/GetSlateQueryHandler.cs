using Application.Persistence;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetSlates
{
    public class GetSlateQueryHandler : IRequestHandler<GetSlateRequest, List<GetSlateResponse>>
    {
        #region Dependencies

        //private readonly ISlateDBContext _dbContext;

        #endregion

        #region Constructor

        //public GetSlateQueryHandler(ISlateDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        #endregion

        public Task<List<GetSlateResponse>> Handle(GetSlateRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                new List<GetSlateResponse> {
                    new GetSlateResponse(Guid.NewGuid(), "Slate 1"),
                    new GetSlateResponse(Guid.NewGuid(), "Slate 2")
                }
            );
        }
    }
}
