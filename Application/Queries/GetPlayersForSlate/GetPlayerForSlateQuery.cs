using Application.Common.Repositories;

using Common.Enums;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using MediatR;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayerForSlateQuery : 
        IRequestHandler<GetPlayerForSlateRequest, List<GetPlayerForSlateResponse>>
    {
        #region Dependencies

        private readonly IQueryRepository<Player, PlayerID> _queryRepository;

        #endregion

        #region Constructor

        public GetPlayerForSlateQuery(IQueryRepository<Player, PlayerID> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        #endregion

        #region IRequestHandler Implementation

        public async Task<List<GetPlayerForSlateResponse>> Handle(
            GetPlayerForSlateRequest request, CancellationToken cancellationToken)
        {
            var players = await _queryRepository.FindAsync(p => 
                p.Salaries.Any(s=>s.SlateID == request.SlateID) ||
                p.Projections.Any(s=>s.SlateID == request.SlateID));

            return players.Select(p => ConstructResponse(p)).ToList();
        }

        private GetPlayerForSlateResponse ConstructResponse(Player p)
        {
            var name = $"{p.FirstName} {p.LastName}";
            var salary = p.Salaries.FirstOrDefault();
            var projection = p.Projections.FirstOrDefault();
            return new GetPlayerForSlateResponse(
                p.Id,
                name,
                salary?.Team ?? Team.UNKNOWN,
                salary?.Positions.ToArray() ?? Array.Empty<PlayerPosition>(),
                salary?.SalaryAmount ?? 0,
                projection?.Data.ToArray() ?? Array.Empty<ProjectionData>()
            );
        }

        #endregion

    }
}
