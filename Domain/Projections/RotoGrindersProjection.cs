using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projections
{
    public class RotoGrindersProjection
    {
        public int player_id { get; set; }

        public string team { get; set; }

        public string opp { get; set; }

        public string pos { get; set; }

        public string name { get; set; }

        public decimal? fpts { get; set; }

        public decimal? proj_own { get; set; }

        public decimal? smash { get; set; }
        
        public decimal? value_percent { get; set; }

        public decimal? ceil { get; set; }

        public decimal? floor { get; set; }

        public decimal? min_exposure { get; set; }

        public decimal? max_exposure { get; set; }

        public decimal rg_value { get; set; }

        public int salary { get; set; }

        public string custom { get; set; }

        public int rg_id { get; set; }

        public int partner_id { get; set; }

    }
}
