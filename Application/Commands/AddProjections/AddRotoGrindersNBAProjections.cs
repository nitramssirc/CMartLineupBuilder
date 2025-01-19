using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections
{
    internal class AddRotoGrindersNBAProjections
        : AddProjectionsRequestBase
    {
        private readonly List<RotoGrindersNBAProjection> _projections;

        public AddRotoGrindersNBAProjections(SlateID slateID, List<RotoGrindersNBAProjection> projections)
            : base(slateID)
        {
            _projections = projections;
        }

        public override ProjectionSource ProjectionSource => ProjectionSource.RotoGrinders;

        internal override IEnumerable<ProjectionDTO> GetProjections()
        {
            return _projections.Select(ConstructProjection);
        }

        private ProjectionDTO ConstructProjection(RotoGrindersNBAProjection rotoGrindersNBAProjection)
        {
            var team = ParseTeam(rotoGrindersNBAProjection.team);
            return new ProjectionDTO(
                rotoGrindersNBAProjection.name, 
                team, 
                ConstructProjectionData(rotoGrindersNBAProjection));
        }

        private IEnumerable<ProjectionData> ConstructProjectionData(RotoGrindersNBAProjection rotoGrindersNBAProjection)
        {
            return new List<ProjectionData>
            {
                new ProjectionData(StatCategories.PlayerId, rotoGrindersNBAProjection.player_id),
                new ProjectionData(StatCategories.Opponent, (decimal)ParseTeam(rotoGrindersNBAProjection.opp)),
                new ProjectionData(StatCategories.FantasyPoints, rotoGrindersNBAProjection.fpts),
                new ProjectionData(StatCategories.ProjectedOwnership, rotoGrindersNBAProjection.proj_own),
                new ProjectionData(StatCategories.Smash, rotoGrindersNBAProjection.smash),
                new ProjectionData(StatCategories.OpprotunityPct, rotoGrindersNBAProjection.opto_pct),
                new ProjectionData(StatCategories.Minutes, rotoGrindersNBAProjection.minutes),
                new ProjectionData(StatCategories.Ceiling, rotoGrindersNBAProjection.ceil),
                new ProjectionData(StatCategories.Floor, rotoGrindersNBAProjection.floor),
                new ProjectionData(StatCategories.MinExposure, rotoGrindersNBAProjection.min_exposure),
                new ProjectionData(StatCategories.MaxExposure, rotoGrindersNBAProjection.max_exposure),
                new ProjectionData(StatCategories.RotoGrindersValue, rotoGrindersNBAProjection.rg_value),
                new ProjectionData(StatCategories.RotoGrindersID, rotoGrindersNBAProjection.rg_id),
                new ProjectionData(StatCategories.PartnerID, rotoGrindersNBAProjection.partner_id)
            };
        }

        private Team ParseTeam(string team)
        {
            if (Enum.TryParse<Team>(team, out var parsedTeam))
            {
                return parsedTeam;
            }
            return Team.UNKNOWN;
        }
    }
}
