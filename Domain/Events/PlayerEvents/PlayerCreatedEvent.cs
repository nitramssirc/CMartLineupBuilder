using Common.Enums;

using Domain.Aggregates;
using Domain.Common.Events;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.PlayerEvents
{
    public class PlayerCreatedEvent: IDomainEvent
    {
        public Guid PlayerID { get; private set; }

        public Team Team { get; private set; }

        public string Name { get; private set; }

        internal PlayerCreatedEvent(
            Player player)
        {
            PlayerID = player.Id;
            Team = player.Team;
            Name = player.Name;
        }

        public override string ToString()
        {
            return $"PlayerCreatedEvent: PlayerID={PlayerID}, {Name} ({Team})";
        }
    }
}
