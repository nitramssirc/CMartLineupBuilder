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
            var slateId = SlateID.CreateNew();
            var playerId = PlayerID.CreateNew(slateId, "Test Player", Team.ATL);
            var salaryAmount = 7500;
            var evt = new PlayerSalaryUpdatedEvent(playerId, salaryAmount);

            // Act
            var result = evt.ToString();

            // Assert
            Assert.AreEqual($"PlayerSalaryUpdated: {playerId.Name} - {salaryAmount}", result);
        }

        #endregion

        #endregion
    }
}