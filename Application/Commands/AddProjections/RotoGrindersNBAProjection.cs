using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections
{
    public class RotoGrindersNBAProjection
    {
        public int player_id { get; private set; }
        public string team { get; private set; }= string.Empty;
        public string opp { get; private set; } = string.Empty;
        public string pos { get; private set; } = string.Empty;
        public string name { get; private set; } = string.Empty;
        public decimal fpts { get; private set; }
        public decimal proj_own { get; private set; }
        public decimal smash { get; private set; }
        public decimal opto_pct { get; private set; }
        public int minutes { get; private set; }
        public decimal ceil { get; private set; }
        public decimal floor { get; private set; }
        public decimal min_exposure { get; private set; }
        public decimal max_exposure { get; private set; }
        public decimal rg_value { get; private set; }
        public int salary { get; private set; }
        public string custom { get; private set; } = string.Empty;
        public int rg_id { get; private set; }
        public int partner_id { get; private set; }

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
