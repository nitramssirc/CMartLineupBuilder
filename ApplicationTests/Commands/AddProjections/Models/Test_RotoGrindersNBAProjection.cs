using Domain.ValueTypes;
using Common.Enums;
using Application.Commands.AddProjections.Models;

namespace ApplicationTests.Commands.AddProjections.Models
{
    [TestClass]
    public class Test_RotoGrindersNBAUploadedProjection
    {
        #region Tests

        #region Name

        [TestMethod]
        public void Name_Should_ReturnNameField()
        {
            //Arrange
            var projection = CreateRotoGrindersNBAProjection(name: "Player1");

            //Act
            var name = projection.Name;

            //Assert
            Assert.AreEqual("Player1", name);
        }

        #endregion

        #region Team

        [TestMethod]
        public void Team_Should_ParseTeamField()
        {
            //Arrange
            var projection = CreateRotoGrindersNBAProjection(team: "ATL");
            //Act
            var team = projection.Team;
            //Assert
            Assert.AreEqual(Team.ATL, team);
        }

        #endregion


        #region ProjectionData

        private RotoGrindersNBAUploadedProjection CreateRotoGrindersNBAProjection(
            int player_id = 1,
            string team = "ATL",
            string opp = "BOS",
            string pos = "PG",
            string name = "Player1",
            decimal fpts = 50,
            decimal proj_own = 20,
            decimal smash = 10,
            decimal opto_pct = 30,
            int minutes = 35,
            decimal ceil = 60,
            decimal floor = 40,
            decimal min_exposure = 10,
            decimal max_exposure = 50,
            decimal rg_value = 5,
            int salary = 8000,
            string custom = "",
            int rg_id = 1001,
            int partner_id = 2001)
        {
            return new RotoGrindersNBAUploadedProjection(
                player_id,
                team,
                opp,
                pos,
                name,
                fpts,
                proj_own,
                smash,
                opto_pct,
                minutes,
                ceil,
                floor,
                min_exposure,
                max_exposure,
                rg_value,
                salary,
                custom,
                rg_id,
                partner_id);
        }


        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForPlayerID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(player_id: 1);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.PlayerId && d.Value == 1));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForOpponent()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(opp: "BOS");

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.Opponent && d.Value == (decimal)Team.BOS));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForFantasyPoints()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(fpts: 50);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.FantasyPoints && d.Value == 50));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForProjectedOwnership()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(proj_own: 20);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.ProjectedOwnership && d.Value == 20));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForSmash()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(smash: 10);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.Smash && d.Value == 10));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForOpprotunityPct()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(opto_pct: 30);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.OpprotunityPct && d.Value == 30));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForMinutes()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(minutes: 35);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.Minutes && d.Value == 35));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForCeiling()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(ceil: 60);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.Ceiling && d.Value == 60));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForFloor()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(floor: 40);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.Floor && d.Value == 40));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForMinExposure()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(min_exposure: 10);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.MinExposure && d.Value == 10));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForMaxExposure()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(max_exposure: 50);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.MaxExposure && d.Value == 50));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForRotoGrindersValue()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(rg_value: 5);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.RotoGrindersValue && d.Value == 5));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForRotoGrindersID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(rg_id: 1001);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.RotoGrindersID && d.Value == 1001));
        }

        [TestMethod]
        public void ProjectionData_Should_HaveProjectionDataForPartnerID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projection = CreateRotoGrindersNBAProjection(partner_id: 2001);

            // Act
            var result = projection.ProjectionData;

            // Assert
            Assert.IsTrue(result.Any(d => d.StatCategory == StatCategories.PartnerID && d.Value == 2001));
        }

        #endregion

        #endregion
    }
}


