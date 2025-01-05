using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Domain.Events;

namespace Domain.Entities.Tests
{
    [TestClass()]
    public class SlateTests
    {
        #region Tests

        #region Create

        [TestMethod]
        public void Create_Should_InitializeDate()
        {
            // Arrange
            var date = DateTime.Now;
            var sport = Sport.NFL;
            var gameType = GameType.Cash;
            var dfsSite = DFSSite.DraftKings;
            var name = "Test Slate";

            // Act
            var slate = Slate.Create(date, sport, gameType, dfsSite, name);

            // Assert
            Assert.AreEqual(date, slate.Date);
        }

        [TestMethod]
        public void Create_Should_InitializeSport()
        {
            // Arrange
            var date = DateTime.Now;
            var sport = Sport.NFL;
            var gameType = GameType.Cash;
            var dfsSite = DFSSite.DraftKings;
            var name = "Test Slate";

            // Act
            var slate = Slate.Create(date, sport, gameType, dfsSite, name);

            // Assert
            Assert.AreEqual(sport, slate.Sport);
        }

        [TestMethod]
        public void Create_Should_InitializeGameType()
        {
            // Arrange
            var date = DateTime.Now;
            var sport = Sport.NFL;
            var gameType = GameType.Cash;
            var dfsSite = DFSSite.DraftKings;
            var name = "Test Slate";

            // Act
            var slate = Slate.Create(date, sport, gameType, dfsSite, name);

            // Assert
            Assert.AreEqual(gameType, slate.GameType);
        }

        [TestMethod]
        public void Create_Should_InitializeDFSSite()
        {
            // Arrange
            var date = DateTime.Now;
            var sport = Sport.NFL;
            var gameType = GameType.Cash;
            var dfsSite = DFSSite.DraftKings;
            var name = "Test Slate";

            // Act
            var slate = Slate.Create(date, sport, gameType, dfsSite, name);

            // Assert
            Assert.AreEqual(dfsSite, slate.DFSSite);
        }

        [TestMethod]
        public void Create_Should_InitializeName()
        {
            // Arrange
            var date = DateTime.Now;
            var sport = Sport.NFL;
            var gameType = GameType.Cash;
            var dfsSite = DFSSite.DraftKings;
            var name = "Test Slate";

            // Act
            var slate = Slate.Create(date, sport, gameType, dfsSite, name);

            // Assert
            Assert.AreEqual(name, slate.Name);
        }

        [TestMethod]
        public void Create_Should_AddSlateCreatedEvent()
        {
            // Arrange
            var date = DateTime.Now;
            var sport = Sport.NFL;
            var gameType = GameType.Cash;
            var dfsSite = DFSSite.DraftKings;
            var name = "Test Slate";

            // Act
            var slate = Slate.Create(date, sport, gameType, dfsSite, name);

            // Assert
            var domainEvent = slate.PublishDomainEvents().FirstOrDefault();
            Assert.IsInstanceOfType(domainEvent, typeof(SlateCreatedEvent));
        }

        #endregion

        #region AddSalary

        [TestMethod]
        public void AddSalary_Should_AddSalaryToSalaries()
        {
            // Arrange
            var slate = Slate.Create(
                DateTime.Now,
                Sport.NFL,
                GameType.Cash,
                DFSSite.DraftKings,
                "Test Slate"
            );
            var salary = Salary.Create(
                slate.Id,
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                10000,
                "DFSSiteID"
            );

            // Act
            slate.AddSalary(salary);

            // Assert
            Assert.IsTrue(slate.Salaries.Contains(salary));
        }

        [TestMethod]
        public void AddSalary_Should_AddSalaryAddedToSlateEvent()
        {
            // Arrange
            var slate = Slate.Create(
                DateTime.Now,
                Sport.NFL,
                GameType.Cash,
                DFSSite.DraftKings,
                "Test Slate"
            );
            var salary = Salary.Create(
                slate.Id,
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                10000,
                "DFSSiteID"
            );

            // Act
            slate.AddSalary(salary);

            // Assert
            var domainEvent = slate.PublishDomainEvents().Where(e=>e is SalaryAddedToSlateEvent).FirstOrDefault();
            var salaryAddedEvent = domainEvent as SalaryAddedToSlateEvent;
            Assert.IsNotNull(salaryAddedEvent);
            Assert.AreEqual(salary.Id, salaryAddedEvent.SalaryID);
            Assert.AreEqual(slate.Id, salaryAddedEvent.SlateID);
        }

        #endregion

        #endregion
    }
}