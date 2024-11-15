﻿using Application.Common.Repositories;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using MediatR;

namespace Application.Queries.GetSlates
{
    public class GetSlateQueryHandler : IRequestHandler<GetSlateRequest, List<GetSlateResponse>>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate, SlateID> _dbContext;

        #endregion

        #region Constructor

        public GetSlateQueryHandler(IQueryRepository<Slate, SlateID> dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        public async Task<List<GetSlateResponse>> Handle(GetSlateRequest request, CancellationToken cancellationToken)
        {
            var slates = await _dbContext.FindAsync(s => 
                s.DFSSite.ToString() == request.Site && 
                s.Sport.ToString() == request.Sport);

            return slates.Select(s => new GetSlateResponse(s.Id, $"{s.Sport} - {s.DFSSite} - {s.GameType} - {s.Name}")).ToList();
        }
    }
}
