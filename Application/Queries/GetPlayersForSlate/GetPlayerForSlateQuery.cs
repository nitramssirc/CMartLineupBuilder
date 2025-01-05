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

        private readonly IQueryRepository<Player, PlayerID> _playerRepository;
        private readonly IQueryRepository<Slate, SlateID> _slateRepository;

        #endregion

        #region Constructor

        public GetPlayerForSlateQuery(
            IQueryRepository<Player, PlayerID> playerRepository,
            IQueryRepository<Slate, SlateID> slateRepository)
        {
            _playerRepository = playerRepository;
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
            var players = await _playerRepository.FindAsync(p =>
                p.Salaries.Any(s => s.SlateID == request.SlateID) ||
                p.Projections.Any(s => s.SlateID == request.SlateID));

            return players.Select(p => ConstructResponse(p, slate)).ToList();
        }

        private GetPlayerForSlateResponse ConstructResponse(Player p, Slate slate)
        {
            var name = $"{p.FirstName} {p.LastName}";
            var slateID = slate.Id;
            var salary = p.Salaries.FirstOrDefault(s => s.SlateID == slateID);
            var projection = p.Projections.FirstOrDefault(p => p.SlateID == slateID);
            return new GetPlayerForSlateResponse(
                p.Id,
                name,
                salary?.Team ?? Team.UNKNOWN,
                salary?.Team.GetName(slate.Sport) ?? string.Empty,
                salary?.Positions.ToArray() ?? Array.Empty<PlayerPosition>(),
                salary?.SalaryAmount ?? 0,
                projection?.Data.ToArray() ?? Array.Empty<ProjectionData>()
            );
        }

        #endregion

    }
}
