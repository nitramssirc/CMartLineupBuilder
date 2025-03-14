using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.SlateEvents
{
    public class GameAddedToSlateEvent: IDomainEvent
    {
        public SlateID SlateID { get; }
        public GameID GameID { get; }
        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public TimeOnly GameTime { get; }

        internal GameAddedToSlateEvent(
            Slate slate,
            Game game)
        {
            SlateID = slate.Id;
            GameID = game.Id;
            HomeTeam = game.HomeTeam.ToString();
            AwayTeam = game.AwayTeam.ToString();
            GameTime = game.StartTime;
        }
    }
}
