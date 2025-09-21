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
        #region Properties

        public Team HomeTeam { get; private set; }

        public Team AwayTeam { get; private set; }

        #endregion

        #region Constructors

        private GameID(Team homeTeam, Team awayTeam, Guid id) : base(id)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        #endregion

        #region Factory Methods

        internal static GameID CreateNew(Team homeTeam, Team awayTeam)
        {
            if (homeTeam == awayTeam)
            {
                throw new ArgumentException("Home team and away team cannot be the same.");
            }
            return new GameID(homeTeam, awayTeam, Guid.NewGuid());
        }

        #endregion

        #region EntityID Overrides

        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            yield return HomeTeam;
            yield return AwayTeam;
        }

        #endregion
    }
}
