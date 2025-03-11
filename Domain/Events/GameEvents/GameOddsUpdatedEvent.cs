using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueTypes;

using System;

namespace Domain.Events.GameEvents
{
    public class GameOddsUpdatedEvent : IDomainEvent
    {
        public GameID GameID { get; }
        public decimal HomePoints { get; }
        public decimal AwayPoints { get; }

        public GameOddsUpdatedEvent(Game game)
        {
            GameID = game.Id;
            HomePoints = game.HomePoints;
            AwayPoints = game.AwayPoints;
        }
    }
}

