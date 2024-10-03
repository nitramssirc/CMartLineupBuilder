using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MatchupRanking
    {
        public int Id { get; set; }

        public int WeekId { get; set; }

        public int GameId { get; set; }

        public Team Team { get; set; }

        public MatchupType MatchupType { get; set; }

        public MatchupRankingScore Score { get; set; }
    }
}
