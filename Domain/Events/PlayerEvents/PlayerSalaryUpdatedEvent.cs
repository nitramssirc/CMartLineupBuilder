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
        public PlayerID PlayerID { get; private set; }

        public int SalaryAmount { get; private set; }

        internal PlayerSalaryUpdatedEvent(
            PlayerID playerID,
            int salaryAmount)
        {
            PlayerID = playerID;
            SalaryAmount = salaryAmount;
        }

        public override string ToString()
        {
            return $"PlayerSalaryUpdated: {PlayerID.Name} - {SalaryAmount}";
        }
    }
}
