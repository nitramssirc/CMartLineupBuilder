using Common.Enums;

using Domain.Aggregates;
using Domain.Events.GameEvents;
using Domain.ValueTypes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace DomainTests.Events.GameEvents
{
    [TestClass]
    public class Test_GameCreatedEvent
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnExpectedFormat()
        {
            // Arrange
            var slateId = SlateID.CreateNew();
            var homeTeam = Team.DEN;
            var awayTeam = Team.KC;
            var startTime = new TimeOnly(19, 30);
            var gameId = GameID.CreateNew(homeTeam, awayTeam);
            var game = Game.Create(slateId, homeTeam, awayTeam, startTime);

            var evt = new GameCreatedEvent(game);

            // Act
            var result = evt.ToString();

            // Assert
            Assert.AreEqual(
                $"GameCreatedEvent: SlateID={evt.SlateID}, {evt.AwayTeam} at {evt.HomeTeam} @ {evt.StartTime}",
                result);
        }

        #endregion

        #endregion
    }
}