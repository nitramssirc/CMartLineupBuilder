using System;
using System.Linq;
using Domain.ValueTypes;
using Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests.ValueTypes
{
    [TestClass]
    public class Test_Salary
    {
        #region Tests

        #region Create

        [TestMethod]
        public void Create_Should_ReturnSalary()
        {
            // Arrange
            var positions = new[] { PlayerPosition.QB, PlayerPosition.WR };
            var salaryAmount = 5000;
            var dfsSiteID = "12345";

            // Act
            var salary = Salary.Create(positions, salaryAmount, dfsSiteID);

            // Assert
            Assert.IsNotNull(salary);
        }

        [TestMethod]
        public void Create_Should_SetPositions()
        {
            // Arrange
            var positions = new[] { PlayerPosition.RB, PlayerPosition.WR };
            var salaryAmount = 6000;
            var dfsSiteID = "siteA";

            // Act
            var salary = Salary.Create(positions, salaryAmount, dfsSiteID);

            // Assert
            CollectionAssert.AreEqual(positions, salary.Positions);
        }

        [TestMethod]
        public void Create_Should_SetSalaryAmount()
        {
            // Arrange
            var positions = new[] { PlayerPosition.TE };
            var salaryAmount = 7000;
            var dfsSiteID = "siteB";

            // Act
            var salary = Salary.Create(positions, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(salaryAmount, salary.SalaryAmount);
        }

        [TestMethod]
        public void Create_Should_SetDFSSiteID()
        {
            // Arrange
            var positions = new[] { PlayerPosition.K };
            var salaryAmount = 8000;
            var dfsSiteID = "siteC";

            // Act
            var salary = Salary.Create(positions, salaryAmount, dfsSiteID);

            // Assert
            Assert.AreEqual(dfsSiteID, salary.DFSSiteID);
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_Should_ReturnTrue_When_InstancesHaveSameProperties()
        {
            // Arrange
            var positions = new[] { PlayerPosition.QB, PlayerPosition.WR };
            var salaryAmount = 9000;
            var dfsSiteID = "siteD";

            var salary1 = Salary.Create(positions, salaryAmount, dfsSiteID);
            var salary2 = Salary.Create(positions, salaryAmount, dfsSiteID);

            // Act
            var areEqual = salary1.Equals(salary2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_PositionsDiffer()
        {
            // Arrange
            var salaryAmount = 9000;
            var dfsSiteID = "siteD";

            var salary1 = Salary.Create(new[] { PlayerPosition.QB, PlayerPosition.WR }, salaryAmount, dfsSiteID);
            var salary2 = Salary.Create(new[] { PlayerPosition.RB, PlayerPosition.WR }, salaryAmount, dfsSiteID);

            // Act
            var areEqual = salary1.Equals(salary2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_SalaryAmountDiffers()
        {
            // Arrange
            var positions = new[] { PlayerPosition.QB, PlayerPosition.WR };
            var dfsSiteID = "siteD";

            var salary1 = Salary.Create(positions, 9000, dfsSiteID);
            var salary2 = Salary.Create(positions, 9500, dfsSiteID);

            // Act
            var areEqual = salary1.Equals(salary2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_DFSSiteIDDiffers()
        {
            // Arrange
            var positions = new[] { PlayerPosition.QB, PlayerPosition.WR };
            var salaryAmount = 9000;

            var salary1 = Salary.Create(positions, salaryAmount, "siteD");
            var salary2 = Salary.Create(positions, salaryAmount, "siteE");

            // Act
            var areEqual = salary1.Equals(salary2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithNull()
        {
            // Arrange
            var positions = new[] { PlayerPosition.QB };
            var salaryAmount = 5000;
            var dfsSiteID = "siteF";
            var salary = Salary.Create(positions, salaryAmount, dfsSiteID);

            // Act
            var areEqual = salary.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_Should_ReturnFalse_When_ComparedWithDifferentType()
        {
            // Arrange
            var positions = new[] { PlayerPosition.QB };
            var salaryAmount = 5000;
            var dfsSiteID = "siteF";
            var salary = Salary.Create(positions, salaryAmount, dfsSiteID);
            var notASalary = new object();

            // Act
            var areEqual = salary.Equals(notASalary);

            // Assert
            Assert.IsFalse(areEqual);
        }

        #endregion

        #endregion
    }
}
