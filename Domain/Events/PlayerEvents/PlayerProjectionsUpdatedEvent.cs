using Common.Enums;

using Domain.Common.Events;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.PlayerEvents
{
    public class PlayerProjectionsUpdatedEvent: IDomainEvent
    {
        public PlayerID PlayerID { get; private set; }
        public ProjectionSource ProjectionSource { get; private set; }

        internal PlayerProjectionsUpdatedEvent(
            PlayerID playerID,
            ProjectionSource projectionSource)
        {
            PlayerID = playerID;
            ProjectionSource = projectionSource;
        }

        public override string ToString()
        {
            return $"PlayerProjectionsUpdatedEvent: PlayerID={PlayerID}, ProjectionSource={ProjectionSource}";
        }
    }
}
