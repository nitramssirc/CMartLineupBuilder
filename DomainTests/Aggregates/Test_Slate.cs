using Domain.Aggregates;
using Common.Enums;
using Domain.Events.SlateEvents;

namespace DomainTests.Aggregates
{
    [TestClass]
    public class Test_Slate
    {
        #region Setup

        private Slate CreateSlate(
            DateTime? date = null,
            Sport? sport = null,
            GameType? gameType = null,
            DFSSite? dfsSite = null,
            string? name = null)
        {
            var defaultDate = new DateTime(2025, 1, 1);
            const Sport defaultSport = Sport.NFL;
            const GameType defaultGameType = GameType.Cash;
            const DFSSite defaultDFSSite = DFSSite.DraftKings;
            const string defaultName = "Main Slate";

            return Slate.Create(
                date ?? defaultDate,
                sport ?? defaultSport,
                gameType ?? defaultGameType,
                dfsSite ?? defaultDFSSite,
                name ?? defaultName
            );
        }

        #endregion

        #region Tests

        #region Create

        [TestMethod]
        public void Create_Should_PublishSlateCreatedEvent()
        {
            // Arrange
            var slate = CreateSlate();

            // Act
            var events = slate.PublishDomainEvents();

            // Assert
            Assert.IsTrue(events.OfType<SlateCreatedEvent>().Any());
        }

        [TestMethod]
        public void Create_Should_SetDate()
        {
            var expectedDate = new DateTime(2024, 12, 25);
            var slate = CreateSlate(date: expectedDate);
            Assert.AreEqual(expectedDate, slate.Date);
        }

        [TestMethod]
        public void Create_Should_SetSport()
        {
            var expectedSport = Sport.NBA;
            var slate = CreateSlate(sport: expectedSport);
            Assert.AreEqual(expectedSport, slate.Sport);
        }

        [TestMethod]
        public void Create_Should_SetGameType()
        {
            var expectedGameType = GameType.GPP;
            var slate = CreateSlate(gameType: expectedGameType);
            Assert.AreEqual(expectedGameType, slate.GameType);
        }

        [TestMethod]
        public void Create_Should_SetDFSSite()
        {
            var expectedDFSSite = DFSSite.FanDuel;
            var slate = CreateSlate(dfsSite: expectedDFSSite);
            Assert.AreEqual(expectedDFSSite, slate.DFSSite);
        }

        [TestMethod]
        public void Create_Should_SetName()
        {
            var expectedName = "Late Night Slate";
            var slate = CreateSlate(name: expectedName);
            Assert.AreEqual(expectedName, slate.Name);
        }

        #endregion

        #endregion
    }
}