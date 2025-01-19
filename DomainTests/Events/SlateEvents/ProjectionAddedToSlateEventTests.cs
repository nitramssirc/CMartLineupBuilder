using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Events.SlateEvents;
using Domain.Entities;
using Domain.ValueTypes;
using Common.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Tests.Events.SlateEvents
{
    [TestClass]
    public class ProjectionAddedToSlateEventTests
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnFormattedString()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = Projection.Create(slateID, ProjectionSource.RotoGrinders, "TestPlayer", Team.DAL, new List<ProjectionData>());
            var projectionAddedToSlateEvent = new ProjectionAddedToSlateEvent(projection);

            // Act
            var result = projectionAddedToSlateEvent.ToString();

            // Assert
            var expected = $"Projection Added to Slate: {projection.Id} - {slateID}";
            Assert.AreEqual(expected, result);
        }

        #endregion

        #endregion
    }
}

