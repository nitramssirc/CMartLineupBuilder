using Common.Enums;

using Domain.Common.Entities;
using Domain.Events;
using Domain.Events.GameEvents;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Game : Entity<GameID>, IAggregateRoot
    {
        #region Properties

        public SlateID SlateID { get; private set; }
        public Team HomeTeam => Id.HomeTeam;
        public Team AwayTeam => Id.AwayTeam;
        public TimeOnly StartTime { get; private set; }
        public decimal HomePoints { get; private set; }
        public decimal AwayPoints { get; private set; }


        #endregion

        #region Constructor

        private Game(
            GameID id,
            SlateID slateID,
            TimeOnly startTime,
            decimal homePoints,
            decimal awayPoints) : base(id)
        {
            SlateID = slateID;
            StartTime = startTime;
            HomePoints = homePoints;
            AwayPoints = awayPoints;
        }

        #endregion

        #region Factory Methods

        public static Game Create(
            SlateID slateID,
            Team homeTeam,
            Team awayTeam,
            TimeOnly startTime)
        {
            var newGame = new Game(new GameID(homeTeam, awayTeam), slateID, startTime, 0, 0);
            newGame.AddDomainEvent(new GameCreatedEvent(newGame));
            return newGame;
        }

        #endregion

        #region Update Methods

        public void UpdateLine(decimal homePoints, decimal awayPoints)
        {
            HomePoints = homePoints;
            AwayPoints = awayPoints;
            AddDomainEvent(new GameLineUpdatedEvent(this));
        }

        #endregion



    }
}
