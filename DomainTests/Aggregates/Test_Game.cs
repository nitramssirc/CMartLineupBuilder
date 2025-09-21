using Common.Enums;

using Domain.Aggregates;
using Domain.Events.GameEvents;
using Domain.ValueTypes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.Aggregates
{
    [TestClass]
    public class Test_Game
    {
        #region Tests

        #region Create

        private Game SetupForCreate(
            SlateID? slateID = null,
            Team homeTeam = Team.DAL,
            Team awayTeam = Team.CHI,
            TimeOnly startTime = default)
        {
            slateID ??= SlateID.CreateNew();

            return Game.Create(slateID, homeTeam, awayTeam, startTime);
        }

        [TestMethod]
        public void Create_Should_SetGameIDToGivenHomeAndAwayTeam()
        {
            //Act
            var game = SetupForCreate(homeTeam: Team.DAL, awayTeam: Team.CHI);

            //Assert
            Assert.AreEqual(Team.DAL, game.HomeTeam);
            Assert.AreEqual(Team.CHI, game.AwayTeam);
        }

        [TestMethod]
        public void Create_Should_SetSlateIDToParam()
        {
            //Assert
            var expectedSlateID = SlateID.CreateNew();

            //Act
            var game = SetupForCreate(slateID: expectedSlateID);

            //Assert
            Assert.AreEqual(expectedSlateID, game.SlateID);
        }

        [TestMethod]
        public void Create_Should_SetStartTimeToParam()
        {
            //Assert
            var expectedStartTime = new TimeOnly();

            //Act
            var game = SetupForCreate(startTime: expectedStartTime);

            //Assert
            Assert.AreEqual(expectedStartTime, game.StartTime);
        }

        [TestMethod]
        public void Create_Should_SetHomePointsToZero()
        {
            //Act
            var game = SetupForCreate();

            //Assert
            Assert.AreEqual(0, game.HomePoints);
        }

        [TestMethod]
        public void Create_Should_SetAwayPointsToZero()
        {
            //Act
            var game = SetupForCreate();

            //Assert
            Assert.AreEqual(0, game.AwayPoints);
        }

        [TestMethod]
        public void Create_Should_AddGameCreatedDomainEvent()
        {
            //Act
            var game = SetupForCreate();

            //Assert
            var domainEvents = game.PublishDomainEvents();

            //Act
            var domainEvent = domainEvents.FirstOrDefault() as GameCreatedEvent;
            Assert.IsNotNull(domainEvent);
        }

        #endregion

        #region UpdateLine

        [TestMethod]
        public void UpdateLine_Should_SetHomePoints()
        {
            // Arrange
            var game = SetupForCreate(homeTeam: Team.DAL, awayTeam: Team.CHI);
            decimal newHomePoints = 7.5m;
            decimal newAwayPoints = 3.0m;

            // Act
            game.UpdateLine(newHomePoints, newAwayPoints);

            // Assert
            Assert.AreEqual(newHomePoints, game.HomePoints);
        }

        [TestMethod]
        public void UpdateLine_Should_SetAwayPoints()
        {
            // Arrange
            var game = SetupForCreate(homeTeam: Team.DAL, awayTeam: Team.CHI);
            decimal newHomePoints = 7.5m;
            decimal newAwayPoints = 3.0m;

            // Act
            game.UpdateLine(newHomePoints, newAwayPoints);

            // Assert
            Assert.AreEqual(newAwayPoints, game.AwayPoints);
        }

        [TestMethod]
        public void UpdateLine_Should_AddGameLineUpdatedDomainEvent()
        {
            // Arrange
            var game = SetupForCreate(homeTeam: Team.DAL, awayTeam: Team.CHI);

            // Act
            game.UpdateLine(10m, 5m);
            var domainEvents = game.PublishDomainEvents();

            // Assert
            Assert.IsTrue(domainEvents.Any(e => e is GameLineUpdatedEvent));
        }

        #endregion

        #endregion
    }
}
