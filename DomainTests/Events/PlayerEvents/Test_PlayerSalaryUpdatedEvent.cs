using Domain.Events.PlayerEvents;
using Domain.ValueTypes;
using Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainTests.Events.PlayerEvents
{
    [TestClass]
    public class Test_PlayerSalaryUpdatedEvent
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnExpectedFormat()
        {
            // Arrange
            var slateId = Guid.NewGuid();
            var playerId = Guid.NewGuid();
            var playerName = "John Doe";
            var salaryAmount = 7500;
            var evt = new PlayerSalaryUpdatedEvent(playerId, playerName, salaryAmount);

            // Act
            var result = evt.ToString();

            // Assert
            Assert.AreEqual($"PlayerSalaryUpdated: {playerName} - {salaryAmount}", result);
        }

        #endregion

        #endregion
    }
}