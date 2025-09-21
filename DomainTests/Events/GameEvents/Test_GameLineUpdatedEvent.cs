using Common.Enums;

using Domain.Aggregates;
using Domain.Events.GameEvents;
using Domain.ValueTypes;

namespace DomainTests.Events.GameEvents
{
    [TestClass]
    public class Test_GameLineUpdatedEvent
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnExpectedFormat()
        {
            // Arrange
            var homeTeam = Team.ATL;
            var awayTeam = Team.BAL;
            var gameId = GameID.CreateNew(homeTeam, awayTeam);
            var slateId = SlateID.CreateNew();
            var startTime = new TimeOnly(13, 0);
            decimal homePoints = 21.5m;
            decimal awayPoints = 17.25m;

            var game = Game.Create(slateId, homeTeam, awayTeam, startTime);
            game.UpdateLine(homePoints, awayPoints);

            var evt = new GameLineUpdatedEvent(game);

            // Act
            var result = evt.ToString();

            // Assert
            Assert.AreEqual(
                $"GameLineUpdatedEvent: GameID={game.Id}, HomePoints={homePoints}, AwayPoints={awayPoints}",
                result
            );
        }

        #endregion

        #endregion
    }
}