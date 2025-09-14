using Common.Enums;

using Domain.Common.ValueTypes;

namespace Domain.ValueTypes
{
    public class Salary : ValueObject
    {
        #region Properties

        public PlayerPosition[] Positions { get; private set; }
        public int SalaryAmount { get; private set; }
        public string DFSSiteID { get; private set; }

        #endregion

        #region Constructor

        internal Salary() 
        {
            Positions = Array.Empty<PlayerPosition>();
            SalaryAmount = 0;
            DFSSiteID = string.Empty;
        }

        private Salary(
            PlayerPosition[] positions,
            int salaryAmount,
            string dfsSiteID)
        {
            Positions = positions;
            SalaryAmount = salaryAmount;
            DFSSiteID = dfsSiteID;
        }

        private Salary(
            string positions,
            int salaryAmount,
            string dfsSiteID)
        {
            Positions = ParsePositions(positions);
            SalaryAmount = salaryAmount;
            DFSSiteID = dfsSiteID;
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

        #endregion

        #region Value Object Implementation

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return string.Join("/", Positions.OrderBy(p => p).Select(p => p.ToString()));
            yield return SalaryAmount;
            yield return DFSSiteID;
        }

        #endregion

    }
}
