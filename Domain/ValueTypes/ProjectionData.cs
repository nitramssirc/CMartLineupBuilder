using Common.Enums;

using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueTypes
{
    public class ProjectionData : ValueObject
    {
        #region Constructors

        private ProjectionData()
        {
        }

        public ProjectionData(StatCategories statCategory, decimal value)
        {
            StatCategory = statCategory;
            Value = value;
        }

        #endregion

        #region Properties

        public StatCategories StatCategory { get; private set; }
        public decimal Value { get; private set; }

        #endregion

        #region Value Object Implementation

        override protected IEnumerable<object> GetEqualityComponents()
        {
            yield return StatCategory;
            yield return Value;
        }

        #endregion
    }

}
