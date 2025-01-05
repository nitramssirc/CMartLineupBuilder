using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Domain.Entities;

namespace Domain.Events.Tests
{
    [TestClass()]
    public class SlateCreatedEventTests
    {
        #region Tests

        #region ToString

        [TestMethod]
        public void ToString_Should_ReturnCorrectString()
        {
            // Arrange
            var slate = Slate.Create(
                DateTime.Now,
                Sport.NFL,
                GameType.Cash,
                DFSSite.DraftKings,
                "Test Slate"
            );
            var slateCreatedEvent = new SlateCreatedEvent(slate);

            // Act
            var result = slateCreatedEvent.ToString();

            // Assert
            var expected = $"SlateCreatedEvent: {slate.Name} - {slate.Date} - {slate.Sport} - {slate.GameType} - {slate.DFSSite}";
            Assert.AreEqual(expected, result);
        }

        #endregion

        #endregion
    }
}