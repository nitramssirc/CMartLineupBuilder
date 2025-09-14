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
        public PlayerID PlayerID { get; private set; }

        public PlayerCreatedEvent(
            PlayerID playerID)
        {
            PlayerID = playerID;
        }
    }
}
