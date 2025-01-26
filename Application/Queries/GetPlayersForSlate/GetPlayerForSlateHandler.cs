using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayerForSlateHandler :
        IRequestHandler<GetPlayersForSlateQuery, List<GetPlayerForSlateResponse>>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate> _slateRepository;
        private readonly ISpecificationFactory specificationFactory;

        #endregion

        #region Constructor

        public GetPlayerForSlateHandler(
            IQueryRepository<Slate> slateRepository,
            ISpecificationFactory specificationFactory)
        {
            _slateRepository = slateRepository;
            this.specificationFactory = specificationFactory;
        }

        #endregion

        #region IRequestHandler Implementation

        public async Task<List<GetPlayerForSlateResponse>> Handle(
            GetPlayersForSlateQuery request, CancellationToken cancellationToken)
        {
            var specification = specificationFactory.Create<GetSlateByIDWithSalariesSpec>(request.SlateID);

            var slate = await _slateRepository.GetEntity(specification);
            return slate == null
                ? throw new Exception("Slate not found")
                : slate.Salaries.OrderByDescending(s=>s.SalaryAmount).Select(salary => ConstructResponse(salary, slate)).ToList();
        }

        private GetPlayerForSlateResponse ConstructResponse(Salary salary, Slate slate)
        {
            var name = salary.PlayerName;
            var slateID = slate.Id;            
            return new GetPlayerForSlateResponse(
                name,
                salary?.Team ?? Team.UNKNOWN,
                salary?.Team.GetName(slate.Sport) ?? string.Empty,
                salary?.Positions.ToArray() ?? [],
                salary?.SalaryAmount ?? 0,
                []
            );
        }

        #endregion

    }
}
