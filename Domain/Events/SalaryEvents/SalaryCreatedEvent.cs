using Common.Enums;

using Domain.Common.Events;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.SalaryEvents
{
    /// <summary>
    /// Event that is raised when a salary is created.
    /// </summary>
    public class SalaryCreatedEvent : IDomainEvent
    {
        public SalaryID SalaryID { get; private set; }
        public SlateID SlateID { get; private set; }
        public string PlayerName { get; private set; }
        public PlayerPosition[] Positions { get; private set; }
        public Team Team { get; private set; }
        public int SalaryAmount { get; private set; }
        public string DFSSiteID { get; private set; }

        internal SalaryCreatedEvent(
            SalaryID salaryID,
            SlateID slateID,
            string playerName,
            PlayerPosition[] positions,
            Team team,
            int salaryAmount,
            string dfsSiteID)
        {
            SalaryID = salaryID;
            SlateID = slateID;
            PlayerName = playerName;
            Positions = positions;
            Team = team;
            SalaryAmount = salaryAmount;
            DFSSiteID = dfsSiteID;
        }

        public override string ToString()
        {
            return $"SalaryCreatedEvent: {PlayerName} - {SalaryAmount} - {Team}";
        }
    }
}
