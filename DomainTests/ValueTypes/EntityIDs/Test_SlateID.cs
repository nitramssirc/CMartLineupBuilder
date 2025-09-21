using Domain.ValueTypes;

using System.Reflection;

namespace DomainTests.ValueTypes.EntityIDs
{
    [TestClass]
    public class Test_SlateID
    {
        #region Helper Methods

        private static SlateID CreateSlateIDWithId(Guid id)
        {
            var ctor = typeof(SlateID).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(Guid) },
                null
            );
            return (SlateID)ctor?.Invoke(new object[] { id })!;
        }

        #endregion

        #region Tests

        #region CreateNew

        [TestMethod]
        public void CreateNew_Should_ReturnSlateID()
        {
            // Arrange & Act
            var slateId = SlateID.CreateNew();

            // Assert
            Assert.IsNotNull(slateId);
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_Should_ReturnTrue_When_InstancesHaveSameId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var slateId1 = CreateSlateIDWithId(id);
            var slateId2 = CreateSlateIDWithId(id);

            // Act
            var areEqual = slateId1.Equals(slateId2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_IdsDiffer()
        {
            // Arrange
            var slateId1 = CreateSlateIDWithId(Guid.NewGuid());
            var slateId2 = CreateSlateIDWithId(Guid.NewGuid());

            // Act
            var areEqual = slateId1.Equals(slateId2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithNull()
        {
            // Arrange
            var slateId = CreateSlateIDWithId(Guid.NewGuid());

            // Act
            var areEqual = slateId.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithDifferentType()
        {
            // Arrange
            var slateId = CreateSlateIDWithId(Guid.NewGuid());
            var notASlateId = new object();

            // Act
            var areEqual = slateId.Equals(notASlateId);

            // Assert
            Assert.IsFalse(areEqual);
        }

        #endregion

        #endregion
    }
}
