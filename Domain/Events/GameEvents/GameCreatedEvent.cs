using Common.Enums;

using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.GameEvents
{
    public class GameCreatedEvent:IDomainEvent
    {
        public GameID GameID { get; private set; }
        public SlateID SlateID { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public decimal HomePoints { get; private set; }
        public decimal AwayPoints { get; private set; }

        public GameCreatedEvent(
            Game createdGame)
        {
            GameID = createdGame.Id;
            SlateID = createdGame.SlateID;
            HomeTeam = createdGame.HomeTeam;
            AwayTeam = createdGame.AwayTeam;
            StartTime = createdGame.StartTime;
            HomePoints = createdGame.HomePoints;
            AwayPoints = createdGame.AwayPoints;
        }
    }
}
