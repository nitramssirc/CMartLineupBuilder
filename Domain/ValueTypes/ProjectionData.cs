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

        #region Properties

        public StatCategories StatCategory { get; private set; }
        public decimal Value { get; private set; }

        #endregion

        #region Constructors

        private ProjectionData(StatCategories statCategory, decimal value)
        {
            StatCategory = statCategory;
            Value = value;
        }

        #endregion

        #region Factory Methods
        public static ProjectionData Create(StatCategories statCategory, decimal value)
        {
            return new ProjectionData(statCategory, value);
        }

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
