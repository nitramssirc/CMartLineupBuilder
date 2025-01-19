using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Specifications.SlateSpecs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Domain.Entities;
using Domain.ValueTypes;
using System.Linq.Expressions;

namespace Application.Specifications.SlateSpecs.Tests
{
    [TestClass()]
    public class GetSlateByIDTests
    {
        #region Tests

        #region Expression

        [TestMethod]
        public void Expression_Should_FilterBySlateID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var specification = new GetSlateByID(slateID);

            // Act
            Expression<Func<Slate, bool>> expression = specification.Expression;
            var compiledExpression = expression.Compile();
            var slate = new Slate(slateID, DateTime.Now, Sport.NFL, GameType.Cash, DFSSite.DraftKings, "Test Slate");

            // Assert
            Assert.IsTrue(compiledExpression(slate));
        }

        #endregion

        #region Includes

        [TestMethod]
        public void Includes_Should_BeEmpty()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var specification = new GetSlateByID(slateID);

            // Act
            var includes = specification.Includes;

            // Assert
            Assert.IsTrue(includes.Count == 0);
        }

        #endregion

        #endregion

    }
}