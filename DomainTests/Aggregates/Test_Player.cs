using Common.Enums;

using Domain.Aggregates;
using Domain.Events.PlayerEvents;
using Domain.ValueTypes;

namespace DomainTests.Aggregates
{
    [TestClass]
    public class Test_Player
    {
        #region Setup

        private static SlateID DefaultSlateId => SlateID.CreateNew();
        private static string DefaultName => "Test Player";
        private static Team DefaultTeam => Team.ATL;
        private static Salary DefaultSalary => Salary.Create([PlayerPosition.PG], 5000, "123");
        private static TimeOnly DefaultStartTime => new TimeOnly(12, 0);

        private static Game CreateGame(
            SlateID? slateId = null,
            Team? homeTeam = null,
            Team? awayTeam = null,
            TimeOnly? startTime = null)
        {
            return Game.Create(
                slateId ?? DefaultSlateId,
                homeTeam ?? DefaultTeam,
                awayTeam ?? Team.BOS,
                startTime ?? DefaultStartTime
            );
        }

        private static Player CreatePlayer(
            string? name = null,
            Team? team = null,
            Salary? salary = null,
            Game? game = null)
        {
            return Player.Create(
                name ?? DefaultName,
                team ?? DefaultTeam,
                salary ?? DefaultSalary,
                game ?? CreateGame()
            );
        }

        private static Projection CreateProjection(
            ProjectionSource source = ProjectionSource.RotoGrinders,
            decimal value = 30)
        {
            return Projection.Create(
                source,
                [ProjectionData.Create(StatCategories.Floor, value)]
            );
        }

        #endregion

        #region Tests

        #region Create

        [TestMethod]
        public void Create_Should_SetName()
        {
            // Act
            var player = CreatePlayer(name: "Custom Name");

            // Assert
            Assert.AreEqual("Custom Name", player.Name);
        }

        [TestMethod]
        public void Create_Should_SetTeam()
        {
            // Act
            var player = CreatePlayer(team: Team.BOS);

            // Assert
            Assert.AreEqual(Team.BOS, player.Team);
        }

        [TestMethod]
        public void Create_Should_SetSalary()
        {
            // Arrange
            var salary = Salary.Create([PlayerPosition.SG], 8000, "456");

            // Act
            var player = CreatePlayer(salary: salary);

            // Assert
            Assert.AreEqual(salary, player.Salary);
        }

        [TestMethod]
        public void Create_Should_SetGameID()
        {
            // Arrange
            var game = CreateGame();

            // Act
            var player = CreatePlayer(game: game);

            // Assert
            Assert.AreEqual(game.Id, player.GameID);
        }

        [TestMethod]
        public void Create_Should_SetSlateID()
        {
            // Arrange
            var slateId = SlateID.CreateNew();
            var game = CreateGame(slateId: slateId);

            // Act
            var player = CreatePlayer(game: game);

            // Assert
            Assert.AreEqual(slateId, player.SlateID);
        }

        [TestMethod]
        public void Create_Should_AddPlayerCreatedEvent()
        {
            // Act
            var player = CreatePlayer();
            var events = player.PublishDomainEvents();

            // Assert
            Assert.IsTrue(events.Any(e => e is PlayerCreatedEvent));
        }

        #endregion

        #region UpdateSalary

        [TestMethod]
        public void UpdateSalary_Should_ChangeSalary()
        {
            // Arrange
            var player = CreatePlayer();
            var newSalary = Salary.Create([PlayerPosition.PG], 7000, "123");

            // Act
            player.UpdateSalary(newSalary);

            // Assert
            Assert.AreEqual(newSalary, player.Salary);
        }

        [TestMethod]
        public void UpdateSalary_Should_AddPlayerSalaryUpdatedEvent()
        {
            // Arrange
            var player = CreatePlayer();
            var newSalary = Salary.Create([PlayerPosition.PG], 7000, "123");

            // Act
            player.UpdateSalary(newSalary);
            var events = player.PublishDomainEvents();

            // Assert
            Assert.IsTrue(events.Any(e => e is PlayerSalaryUpdatedEvent));
        }

        #endregion

        #region SetProjection

        [TestMethod]
        public void SetProjection_Should_AddProjection_When_NoExistingProjectionWithSameSource()
        {
            // Arrange
            var player = CreatePlayer();
            var projection = CreateProjection(ProjectionSource.FootballGuys);

            // Act
            player.SetProjection(projection);

            // Assert
            Assert.AreEqual(1, player.Projections.Count);
            Assert.IsTrue(player.Projections.Contains(projection));
        }

        [TestMethod]
        public void SetProjection_Should_ReplaceProjection_When_ExistingProjectionWithSameSource()
        {
            // Arrange
            var player = CreatePlayer();
            var oldProjection = CreateProjection(ProjectionSource.RotoGrinders);
            var newProjection = CreateProjection(ProjectionSource.RotoGrinders);
            player.SetProjection(oldProjection);

            // Act
            player.SetProjection(newProjection);

            // Assert
            Assert.AreEqual(1, player.Projections.Count);
            Assert.AreEqual(newProjection, player.Projections.First());
        }

        [TestMethod]
        public void SetProjection_Should_OnlyReplaceMatchingSource_And_LeaveOthersUnchanged()
        {
            // Arrange
            var player = CreatePlayer();
            var rgProjection = CreateProjection(ProjectionSource.RotoGrinders);
            var fgProjection = CreateProjection(ProjectionSource.FootballGuys);
            player.SetProjection(rgProjection);
            player.SetProjection(fgProjection);

            var newFgProjection = CreateProjection(ProjectionSource.RotoGrinders);

            // Act
            player.SetProjection(newFgProjection);

            // Assert
            Assert.AreEqual(2, player.Projections.Count);
            Assert.IsTrue(player.Projections.SequenceEqual([fgProjection, newFgProjection]));
        }

        [TestMethod]
        public void SetProjection_Should_AddPlayerProjectionsUpdatedEvent()
        {
            // Arrange
            var player = CreatePlayer();
            var projection = CreateProjection();

            // Act
            player.SetProjection(projection);
            var events = player.PublishDomainEvents();

            // Assert
            Assert.IsTrue(events.Any(e => e is PlayerProjectionsUpdatedEvent));
        }

        #endregion

        #endregion
    }
}