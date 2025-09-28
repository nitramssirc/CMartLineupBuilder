using Common.Enums;

using Domain.Aggregates;
using Domain.Common.Events;
using Domain.Events.GameEvents;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.GameEvents
{
    public class GameCreatedEvent : IDomainEvent
    {
        public Guid GameID { get; private set; }
        public Guid SlateID { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public TimeOnly StartTime { get; private set; }

        internal GameCreatedEvent(
            Game createdGame)
        {
            GameID = createdGame.Id;
            SlateID = createdGame.SlateID;
            HomeTeam = createdGame.HomeTeam;
            AwayTeam = createdGame.AwayTeam;
            StartTime = createdGame.StartTime;
        }

        public override string ToString()
        {
            return $"GameCreatedEvent: SlateID={SlateID}, {AwayTeam} at {HomeTeam} @ {StartTime}";
        }
    }
}