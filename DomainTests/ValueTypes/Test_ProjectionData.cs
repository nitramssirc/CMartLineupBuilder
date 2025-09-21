using Domain.ValueTypes;
using Common.Enums;

namespace DomainTests.ValueTypes
{
    [TestClass]
    public class Test_ProjectionData
    {
        #region Tests

        #region Create

        [TestMethod]
        public void Create_Should_ReturnProjectionData()
        {
            // Arrange
            var statCategory = StatCategories.PassingYards;
            var value = 300m;

            // Act
            var projectionData = ProjectionData.Create(statCategory, value);

            // Assert
            Assert.IsNotNull(projectionData);
        }

        [TestMethod]
        public void Create_Should_SetStatCategory()
        {
            // Arrange
            var statCategory = StatCategories.RushingYards;
            var value = 120m;

            // Act
            var projectionData = ProjectionData.Create(statCategory, value);

            // Assert
            Assert.AreEqual(statCategory, projectionData.StatCategory);
        }

        [TestMethod]
        public void Create_Should_SetValue()
        {
            // Arrange
            var statCategory = StatCategories.ReceivingYards;
            var value = 88.5m;

            // Act
            var projectionData = ProjectionData.Create(statCategory, value);

            // Assert
            Assert.AreEqual(value, projectionData.Value);
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_Should_ReturnTrue_When_InstancesHaveSameStatCategoryAndValue()
        {
            // Arrange
            var statCategory = StatCategories.RushingYards;
            var value = 120m;
            var pd1 = ProjectionData.Create(statCategory, value);
            var pd2 = ProjectionData.Create(statCategory, value);

            // Act
            var areEqual = pd1.Equals(pd2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_StatCategoriesDiffer()
        {
            // Arrange
            var value = 120m;
            var pd1 = ProjectionData.Create(StatCategories.RushingYards, value);
            var pd2 = ProjectionData.Create(StatCategories.ReceivingYards, value);

            // Act
            var areEqual = pd1.Equals(pd2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ValuesDiffer()
        {
            // Arrange
            var statCategory = StatCategories.RushingYards;
            var pd1 = ProjectionData.Create(statCategory, 120m);
            var pd2 = ProjectionData.Create(statCategory, 130m);

            // Act
            var areEqual = pd1.Equals(pd2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithNull()
        {
            // Arrange
            var pd1 = ProjectionData.Create(StatCategories.RushingYards, 120m);

            // Act
            var areEqual = pd1.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithDifferentType()
        {
            // Arrange
            var pd1 = ProjectionData.Create(StatCategories.RushingYards, 120m);
            var notAProjectionData = new object();

            // Act
            var areEqual = pd1.Equals(notAProjectionData);

            // Assert
            Assert.IsFalse(areEqual);
        }

        #endregion

        #endregion
    }
}
