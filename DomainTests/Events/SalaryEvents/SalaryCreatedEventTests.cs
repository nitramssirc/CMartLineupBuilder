using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Domain.ValueTypes;
using Domain.Events.SalaryEvents;

namespace DomainTests.Events.SalaryEvents
{
    [TestClass()]
    public class SalaryCreatedEventTests
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnCorrectString()
        {
            // Arrange
            var salaryID = new SalaryID();
            var slateID = new SlateID();
            var playerName = "John Doe";
            var positions = new[] { PlayerPosition.QB, PlayerPosition.RB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            var salaryCreatedEvent = new SalaryCreatedEvent(
                salaryID,
                slateID,
                playerName,
                positions,
                team,
                salaryAmount,
                dfsSiteID
            );

            // Act
            var result = salaryCreatedEvent.ToString();

            // Assert
            var expected = $"SalaryCreatedEvent: {playerName} - {salaryAmount} - {team}";
            Assert.AreEqual(expected, result);
        }

        #endregion

        #endregion
    }
}