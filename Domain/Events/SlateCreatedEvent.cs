using Common.Enums;

using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    /// <summary>
    /// Event that is raised when a slate is created
    /// </summary>
    public class SlateCreatedEvent : IDomainEvent
    {
        public SlateID SlateID { get; private set; }
        public string Name { get; private set; }

        public DateTime Date { get; private set; }

        public Sport Sport { get; private set; }

        public GameType GameType { get; private set; }

        public DFSSite DFSSite { get; private set; }

        internal SlateCreatedEvent(Slate slate)
        {
            SlateID = slate.Id;
            Name = slate.Name;
            Date = slate.Date;
            Sport = slate.Sport;
            GameType = slate.GameType;
            DFSSite = slate.DFSSite;
        }

        public override string ToString()
        {
            return $"SlateCreatedEvent: {Name} - {Date} - {Sport} - {GameType} - {DFSSite}";
        }
    }
}
