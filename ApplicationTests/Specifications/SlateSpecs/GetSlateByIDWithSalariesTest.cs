using Application.Specifications.SlateSpecs;
using Domain.Entities;
using Domain.ValueTypes;
using System.Linq.Expressions;
using Common.Enums;

namespace Application.Specifications.Tests.SlateSpecs
{
    [TestClass()]
    public class GetSlateByIDWithSalariesTests
    {
        #region Tests

        #region Expression

        [TestMethod]
        public void Expression_Should_FilterBySlateID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var specification = new GetSlateByIDWithSalariesSpec(slateID);

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
        public void Includes_Should_ContainSalaries()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var specification = new GetSlateByIDWithSalariesSpec(slateID);

            // Act
            var includes = specification.Includes;

            // Assert
            Assert.IsTrue(includes.Any(include => include.Body is MemberExpression member && member.Member.Name == nameof(Slate.Salaries)));
        }

        #endregion

        #endregion
    }
}


