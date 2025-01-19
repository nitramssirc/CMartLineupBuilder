using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Events.SlateEvents;
using Domain.Entities;
using Domain.ValueTypes;
using Common.Enums;
using System;

namespace Domain.Tests.Events.SlateEvents
{
    [TestClass]
    public class ProjectionRemovedFromSlateEventTests
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnFormattedString()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = Projection.Create(slateID, ProjectionSource.RotoGrinders, "TestPlayer", Team.ATL, new List<ProjectionData>());
            var projectionRemovedFromSlateEvent = new ProjectionRemovedFromSlateEvent(projection);

            // Act
            var result = projectionRemovedFromSlateEvent.ToString();

            // Assert
            var expected = $"Projection Removed from Slate: {projection.Id} - {slateID}";
            Assert.AreEqual(expected, result);
        }

        #endregion

        #endregion
    }
}



