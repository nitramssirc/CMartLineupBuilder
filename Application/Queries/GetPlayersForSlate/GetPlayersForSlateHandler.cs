using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayersForSlateHandler :
        IRequestHandler<GetPlayersForSlateQuery, GetPlayersForSlateResponse>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate> _slateRepository;
        private readonly ISpecificationFactory specificationFactory;

        #endregion

        #region Constructor

        public GetPlayersForSlateHandler(
            IQueryRepository<Slate> slateRepository,
            ISpecificationFactory specificationFactory)
        {
            _slateRepository = slateRepository;
            this.specificationFactory = specificationFactory;
        }

        #endregion

        #region IRequestHandler Implementation

        public async Task<GetPlayersForSlateResponse> Handle(
            GetPlayersForSlateQuery request, CancellationToken cancellationToken)
        {
            var specification = specificationFactory.Create<GetSlateByIDWithSalariesAndProjectionsSpec>(request.SlateID);

            var slate = await _slateRepository.GetEntity(specification);
            return new GetPlayersForSlateResponse(slate);
        }

        #endregion

    }
}
