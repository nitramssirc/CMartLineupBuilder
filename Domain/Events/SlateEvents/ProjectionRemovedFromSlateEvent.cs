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
    public class ProjectionRemovedFromSlateEvent:IDomainEvent
    {
        public SlateID SlateID { get; }
        public ProjectionID ProjectionID { get; }
        internal ProjectionRemovedFromSlateEvent(Projection projection)
        {
            SlateID = projection.SlateID;
            ProjectionID = projection.Id;
        }
        override public string ToString()
        {
            return $"Projection Removed from Slate: {ProjectionID} - {SlateID}";
        }
    }
}
