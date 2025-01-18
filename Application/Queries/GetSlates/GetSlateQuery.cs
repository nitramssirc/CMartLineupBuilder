using System.Linq;

using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Common.Enums;

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
            var slates = await LookupSlates(request);

            return slates.
                OrderByDescending(s=>s.Date).
                Select(ConstructResponse).ToList();
        }

        private async Task<IEnumerable<Slate>> LookupSlates(GetSlateRequest request)
        {
            var dfsSite = Enum.Parse<DFSSite>(request.Site);
            var sport = Enum.Parse<Sport>(request.Sport);
            var specification = specificationFactory.Create<GetSlatesByDFSSiteAndSport>(dfsSite, sport);
            return await _dbContext.GetEntities(specification);
        }

        private GetSlateResponse ConstructResponse(Slate slate)
        {
            var slateName = $"{slate.Sport} - {slate.DFSSite} - {slate.GameType} - {slate.Name}";
            return new GetSlateResponse(slate.Id, slateName);
        }
    }
}
