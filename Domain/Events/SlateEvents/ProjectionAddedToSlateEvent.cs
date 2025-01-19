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
    public class ProjectionAddedToSlateEvent:IDomainEvent
    {
        public SlateID SlateID { get; }
        public ProjectionID ProjectionID { get; }
        internal ProjectionAddedToSlateEvent(Projection projection)
        {
            SlateID = projection.SlateID;
            ProjectionID = projection.Id;
        }
        override public string ToString()
        {
            return $"Projection Added to Slate: {ProjectionID} - {SlateID}";
        }
    }
}
