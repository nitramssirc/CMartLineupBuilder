using Common.Enums;

using Domain.Common.Models;
using Domain.SlateAggregate.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SlateAggregate.Models
{
    public class Salary : Entity<SalaryID>
    {
        #region Properties

        public SlateID SlateID { get; private set; }
        public PlayerID PlayerID { get; private set; }
        public PlayerPosition[] Positions { get; private set; }
        public Team Team { get; private set; }
        public int SalaryAmount { get; private set; }
        public string DFSSiteID { get; private set; }

        #endregion

        #region Constructor

        private Salary() : base(new SalaryID())
        {
            SlateID = new SlateID();
            PlayerID = new PlayerID();
            Positions = Array.Empty<PlayerPosition>();
            DFSSiteID = string.Empty;
        }

        private Salary(
            SalaryID id,
            SlateID slateID,
            PlayerID playerID,
            PlayerPosition[] positions,
            Team team,
            int salaryAmount,
            string dfsSiteID) : base(id)
        {
            SlateID = slateID;
            PlayerID = playerID;
            Positions = positions;
            Team = team;
            SalaryAmount = salaryAmount;
            DFSSiteID = dfsSiteID;
        }

        #endregion

        #region Factory Methods

        public static Salary Create(
            SlateID slateID,
            PlayerID playerID,
            PlayerPosition[] positions,
            Team team,
            int salaryAmount,
            string dfsSiteID)
        {
            return new Salary(new SalaryID(), slateID, playerID, positions, team, salaryAmount, dfsSiteID);
        }

        public static Salary Create(
            SlateID slateID,
            PlayerID playerID,
            string positions,
            string team,
            int salaryAmount,
            string dfsSiteID)
        {
            var salaryPositions = ParsePositions(positions);
            var salaryTeam = ParseTeam(team);
            return Create(slateID, playerID, salaryPositions, salaryTeam, salaryAmount, dfsSiteID);
        }

        #endregion

        #region Private Methods

        private static PlayerPosition[] ParsePositions(string positions)
        {
            var positionStrings = positions.Split('/');
            var playerPositions = new List<PlayerPosition>();
            foreach (var position in positionStrings)
            {
                if (Enum.TryParse(position, out PlayerPosition playerPosition))
                {
                    playerPositions.Add(playerPosition);
                }
            }
            return playerPositions.ToArray();
        }

        private static Team ParseTeam(string team)
        {
            if (Enum.TryParse(team, out Team parsedTeam))
            {
                return parsedTeam;
            }
            return Team.UNKNOWN;
        }

        #endregion

    }
}
