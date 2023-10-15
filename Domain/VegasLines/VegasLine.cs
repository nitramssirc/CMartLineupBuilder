using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VegasLines
{
    public class VegasLine
    {
        public Team Team { get; set; }

        public Team Opponent { get; set; }

        public bool IsHomeTeam { get; set; }

        public decimal GameTotal { get; set; }

        public decimal TeamPoints { get; set; }

        public decimal Spread { get; set; }

    }
}
