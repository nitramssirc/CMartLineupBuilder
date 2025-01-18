using Domain.Events.SalaryEvents;
using Domain.Entities;
using Domain.ValueTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Common.Enums;

namespace Domain.Tests.Events.SalaryEvents
{
    [TestClass]
    public class SalaryAmountUpdatedEventTests
    {
        [TestMethod]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            var salary = Salary.Create(new SlateID(Guid.NewGuid()), "John Doe", new[] { PlayerPosition.QB, PlayerPosition.RB }, Team.ARI, 50000, "DraftKings");
            
            var salaryAmountUpdatedEvent = new SalaryAmountUpdatedEvent(salary);

            // Act
            var result = salaryAmountUpdatedEvent.ToString();

            // Assert
            var expected = $"SalaryAmountUpdatedEvent: {salary.Id} - 50000";
            Assert.AreEqual(expected, result);
        }
    }
}
