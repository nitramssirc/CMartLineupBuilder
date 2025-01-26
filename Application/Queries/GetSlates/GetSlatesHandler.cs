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
    public class GetSlatesHandler : IRequestHandler<GetSlateRequest, List<GetSlatesResponse>>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate> _dbContext;
        private readonly ISpecificationFactory specificationFactory;

        #endregion

        #region Constructor

        public GetSlatesHandler(IQueryRepository<Slate> dbContext,
            ISpecificationFactory specificationFactory)
        {
            _dbContext = dbContext;
            this.specificationFactory = specificationFactory;
        }

        #endregion

        public async Task<List<GetSlatesResponse>> Handle(GetSlateRequest request, CancellationToken cancellationToken)
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
            var specification = specificationFactory.Create<GetSlatesByDFSSiteAndSportSpec>(dfsSite, sport);
            return await _dbContext.GetEntities(specification);
        }

        private GetSlatesResponse ConstructResponse(Slate slate)
        {
            var slateName = $"{slate.Sport} - {slate.DFSSite} - {slate.GameType} - {slate.Name}";
            return new GetSlatesResponse(slate.Id, slateName);
        }
    }
}
