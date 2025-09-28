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
    /// <summary>
    /// Event that is raised when a player's salary is updated.
    /// </summary>
    public class PlayerSalaryUpdatedEvent : IDomainEvent
    {
        public Guid PlayerID { get; private set; }

        public string PlayerName { get; set; }

        public int SalaryAmount { get; private set; }

        internal PlayerSalaryUpdatedEvent(
            Guid playerID,
            string playerName,
            int salaryAmount)
        {
            PlayerID = playerID;
            PlayerName = playerName;
            SalaryAmount = salaryAmount;
        }

        public override string ToString()
        {
            return $"PlayerSalaryUpdated: {PlayerName} - {SalaryAmount}";
        }
    }
}
