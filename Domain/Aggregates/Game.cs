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
    public class Game : Entity, IAggregateRoot
    {
        #region Properties

        public Guid SlateID { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public decimal HomePoints { get; private set; }
        public decimal AwayPoints { get; private set; }


        #endregion

        #region Constructor

        private Game(
            Guid gameID,
            Guid slateID,
            Team homeTeam,
            Team awayTeam,
            TimeOnly startTime,
            decimal homePoints,
            decimal awayPoints) : base(gameID)
        {
            SlateID = slateID;
            StartTime = startTime;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomePoints = homePoints;
            AwayPoints = awayPoints;
        }

        #endregion

        #region Factory Methods

        public static Game Create(
            Guid slateID,
            Team homeTeam,
            Team awayTeam,
            TimeOnly startTime)
        {
            var newGame = new Game(Guid.NewGuid(), slateID, homeTeam, awayTeam,startTime, 0, 0);
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
