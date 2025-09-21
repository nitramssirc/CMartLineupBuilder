using Domain.Aggregates;
using Domain.Common.Events;
using Domain.ValueTypes;

using System;

namespace Domain.Events.GameEvents
{
    public class GameLineUpdatedEvent : IDomainEvent
    {
        public GameID GameID { get; }
        public decimal HomePoints { get; }
        public decimal AwayPoints { get; }

        internal GameLineUpdatedEvent(Game game)
        {
            GameID = game.Id;
            HomePoints = game.HomePoints;
            AwayPoints = game.AwayPoints;
        }

        public override string ToString()
        {
            return $"GameLineUpdatedEvent: GameID={GameID}, HomePoints={HomePoints}, AwayPoints={AwayPoints}";
        }
    }
}

