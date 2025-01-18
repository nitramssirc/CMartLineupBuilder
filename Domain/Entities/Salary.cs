using Common.Enums;

using Domain.Common.Entities;
using Domain.Events;
using Domain.Events.SalaryEvents;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Salary : Entity<SalaryID>
    {
        #region Properties

        public SlateID SlateID { get; private set; }
        public string PlayerName { get; private set; }
        public PlayerPosition[] Positions { get; private set; }
        public Team Team { get; private set; }
        public int SalaryAmount { get; private set; }
        public string DFSSiteID { get; private set; }

        #endregion

        #region Constructor

        private Salary() : base(new SalaryID())
        {
            SlateID = new SlateID();
            PlayerName = string.Empty;
            Positions = Array.Empty<PlayerPosition>();
            DFSSiteID = string.Empty;
        }

        private Salary(
            SalaryID id,
            SlateID slateID,
            string playerName,
            PlayerPosition[] positions,
            Team team,
            int salaryAmount,
            string dfsSiteID) : base(id)
        {
            SlateID = slateID;
            PlayerName = playerName;
            Positions = positions;
            Team = team;
            SalaryAmount = salaryAmount;
            DFSSiteID = dfsSiteID;
        }

        #endregion

        #region Factory Methods

        public static Salary Create(
            SlateID slateID,
            string playerName,
            PlayerPosition[] positions,
            Team team,
            int salaryAmount,
            string dfsSiteID)
        {
            var newSalary = new Salary(new SalaryID(), slateID, playerName, positions, team, salaryAmount, dfsSiteID);
            newSalary.AddDomainEvent(new SalaryCreatedEvent(newSalary.Id, slateID, playerName, positions, team, salaryAmount, dfsSiteID));
            return newSalary;
        }

        public static Salary Create(
            SlateID slateID,
            string playerName,
            string positions,
            string team,
            int salaryAmount,
            string dfsSiteID)
        {
            var salaryPositions = ParsePositions(positions);
            var salaryTeam = ParseTeam(team);
            return Create(slateID, playerName, salaryPositions, salaryTeam, salaryAmount, dfsSiteID);
        }

        #endregion

        #region Update Methods

        public void UpdateSalaryAmount(int salaryAmount)
        {
            if (salaryAmount == SalaryAmount)
            {
                return;
            }

            SalaryAmount = salaryAmount;
            AddDomainEvent(new SalaryAmountUpdatedEvent(this));
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
