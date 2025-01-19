using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.ValueTypes;
using Common.Enums;
using System;
using System.Collections.Generic;
using Domain.Events.ProjectionEvents;
using Domain.Events.SlateEvents;

namespace Domain.Tests.Entities
{
    [TestClass]
    public class ProjectionTests
    {
        #region Tests

        #region Create

        private (SlateID slateID, ProjectionSource projectionSource, string playerName, List<ProjectionData> data, Team team) SetupForCreate(
            SlateID? slateID = null,
            ProjectionSource projectionSource = ProjectionSource.RotoGrinders,
            string playerName = "TestPlayer",
            List<ProjectionData>? data = null, 
            Team team = default)
        {
            slateID ??= new SlateID(Guid.NewGuid());
            data ??= new List<ProjectionData>();

            return (slateID, projectionSource, playerName, data, team);
        }

        [TestMethod]
        public void Create_Should_SetSlateID()
        {
            // Arrange
            var (slateID, projectionSource, playerName, data, team) = SetupForCreate();

            // Act
            var projection = Projection.Create(slateID, projectionSource, playerName, team, data);

            // Assert
            Assert.AreEqual(slateID, projection.SlateID);
        }

        [TestMethod]
        public void Create_Should_SetProjectionSource()
        {
            // Arrange
            var (slateID, projectionSource, playerName, data, team) = SetupForCreate();

            // Act
            var projection = Projection.Create(slateID, projectionSource, playerName, team, data);

            // Assert
            Assert.AreEqual(projectionSource, projection.ProjectionSource);
        }

        [TestMethod]
        public void Create_Should_SetPlayerName()
        {
            // Arrange
            var (slateID, projectionSource, playerName, data, team) = SetupForCreate();

            // Act
            var projection = Projection.Create(slateID, projectionSource, playerName, team, data);

            // Assert
            Assert.AreEqual(playerName, projection.PlayerName);
        }

        [TestMethod]
        public void Create_Should_SetProjectionData()
        {
            // Arrange
            var data = new List<ProjectionData>
            {
                new ProjectionData(StatCategories.PassingYards, 300),
                new ProjectionData(StatCategories.PassingTouchdowns, 3)
            };
            var (slateID, projectionSource, playerName, _, team) = SetupForCreate(data: data);

            // Act
            var projection = Projection.Create(slateID, projectionSource, playerName, team, data);

            // Assert
            CollectionAssert.AreEqual(data, (System.Collections.ICollection)projection.Data);
        }

        [TestMethod]
        public void Create_Should_GenerateANewProjectionID()
        {
            // Arrange
            var (slateID, projectionSource, playerName, data, team) = SetupForCreate();

            // Act
            var projection = Projection.Create(slateID, projectionSource, playerName, team, data);

            // Assert
            Assert.IsNotNull(projection.Id);
        }

        [TestMethod]
        public void Create_Should_AddProjectionCreatedEvent()
        {
            // Arrange
            var (slateID, projectionSource, playerName, data, team) = SetupForCreate();

            // Act
            var projection = Projection.Create(slateID, projectionSource, playerName, team, data);
            var domainEvents = projection.PublishDomainEvents();

            // Assert
            Assert.IsTrue(domainEvents.Length > 0);
            Assert.IsInstanceOfType(domainEvents[0], typeof(ProjectionCreatedEvent));
        }

        [TestMethod]
        public void Create_Should_SetTeam()
        {
            // Arrange
            var team = Team.DAL;
            var (slateID, projectionSource, playerName, data, _) = SetupForCreate(team: team);
            // Act
            var projection = Projection.Create(slateID, projectionSource, playerName, team, data);
            // Assert
            Assert.AreEqual(team, projection.Team);
        }

        #endregion

        #region AddProjection

        [TestMethod]
        public void AddProjection_Should_AddProjectionToProjectionList()
        {
            // Arrange
            var slate = Slate.Create(DateTime.Now, Sport.NFL, GameType.Cash, DFSSite.DraftKings, "TestSlate");
            var projection = Projection.Create(new SlateID(Guid.NewGuid()), ProjectionSource.RotoGrinders, "TestPlayer", Team.ARI, new List<ProjectionData>());

            // Act
            slate.AddProjection(projection);

            // Assert
            Assert.IsTrue(slate.Projections.Contains(projection));
        }

        [TestMethod]
        public void AddProjection_Should_AddProjectionAddedToSlateEvent()
        {
            // Arrange
            var slate = Slate.Create(DateTime.Now, Sport.NFL, GameType.Cash, DFSSite.DraftKings, "TestSlate");
            var projection = Projection.Create(new SlateID(Guid.NewGuid()), ProjectionSource.RotoGrinders, "TestPlayer", Team.ARI, new List<ProjectionData>());
            slate.PublishDomainEvents();

            // Act
            slate.AddProjection(projection);

            // Assert
            var domainEvents = slate.PublishDomainEvents();
            Assert.IsTrue(domainEvents.Length > 0);
            Assert.IsInstanceOfType(domainEvents[0], typeof(ProjectionAddedToSlateEvent));
        }

        #endregion

        #endregion
    }
}
