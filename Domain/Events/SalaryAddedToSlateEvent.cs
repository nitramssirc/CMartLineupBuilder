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
    /// Event that is raised when a salary is added to a slate.
    /// </summary>
    public class SalaryAddedToSlateEvent : IDomainEvent
    {
        public SalaryID SalaryID { get; private set; }
        public string PlayerName { get; private set; }
        public int SalaryAmount { get; private set; }

        public SlateID SlateID { get; private set; }
        public string SlateName { get; private set; }

        internal SalaryAddedToSlateEvent(Slate slate, Salary salary)
        {
            SalaryID = salary.Id;
            PlayerName = salary.PlayerName;
            SalaryAmount = salary.SalaryAmount;
            SlateID = slate.Id;
            SlateName = slate.Name;
        }

        public override string ToString()
        {
            return $"SalaryAddedToSlateEvent: {SlateName} - {PlayerName} - {SalaryAmount}";
        }
    }
}
