using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Domain.Entities;
using Domain.Events.SlateEvents;

namespace DomainTests.Events.SlateEvents
{
    [TestClass()]
    public class SalaryAddedToSlateEventTests
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnCorrectString()
        {
            // Arrange
            var slate = Slate.Create(
                DateTime.Now,
                Sport.NBA,
                GameType.Cash,
                DFSSite.DraftKings,
                "SlateName"
            );
            var salary = Salary.Create(
                slate.Id,
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ATL,
                10000,
                "DFSSiteID"
            );
            var eventInstance = new SalaryAddedToSlateEvent(slate, salary);

            // Act
            var result = eventInstance.ToString();

            // Assert
            Assert.AreEqual("SalaryAddedToSlateEvent: SlateName - PlayerName - 10000", result);
        }

        #endregion

        #endregion
    }
}