using System;
using Domain.ValueTypes;
using Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace DomainTests.ValueTypes.EntityIDs
{
    [TestClass]
    public class Test_GameID
    {
        #region Helper Methods

        private static GameID CreateGameIDWithId(Team homeTeam, Team awayTeam, Guid id)
        {
            var ctor = typeof(GameID).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(Team), typeof(Team), typeof(Guid) },
                null
            );
            return (GameID)ctor?.Invoke(new object[] { homeTeam, awayTeam, id })!;
        }

        #endregion

        #region Tests

        #region CreateNew

        [TestMethod]
        public void CreateNew_Should_ReturnGameID()
        {
            // Arrange
            var homeTeam = Team.ARI;
            var awayTeam = Team.ATL;

            // Act
            var gameId = GameID.CreateNew(homeTeam, awayTeam);

            // Assert
            Assert.IsNotNull(gameId);
        }

        [TestMethod]
        public void CreateNew_Should_SetHomeTeamProperty()
        {
            // Arrange
            var homeTeam = Team.BAL;
            var awayTeam = Team.BUF;

            // Act
            var gameId = GameID.CreateNew(homeTeam, awayTeam);

            // Assert
            Assert.AreEqual(homeTeam, gameId.HomeTeam);
        }

        [TestMethod]
        public void CreateNew_Should_SetAwayTeamProperty()
        {
            // Arrange
            var homeTeam = Team.CAR;
            var awayTeam = Team.CHI;

            // Act
            var gameId = GameID.CreateNew(homeTeam, awayTeam);

            // Assert
            Assert.AreEqual(awayTeam, gameId.AwayTeam);
        }

        [TestMethod]
        public void CreateNew_Should_ThrowArgumentException_When_HomeAndAwayTeamsAreSame()
        {
            // Arrange
            var team = Team.DEN;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => GameID.CreateNew(team, team));
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_Should_ReturnTrue_When_InstancesHaveSameIdAndTeams()
        {
            // Arrange
            var homeTeam = Team.HOU;
            var awayTeam = Team.IND;
            var original = GameID.CreateNew(homeTeam, awayTeam);

            var other = CreateGameIDWithId(homeTeam, awayTeam, original.Id);

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_HomeTeamsDiffer()
        {
            // Arrange
            var id = Guid.NewGuid();
            var original = CreateGameIDWithId(Team.JAX, Team.KC, id);
            var other = CreateGameIDWithId(Team.LAC, Team.KC, id);

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_AwayTeamsDiffer()
        {
            // Arrange
            var id = Guid.NewGuid();
            var original = CreateGameIDWithId(Team.JAX, Team.KC, id);
            var other = CreateGameIDWithId(Team.JAX, Team.LAC, id);

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_IdsDiffer()
        {
            // Arrange
            var homeTeam = Team.JAX;
            var awayTeam = Team.KC;
            var original = CreateGameIDWithId(homeTeam, awayTeam, Guid.NewGuid());
            var other = CreateGameIDWithId(homeTeam, awayTeam, Guid.NewGuid());

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithNull()
        {
            // Arrange
            var homeTeam = Team.JAX;
            var awayTeam = Team.KC;
            var original = CreateGameIDWithId(homeTeam, awayTeam, Guid.NewGuid());

            // Act
            var areEqual = original.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithDifferentType()
        {
            // Arrange
            var homeTeam = Team.JAX;
            var awayTeam = Team.KC;
            var original = CreateGameIDWithId(homeTeam, awayTeam, Guid.NewGuid());
            var notAGameId = new object();

            // Act
            var areEqual = original.Equals(notAGameId);

            // Assert
            Assert.IsFalse(areEqual);
        }

        #endregion

        #endregion
    }
}