using Domain.Aggregates;
using Domain.Events.PlayerEvents;
using Domain.ValueTypes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace DomainTests.Events.PlayerEvents
{
    [TestClass]
    public class Test_PlayerCreatedEvent
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnExpectedFormat()
        {
            // Arrange
            var slateId = SlateID.CreateNew();
            var team = Common.Enums.Team.BUF;
            var playerName = "Josh Allen";
            var salary = Salary.Create([], 10000, "123");
            var game = Game.Create(slateId, team, Common.Enums.Team.MIA, new TimeOnly(13, 0));
            var player = Player.Create(playerName, team, salary, game);
            var evt = new PlayerCreatedEvent(player);

            // Act
            var result = evt.ToString();

            // Assert
            Assert.AreEqual($"PlayerCreatedEvent: PlayerID={player.Id}, {playerName} ({team})",
                result);
        }

        #endregion

        #endregion
    }
}