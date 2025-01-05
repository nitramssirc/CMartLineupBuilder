using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Common.Enums;
using System;
using System.Linq;
using Domain.Events;
using Domain.ValueTypes;

namespace Domain.Entities.Tests
{
    [TestClass]
    public class SalaryTests
    {
        #region Tests

        #region Create

        [TestMethod]
        public void Create_Should_InitializeSlateID()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = new[] { PlayerPosition.QB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(slateID, salary.SlateID);
        }

        [TestMethod]
        public void Create_Should_InitializePlayerName()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = new[] { PlayerPosition.QB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(playerName, salary.PlayerName);
        }

        [TestMethod]
        public void Create_Should_InitializePositions()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = new[] { PlayerPosition.QB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            CollectionAssert.AreEqual(positions, salary.Positions);
        }

        [TestMethod]
        public void Create_Should_InitializeTeam()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = new[] { PlayerPosition.QB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(team, salary.Team);
        }

        [TestMethod]
        public void Create_Should_InitializeSalaryAmount()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = new[] { PlayerPosition.QB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(salaryAmount, salary.SalaryAmount);
        }

        [TestMethod]
        public void Create_Should_InitializeDFSSiteID()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = new[] { PlayerPosition.QB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(dfsSiteID, salary.DFSSiteID);
        }

        [TestMethod]
        public void Create_Should_ParsePositions()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = "QB/RB";
            var team = "ARI";
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            CollectionAssert.AreEqual(new[] { PlayerPosition.QB, PlayerPosition.RB }, salary.Positions);
        }

        [TestMethod]
        public void Create_Should_ParseTeam()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = "QB";
            var team = "ARI";
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(Team.ARI, salary.Team);
        }

        [TestMethod]
        public void Create_Should_AddSalaryCreatedEvent()
        {
            // Arrange
            var slateID = new SlateID();
            var playerName = "Test Player";
            var positions = new[] { PlayerPosition.QB };
            var team = Team.ARI;
            var salaryAmount = 5000;
            var dfsSiteID = "DraftKings";

            // Act
            var salary = Salary.Create(slateID, playerName, positions, team, salaryAmount, dfsSiteID);

            // Assert
            var domainEvent = salary.PublishDomainEvents().FirstOrDefault();
            Assert.IsInstanceOfType(domainEvent, typeof(SalaryCreatedEvent));
        }

        #endregion

        #endregion
    }
}