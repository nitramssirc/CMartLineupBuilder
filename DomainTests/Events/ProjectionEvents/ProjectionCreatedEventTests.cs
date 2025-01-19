using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Events.ProjectionEvents;
using Domain.ValueTypes;
using System;
using Domain.Entities;
using Common.Enums;

namespace Domain.Tests.Events.ProjectionEvents
{
    [TestClass]
    public class ProjectionCreatedEventTests
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnFormattedString()
        {
            // Arrange
            var projection = Projection.Create(
                new SlateID(Guid.NewGuid()),
                ProjectionSource.RotoGrinders,
                "TestPlayer",
                Team.DAL,
                []);
            var projectionCreatedEvent = new ProjectionCreatedEvent(projection);

            // Act
            var result = projectionCreatedEvent.ToString();

            // Assert
            var expected = $"Projection Created: {projection.Id} - {projection.SlateID} - {projection.ProjectionSource} - {projection.PlayerName} ({projection.Team})";
            Assert.AreEqual(expected, result);
        }

        #endregion

        #endregion
    }
}