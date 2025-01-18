using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Common.Enums;
using System;
using System.Linq;
using Domain.ValueTypes;
using Domain.Events.SalaryEvents;

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

        #region UpdateSalaryAmount

        [TestMethod]
        public void UpdateSalaryAmount_Should_UpdateTheSalaryAmount()
        {
            // Arrange
            var salary = Salary.Create(
                new SlateID(Guid.NewGuid()),
                "PlayerName",
                [PlayerPosition.QB],
                Team.ARI,
                50000,
                "DFSSiteID");

            // Act
            salary.UpdateSalaryAmount(60000);

            // Assert
            Assert.AreEqual(60000, salary.SalaryAmount);
        }

        [TestMethod]
        public void UpdateSalaryAmount_Should_AddSalaryAmountUpdatedEvent_When_SalaryAmountChanged()
        {
            // Arrange
            var salary = Salary.Create(
                new SlateID(Guid.NewGuid()),
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                50000,
                "DFSSiteID");

            // Act
            salary.UpdateSalaryAmount(60000);

            // Assert
            var domainEvents = salary.PublishDomainEvents();
            Assert.IsTrue(domainEvents.Any(e => e is SalaryAmountUpdatedEvent));
        }

        [TestMethod]
        public void UpdateSalaryAmount_Should_NotAddSalaryAmountUpdatedEvent_When_SalaryAmountDidNotChange()
        {
            // Arrange
            var salary = Salary.Create(
                new SlateID(Guid.NewGuid()),
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                50000,
                "DFSSiteID");

            // Act
            salary.UpdateSalaryAmount(50000);

            // Assert
            var domainEvents = salary.PublishDomainEvents();
            Assert.IsFalse(domainEvents.Any(e => e is SalaryAmountUpdatedEvent));
        }

        #endregion

        #endregion
    }
}