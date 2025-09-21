using System;
using Domain.ValueTypes;
using Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace DomainTests.ValueTypes.EntityIDs
{
    [TestClass]
    public class Test_PlayerID
    {
        #region Helper Methods

        private static SlateID CreateSlateID(Guid? id = null)
        {
            var ctor = typeof(SlateID).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(Guid) },
                null
            );
            return (SlateID)ctor?.Invoke(new object[] { id ?? Guid.NewGuid() })!;
        }

        private static PlayerID CreatePlayerIDWithId(SlateID slateId, string name, Team team, Guid id)
        {
            var ctor = typeof(PlayerID).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(SlateID), typeof(string), typeof(Team), typeof(Guid) },
                null
            );
            return (PlayerID)ctor?.Invoke(new object[] { slateId, name, team, id })!;
        }

        #endregion

        #region Tests

        #region CreateNew

        [TestMethod]
        public void CreateNew_Should_ReturnPlayerID()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "John Doe";
            var team = Team.ARI;

            // Act
            var playerId = PlayerID.CreateNew(slateId, name, team);

            // Assert
            Assert.IsNotNull(playerId);
        }

        [TestMethod]
        public void CreateNew_Should_SetSlateID()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var team = Team.BUF;

            // Act
            var playerId = PlayerID.CreateNew(slateId, name, team);

            // Assert
            Assert.AreEqual(slateId, playerId.SlateID);
        }

        [TestMethod]
        public void CreateNew_Should_SetName()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var team = Team.BUF;

            // Act
            var playerId = PlayerID.CreateNew(slateId, name, team);

            // Assert
            Assert.AreEqual(name, playerId.Name);
        }

        [TestMethod]
        public void CreateNew_Should_SetTeam()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var team = Team.BUF;

            // Act
            var playerId = PlayerID.CreateNew(slateId, name, team);

            // Assert
            Assert.AreEqual(team, playerId.Team);
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_Should_ReturnTrue_When_InstancesHaveSameIdAndProperties()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var team = Team.BUF;
            var id = Guid.NewGuid();

            var original = CreatePlayerIDWithId(slateId, name, team, id);
            var other = CreatePlayerIDWithId(slateId, name, team, id);

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_SlateIDsDiffer()
        {
            // Arrange
            var name = "Jane Smith";
            var team = Team.BUF;
            var id = Guid.NewGuid();

            var slateId1 = CreateSlateID(Guid.NewGuid());
            var slateId2 = CreateSlateID(Guid.NewGuid());

            var original = CreatePlayerIDWithId(slateId1, name, team, id);
            var other = CreatePlayerIDWithId(slateId2, name, team, id);

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_NamesDiffer()
        {
            // Arrange
            var slateId = CreateSlateID();
            var team = Team.BUF;
            var id = Guid.NewGuid();

            var original = CreatePlayerIDWithId(slateId, "Jane Smith", team, id);
            var other = CreatePlayerIDWithId(slateId, "John Doe", team, id);

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_TeamsDiffer()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var id = Guid.NewGuid();

            var original = CreatePlayerIDWithId(slateId, name, Team.BUF, id);
            var other = CreatePlayerIDWithId(slateId, name, Team.ARI, id);

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_IdsDiffer()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var team = Team.BUF;

            var original = CreatePlayerIDWithId(slateId, name, team, Guid.NewGuid());
            var other = CreatePlayerIDWithId(slateId, name, team, Guid.NewGuid());

            // Act
            var areEqual = original.Equals(other);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithNull()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var team = Team.BUF;
            var original = CreatePlayerIDWithId(slateId, name, team, Guid.NewGuid());

            // Act
            var areEqual = original.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithDifferentType()
        {
            // Arrange
            var slateId = CreateSlateID();
            var name = "Jane Smith";
            var team = Team.BUF;
            var original = CreatePlayerIDWithId(slateId, name, team, Guid.NewGuid());
            var notAPlayerId = new object();

            // Act
            var areEqual = original.Equals(notAPlayerId);

            // Assert
            Assert.IsFalse(areEqual);
        }

        #endregion

        #endregion
    }
}
