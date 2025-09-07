using Common.Enums;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections.Models
{
    public class RotoGrindersNFLUploadedProjection:UploadedProjection
    {
        public int player_id { get; set; }
        public string team { get; set; } = string.Empty;
        public string opp { get; set; } = string.Empty;
        public string pos { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public decimal fpts { get; set; }
        public decimal proj_own { get; set; }
        public decimal smash { get; set; }
        public decimal opto_pct { get; set; }
        public decimal ceil { get; set; }
        public decimal floor { get; set; }
        public decimal min_exposure { get; set; }
        public decimal max_exposure { get; set; }
        public decimal rg_value { get; set; }
        public int salary { get; set; }
        public string custom { get; set; } = string.Empty;
        public int rg_id { get; set; }
        public int partner_id { get; set; }

        public override IEnumerable<ProjectionData> ProjectionData
        {
            get
            {
                return new List<ProjectionData>
            {
                new ProjectionData(StatCategories.PlayerId, player_id),
                new ProjectionData(StatCategories.Opponent, (decimal)ParseTeam(opp)),
                new ProjectionData(StatCategories.FantasyPoints, fpts),
                new ProjectionData(StatCategories.ProjectedOwnership, proj_own),
                new ProjectionData(StatCategories.Smash, smash),
                new ProjectionData(StatCategories.OpprotunityPct, opto_pct),
                new ProjectionData(StatCategories.Ceiling, ceil),
                new ProjectionData(StatCategories.Floor, floor),
                new ProjectionData(StatCategories.MinExposure, min_exposure),
                new ProjectionData(StatCategories.MaxExposure, max_exposure),
                new ProjectionData(StatCategories.RotoGrindersValue, rg_value),
                new ProjectionData(StatCategories.RotoGrindersID, rg_id),
                new ProjectionData(StatCategories.PartnerID, partner_id)
            };
            }
        }

        public override string Name => name;

        public override Team Team => ParseTeam(team);

        public RotoGrindersNFLUploadedProjection() { }

        public RotoGrindersNFLUploadedProjection(
            int player_id,
            string team,
            string opp,
            string pos,
            string name,
            decimal fpts,
            decimal proj_own,
            decimal smash,
            decimal opto_pct,
            decimal ceil,
            decimal floor,
            decimal min_exposure,
            decimal max_exposure,
            decimal rg_value,
            int salary,
            string custom,
            int rg_id,
            int partner_id)
        {
            this.player_id = player_id;
            this.team = team;
            this.opp = opp;
            this.pos = pos;
            this.name = name;
            this.fpts = fpts;
            this.proj_own = proj_own;
            this.smash = smash;
            this.opto_pct = opto_pct;
            this.ceil = ceil;
            this.floor = floor;
            this.min_exposure = min_exposure;
            this.max_exposure = max_exposure;
            this.rg_value = rg_value;
            this.salary = salary;
            this.custom = custom;
            this.rg_id = rg_id;
            this.partner_id = partner_id;
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
