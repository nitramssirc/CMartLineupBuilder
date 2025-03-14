using Common.Enums;

using Domain.Common.Entities;
using Domain.Events;
using Domain.Events.GameEvents;
using Domain.Events.SalaryEvents;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game : Entity<GameID>
    {
        #region Properties

        public SlateID SlateID { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public decimal HomePoints { get; private set; }
        public decimal AwayPoints { get; private set; }


        #endregion

        #region Constructor

        private Game() : base(new GameID())
        {
            SlateID = new SlateID();
            HomeTeam = Team.UNKNOWN;
            AwayTeam = Team.UNKNOWN;
            StartTime = new TimeOnly();
            HomePoints = 0;
            AwayPoints = 0;
        }

        private Game(
            GameID id,
            SlateID slateID,
            Team homeTeam,
            Team awayTeam,
            TimeOnly startTime,
            decimal homePoints,
            decimal awayPoints) : base(id)
        {
            SlateID = slateID;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
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
            var newGame = new Game(new GameID(), slateID, homeTeam, awayTeam, startTime, 0, 0);
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
