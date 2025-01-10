using Application.Common.Repositories;

using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayerForSlateQuery :
        IRequestHandler<GetPlayerForSlateRequest, List<GetPlayerForSlateResponse>>
    {
        #region Dependencies

        private readonly IQueryRepository<Slate, SlateID> _slateRepository;

        #endregion

        #region Constructor

        public GetPlayerForSlateQuery(
            IQueryRepository<Slate, SlateID> slateRepository)
        {
            _slateRepository = slateRepository;
        }

        #endregion

        #region IRequestHandler Implementation

        public async Task<List<GetPlayerForSlateResponse>> Handle(
            GetPlayerForSlateRequest request, CancellationToken cancellationToken)
        {
            var slate = await _slateRepository.GetByIdAsync(request.SlateID);
            if (slate == null)
            {
                throw new Exception("Slate not found");
            }


            return slate.Salaries.OrderByDescending(s=>s.SalaryAmount).Select(salary => ConstructResponse(salary, slate)).ToList();            
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
