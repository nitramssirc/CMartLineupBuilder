using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using Application.Specifications.SlateSpecs;
using Common.Enums;
using Domain.Entities;

namespace Application.Tests.Specifications.SlateSpecs
{
    [TestClass]
    public class GetSlatesByDFSSiteAndSportTests
    {
        #region Tests

        #region Expression

        private (GetSlatesByDFSSiteAndSportSpec spec, Slate slate) SetupForExpression(
            DFSSite site = DFSSite.DraftKings,
            Sport sport = Sport.NFL,
            DFSSite slateSite = DFSSite.DraftKings,
            Sport slateSport = Sport.NFL)
        {
            var spec = new GetSlatesByDFSSiteAndSportSpec(site, sport);
            var slate = Slate.Create(DateTime.Now, slateSport, GameType.Cash, slateSite, "Test Slate");
            return (spec, slate);
        }

        [TestMethod]
        public void Expression_Should_ReturnTrue_When_SlateMatchesSiteAndSport()
        {
            // Arrange
            var (spec, slate) = SetupForExpression();

            // Act
            var result = spec.Expression.Compile().Invoke(slate);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Expression_Should_ReturnFalse_When_SlateDoesNotMatchSite()
        {
            // Arrange
            var (spec, slate) = SetupForExpression(slateSite: DFSSite.FanDuel);

            // Act
            var result = spec.Expression.Compile().Invoke(slate);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Expression_Should_ReturnFalse_When_SlateDoesNotMatchSport()
        {
            // Arrange
            var (spec, slate) = SetupForExpression(slateSport: Sport.NBA);

            // Act
            var result = spec.Expression.Compile().Invoke(slate);

            // Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region Includes

        [TestMethod]
        public void Includes_Should_BeEmpty()
        {
            // Arrange
            var spec = new GetSlatesByDFSSiteAndSportSpec(DFSSite.DraftKings, Sport.NFL);

            // Act
            var includes = spec.Includes;

            // Assert
            Assert.AreEqual(0, includes.Count);
        }

        #endregion

        #endregion
    }
}
