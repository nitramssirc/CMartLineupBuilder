using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.ValueTypes;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.Commands.AddProjections.NBARotoGrinders;

namespace Application.Tests.Commands.AddProjections
{
    [TestClass]
    public class AddRotoGrindersNBAProjectionsTests
    {
        #region Tests

        #region ProjectionSource

        [TestMethod]
        public void ProjectionSource_Should_ReturnRotoGrinders()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, new List<RotoGrindersNBAProjection>());
            // Act
            var result = addProjections.ProjectionSource;
            // Assert
            Assert.AreEqual(ProjectionSource.RotoGrinders, result);
        }

        #endregion

        #region GetProjections

        private RotoGrindersNBAProjection CreateRotoGrindersNBAProjection(
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
            return new RotoGrindersNBAProjection(
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
        public void GetProjections_Should_ReturnProjectionDTOForEachRotoGrindersNBAProjection()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(),
                CreateRotoGrindersNBAProjection(player_id: 2, team: "BKN", name: "Player2")
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().ToList();

            // Assert
            Assert.AreEqual(projections.Count, result.Count);
        }

        [TestMethod]
        public void GetProjections_Should_SetProjectionSourceToRotoGrinders()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection()
            };

            // Act
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);


            // Assert
            Assert.IsTrue(addProjections.ProjectionSource == ProjectionSource.RotoGrinders);
        }

        [TestMethod]
        public void GetProjection_Should_SetPlayerNameToName()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(name: "Player1")
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.AreEqual("Player1", result.PlayerName);
        }

        [TestMethod]
        public void GetProjection_Should_ParseTeamNameFromTeam()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(team: "ATL")
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.AreEqual(Team.ATL, result.Team);
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForPlayerID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(player_id: 1)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.PlayerId && d.Value == 1));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForOpponent()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(opp: "BOS")
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.Opponent && d.Value == (decimal)Team.BOS));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForFantasyPoints()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(fpts: 50)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.FantasyPoints && d.Value == 50));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForProjectedOwnership()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(proj_own: 20)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.ProjectedOwnership && d.Value == 20));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForSmash()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(smash: 10)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.Smash && d.Value == 10));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForOpprotunityPct()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(opto_pct: 30)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.OpprotunityPct && d.Value == 30));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForMinutes()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(minutes: 35)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.Minutes && d.Value == 35));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForCeiling()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(ceil: 60)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.Ceiling && d.Value == 60));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForFloor()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(floor: 40)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.Floor && d.Value == 40));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForMinExposure()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(min_exposure: 10)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.MinExposure && d.Value == 10));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForMaxExposure()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(max_exposure: 50)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.MaxExposure && d.Value == 50));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForRotoGrindersValue()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(rg_value: 5)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.RotoGrindersValue && d.Value == 5));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForRotoGrindersID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(rg_id: 1001)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.RotoGrindersID && d.Value == 1001));
        }

        [TestMethod]
        public void GetProjection_Should_HaveProjectionDataForPartnerID()
        {
            // Arrange
            var slateID = new SlateID(Guid.NewGuid());
            var projections = new List<RotoGrindersNBAProjection>
            {
                CreateRotoGrindersNBAProjection(partner_id: 2001)
            };
            var addProjections = new AddRotoGrindersNBAProjectionsCommand(slateID, projections);

            // Act
            var result = addProjections.GetProjections().First();

            // Assert
            Assert.IsTrue(result.Data.Any(d => d.StatCategory == StatCategories.PartnerID && d.Value == 2001));
        }

        #endregion

        #endregion
    }
}


