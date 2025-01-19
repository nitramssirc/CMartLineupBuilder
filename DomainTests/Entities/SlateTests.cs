using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Domain.Events.SlateEvents;
using Domain.Events.SalaryEvents;
using Domain.ValueTypes;

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

        [TestMethod]
        public void AddSalary_Should_UpdateSalaryAmount_When_SalaryAlreadyExistsForDFSSiteID()
        {
            // Arrange
            var slate = Slate.Create(
                DateTime.Now,
                Sport.NFL,
                GameType.Cash,
                DFSSite.DraftKings,
                "Test Slate"
            );
            var initialSalary = Salary.Create(
                slate.Id,
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                10000,
                "DFSSiteID"
            );
            var updatedSalary = Salary.Create(
                slate.Id,
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                20000,
                "DFSSiteID"
            );

            // Act
            slate.AddSalary(initialSalary);
            slate.AddSalary(updatedSalary);

            // Assert
            var salary = slate.Salaries.FirstOrDefault(s => s.DFSSiteID == "DFSSiteID");
            Assert.IsNotNull(salary);
            var domainEvents = salary.PublishDomainEvents();
            Assert.IsTrue(domainEvents.Any(e => e is SalaryAmountUpdatedEvent));
        }

        [TestMethod]
        public void AddSalary_Should_NotAddNewSalary_When_SalaryAlreadyExistsForDFSSiteID()
        {
            // Arrange
            var slate = Slate.Create(
                DateTime.Now,
                Sport.NFL,
                GameType.Cash,
                DFSSite.DraftKings,
                "Test Slate"
            );
            var initialSalary = Salary.Create(
                slate.Id,
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                10000,
                "DFSSiteID"
            );
            var updatedSalary = Salary.Create(
                slate.Id,
                "PlayerName",
                new PlayerPosition[] { PlayerPosition.QB },
                Team.ARI,
                20000,
                "DFSSiteID"
            );
            slate.AddSalary(initialSalary);
            slate.PublishDomainEvents();

            // Act
            slate.AddSalary(updatedSalary);

            // Assert
            var domainEvents = slate.PublishDomainEvents();
            Assert.IsFalse(domainEvents.Any(e => e is SalaryAddedToSlateEvent));
        }

        #endregion

        #region ClearProjectionsFromSource

        private (Slate slate, List<Projection> projections) SetupForClearProjectionsFromSource(
            DateTime? date = null,
            Sport sport = Sport.NBA,
            GameType gameType = GameType.Cash,
            DFSSite dfsSite = DFSSite.DraftKings,
            string name = "TestSlate",
            List<(ProjectionSource source, string playerName, Team team)>? projectionData = null)
        {
            date ??= DateTime.Now;
            projectionData ??= new List<(ProjectionSource source, string playerName, Team team)>
            {
                (ProjectionSource.RotoGrinders, "Player1", Team.ATL),
                (ProjectionSource.RotoGrinders, "Player2", Team.BKN),
                (ProjectionSource.RotoGrinders, "Player3", Team.BOS)
            };

            var slate = Slate.Create(date.Value, sport, gameType, dfsSite, name);
            var projections = projectionData.Select(data =>
                Projection.Create(new SlateID(Guid.NewGuid()), data.source, data.playerName, data.team, new List<ProjectionData>())
            ).ToList();

            foreach (var projection in projections)
            {
                slate.AddProjection(projection);
            }

            return (slate, projections);
        }

        [TestMethod]
        public void ClearProjectionsFromSource_Should_RemoveProjectionsFromSpecifiedSource()
        {
            // Arrange
            var (slate, projections) = SetupForClearProjectionsFromSource();

            // Act
            slate.ClearProjectionsFromSource(ProjectionSource.RotoGrinders);

            // Assert
            Assert.IsFalse(slate.Projections.Any(p => p.ProjectionSource == ProjectionSource.RotoGrinders));
        }

        [TestMethod]
        public void ClearProjectionsFromSource_Should_NotRemoveProjectionsFromOtherSources()
        {
            // Arrange
            var projectionData = new List<(ProjectionSource source, string playerName, Team team)>
            {
                (ProjectionSource.RotoGrinders, "Player1", Team.ATL),
                (ProjectionSource.RotoGrinders, "Player2", Team.BKN),
                (ProjectionSource.RotoGrinders, "Player3", Team.BOS),
                ((ProjectionSource)999, "Player4", Team.CHA)
            };
            var (slate, projections) = SetupForClearProjectionsFromSource(projectionData: projectionData);

            // Act
            slate.ClearProjectionsFromSource(ProjectionSource.RotoGrinders);

            // Assert
            Assert.IsTrue(slate.Projections.Any(p => p.ProjectionSource == (ProjectionSource)999));
        }

        [TestMethod]
        public void ClearProjectionsFromSource_Should_NotThrow_When_NoProjectionsFromSpecifiedSource()
        {
            // Arrange
            var projectionData = new List<(ProjectionSource source, string playerName, Team team)>
            {
                ((ProjectionSource)999, "Player1", Team.ATL)
            };
            var (slate, projections) = SetupForClearProjectionsFromSource(projectionData: projectionData);

            // Act
            slate.ClearProjectionsFromSource(ProjectionSource.RotoGrinders);

            // Assert
            Assert.IsTrue(slate.Projections.Any(p => p.ProjectionSource == (ProjectionSource)999));
        }

        [TestMethod]
        public void ClearProjectionsFromSource_Should_AddProjectionRemovedFromSlateEventForEachRemovedProjection()
        {
            // Arrange
            var (slate, projections) = SetupForClearProjectionsFromSource();

            // Act
            slate.ClearProjectionsFromSource(ProjectionSource.RotoGrinders);
            var domainEvents = slate.PublishDomainEvents();

            // Assert
            Assert.AreEqual(3, domainEvents.Count(e => e is ProjectionRemovedFromSlateEvent));
        }

        #endregion

        #endregion
    }
}