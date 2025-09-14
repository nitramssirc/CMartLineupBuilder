using Common.Enums;

using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueTypes
{
    public class GameID : EntityID
    {
        public Team HomeTeam { get; private set; }

        public Team AwayTeam { get; private set; }

        public GameID(Team homeTeam, Team awayTeam, Guid id) : base(id)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public GameID(Team homeTeam, Team awayTeam) : this(homeTeam, awayTeam, Guid.NewGuid())
        {
        }

        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            yield return HomeTeam;
            yield return AwayTeam;
        }
    }
}
