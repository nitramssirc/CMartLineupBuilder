using Domain.Aggregates;
using Domain.Events.SlateEvents;
using Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.ValueTypes;

namespace DomainTests.Events.SlateEvents
{
    [TestClass]
    public class Test_SlateCreatedEvent
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnExpectedFormat()
        {
            // Arrange
            var slateId = SlateID.CreateNew();
            var date = new DateTime(2025, 9, 21, 12, 0, 0);
            var sport = Sport.NFL;
            var gameType = GameType.Cash;
            var dfsSite = DFSSite.DraftKings;
            var name = "Test Slate";

            var slate = Slate.Create(date, sport, gameType, dfsSite, name);

            var evt = new SlateCreatedEvent(slate);

            // Act
            var result = evt.ToString();

            // Assert
            Assert.AreEqual(
                $"SlateCreatedEvent: {name} - {date} - {sport} - {gameType} - {dfsSite}",
                result
            );
        }

        #endregion

        #endregion
    }
}
