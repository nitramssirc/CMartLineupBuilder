using Common.Enums;

using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.ProjectionEvents
{
    public class ProjectionCreatedEvent:IDomainEvent
    {
        public ProjectionID ProjectionID { get; }
        public SlateID SlateID { get; }
        public string Source { get; }
        public string PlayerName { get; }

        public Team Team { get; }

        internal ProjectionCreatedEvent(Projection projection)
        {
            ProjectionID = projection.Id;
            SlateID = projection.SlateID;
            Source = projection.ProjectionSource.ToString();
            PlayerName = projection.PlayerName;
            Team = projection.Team;
        }

        override public string ToString()
        {
            return $"Projection Created: {ProjectionID} - {SlateID} - {Source} - {PlayerName} ({Team})";
        }
    }
}
