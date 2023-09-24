using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Lineups
{
    internal class DraftKingsLineup
    {
        public Week Week { get; set; }

        public Player QB { get; set; }

        public Player RB1 { get; set; }

        public Player RB2 { get; set; }

        public Player WR1 { get; set; }

        public Player WR2 { get; set; }

        public Player WR3 { get; set; }

        public Player TE { get; set; }

        public Player FLEX { get; set; }

        public Player DST { get; set; }
    }
}
