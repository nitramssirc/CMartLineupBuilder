using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Domain.Entities;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetGamesForSlate
{
    public class GetGamesForSlateHandler : IRequestHandler<GetGamesForSlateQuery, GetGamesForSlateResponse>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate> _slateRepository;
        private readonly ISpecificationFactory specificationFactory;

        #endregion

        #region Constructor

        public GetGamesForSlateHandler(
            IQueryRepository<Slate> slateRepository,
            ISpecificationFactory specificationFactory)
        {
            _slateRepository = slateRepository;
            this.specificationFactory = specificationFactory;
        }

        #endregion

        #region IRequestHandler Implementation

        public async Task<GetGamesForSlateResponse> Handle(GetGamesForSlateQuery request, CancellationToken cancellationToken)
        {
            var specification = specificationFactory.Create<GetSlateByIDWithGamesSpec>(request.SlateID);

            var slate = await _slateRepository.GetEntity(specification);

            return new GetGamesForSlateResponse(slate);
        }

        #endregion
    }
}
