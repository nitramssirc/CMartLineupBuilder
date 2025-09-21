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

        private Salary(
            PlayerPosition[] positions,
            int salaryAmount,
            string dfsSiteID)
        {
            Positions = positions;
            SalaryAmount = salaryAmount;
            DFSSiteID = dfsSiteID;
        }

        #endregion

        #region Factory Methods

        public static Salary Create(
            PlayerPosition[] positions,
            int salaryAmount,
            string dfsSiteID)
        {
            return new Salary(positions, salaryAmount, dfsSiteID);
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
