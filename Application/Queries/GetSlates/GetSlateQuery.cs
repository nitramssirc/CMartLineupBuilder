using System.Linq;

using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Queries.GetSlates
{
    public class GetSlateQuery : IRequestHandler<GetSlateRequest, List<GetSlateResponse>>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate, SlateID> _dbContext;
        private readonly ISpecificationFactory specificationFactory;

        #endregion

        #region Constructor

        public GetSlateQuery(IQueryRepository<Slate, SlateID> dbContext,
            ISpecificationFactory specificationFactory)
        {
            _dbContext = dbContext;
            this.specificationFactory = specificationFactory;
        }

        #endregion

        public async Task<List<GetSlateResponse>> Handle(GetSlateRequest request, CancellationToken cancellationToken)
        {
            var specification = specificationFactory.Create<GetSlatesByDFSSiteAndSport>(request.Site, request.Sport);
            var slates = (await _dbContext.GetEntities(specification)).OrderByDescending(s => s.Date);

            return slates.Select(s => new GetSlateResponse(s.Id, $"{s.Sport} - {s.DFSSite} - {s.GameType} - {s.Name}")).ToList();
        }
    }
}
