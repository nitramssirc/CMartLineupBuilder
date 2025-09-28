using System;
using Domain.Events.PlayerEvents;
using Domain.ValueTypes;
using Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests.Events.PlayerEvents
{
    [TestClass]
    public class Test_PlayerProjectionsUpdatedEvent
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnExpectedFormat()
        {
            // Arrange
            var slateId = Guid.NewGuid();
            var playerId = Guid.NewGuid();
            var projectionSource = ProjectionSource.RotoGrinders;
            var evt = new PlayerProjectionsUpdatedEvent(playerId, projectionSource);

            // Act
            var result = evt.ToString();

            // Assert
            Assert.AreEqual(
                $"PlayerProjectionsUpdatedEvent: PlayerID={playerId}, ProjectionSource={projectionSource}",
                result);
        }

        #endregion

        #endregion
    }
}