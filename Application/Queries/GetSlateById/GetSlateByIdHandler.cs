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

namespace Application.Queries.GetSlateById
{
    public class GetSlateByIdHandler : IRequestHandler<GetSlateByIdQuery, GetSlateByIdResponse>
    {
        private readonly ISpecificationFactory _specificationFactory;
        private readonly IQueryRepository<Slate> _slateRepository;

        public GetSlateByIdHandler(
            ISpecificationFactory specificationFactory, 
            IQueryRepository<Slate> slateRepository)
        {
            _specificationFactory = specificationFactory;
            _slateRepository = slateRepository;
        }


        public async Task<GetSlateByIdResponse> Handle(GetSlateByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = _specificationFactory.Create<GetSlateByIdSpec>(request.SlateId);
            var slate = await _slateRepository.GetEntity(specification);
            if (slate == null)
            {
                throw new Exception("Slate not found");
            }

            return new GetSlateByIdResponse(slate);
        }
    }
}
