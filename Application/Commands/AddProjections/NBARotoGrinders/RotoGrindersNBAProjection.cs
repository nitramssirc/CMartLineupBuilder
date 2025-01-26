using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections.NBARotoGrinders
{
    public class RotoGrindersNBAProjection
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
        public int minutes { get; set; }
        public decimal ceil { get; set; }
        public decimal floor { get; set; }
        public decimal min_exposure { get; set; }
        public decimal max_exposure { get; set; }
        public decimal rg_value { get; set; }
        public int salary { get; set; }
        public string custom { get; set; } = string.Empty;
        public int rg_id { get; set; }
        public int partner_id { get; set; }

        public RotoGrindersNBAProjection() { }

        public RotoGrindersNBAProjection(
            int player_id,
            string team,
            string opp,
            string pos,
            string name,
            decimal fpts,
            decimal proj_own,
            decimal smash,
            decimal opto_pct,
            int minutes,
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
            this.minutes = minutes;
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
    }
}
