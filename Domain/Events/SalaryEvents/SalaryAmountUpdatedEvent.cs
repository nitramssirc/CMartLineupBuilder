using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.SalaryEvents
{
    public class SalaryAmountUpdatedEvent : IDomainEvent
    {
        public SalaryID SalaryID { get; private set; }
        public int SalaryAmount { get; private set; }
        internal SalaryAmountUpdatedEvent(Salary salary)
        {
            SalaryID = salary.Id;
            SalaryAmount = salary.SalaryAmount;
        }
        public override string ToString()
        {
            return $"SalaryAmountUpdatedEvent: {SalaryID} - {SalaryAmount}";
        }
    }
}