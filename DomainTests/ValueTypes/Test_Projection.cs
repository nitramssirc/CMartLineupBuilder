using Domain.ValueTypes;
using Common.Enums;
using System.Reflection;

namespace DomainTests.ValueTypes
{
    [TestClass]
    public class Test_Projection
    {
        #region Helper Methods

        private static ProjectionData CreateProjectionData(StatCategories statCategory, decimal value)
        {
            var ctor = typeof(ProjectionData).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(StatCategories), typeof(decimal) },
                null
            );
            return (ProjectionData)ctor?.Invoke(new object[] { statCategory, value })!;
        }

        #endregion

        #region Tests

        #region Create

        [TestMethod]
        public void Create_Should_ReturnProjection()
        {
            // Arrange
            var source = ProjectionSource.RotoGrinders;
            var data = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.PassingYards, 250m),
                CreateProjectionData(StatCategories.PassingTouchdowns, 2m)
            };

            // Act
            var projection = Projection.Create(source, data);

            // Assert
            Assert.IsNotNull(projection);
        }

        [TestMethod]
        public void Create_Should_SetProjectionSource()
        {
            // Arrange
            var source = ProjectionSource.FootballGuys;
            var data = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.RushingYards, 100m)
            };

            // Act
            var projection = Projection.Create(source, data);

            // Assert
            Assert.AreEqual(source, projection.ProjectionSource);
        }

        [TestMethod]
        public void Create_Should_SetData()
        {
            // Arrange
            var source = ProjectionSource.FootballGuys;
            var data = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.RushingYards, 100m),
                CreateProjectionData(StatCategories.RushingTouchdowns, 1m)
            };

            // Act
            var projection = Projection.Create(source, data);

            // Assert
            CollectionAssert.AreEqual(data, new List<ProjectionData>(projection.Data));
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_Should_ReturnTrue_When_InstancesHaveSameSourceAndData()
        {
            // Arrange
            var source = ProjectionSource.FootballGuys;
            var data = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.RushingYards, 100m),
                CreateProjectionData(StatCategories.RushingTouchdowns, 1m)
            };

            var projection1 = Projection.Create(source, data);
            var projection2 = Projection.Create(source, data);

            // Act
            var areEqual = projection1.Equals(projection2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_SourcesDiffer()
        {
            // Arrange
            var data = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.ReceivingYards, 80m)
            };

            var projection1 = Projection.Create(ProjectionSource.RotoGrinders, data);
            var projection2 = Projection.Create(ProjectionSource.FootballGuys, data);

            // Act
            var areEqual = projection1.Equals(projection2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_DataDiffer()
        {
            // Arrange
            var source = ProjectionSource.RotoGrinders;
            var data1 = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.FantasyPoints, 20m)
            };
            var data2 = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.FantasyPoints, 25m)
            };

            var projection1 = Projection.Create(source, data1);
            var projection2 = Projection.Create(source, data2);

            // Act
            var areEqual = projection1.Equals(projection2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithNull()
        {
            // Arrange
            var source = ProjectionSource.RotoGrinders;
            var data = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.PassingYards, 300m)
            };
            var projection = Projection.Create(source, data);

            // Act
            var areEqual = projection.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithDifferentType()
        {
            // Arrange
            var source = ProjectionSource.RotoGrinders;
            var data = new List<ProjectionData>
            {
                CreateProjectionData(StatCategories.PassingYards, 300m)
            };
            var projection = Projection.Create(source, data);
            var notAProjection = new object();

            // Act
            var areEqual = projection.Equals(notAProjection);

            // Assert
            Assert.IsFalse(areEqual);
        }

        #endregion

        #endregion
    }
}
