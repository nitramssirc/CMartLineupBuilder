using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SlateAggregate.ValueTypes
{
    public class ProjectionData: ValueObject
    {
        #region Constructors

        private ProjectionData()
        {
            Name = string.Empty;
            Value = 0;
        }

        public ProjectionData(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public decimal Value { get; private set; }

        #endregion

        #region Value Object Implementation

        override protected IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Value;
        }

        #endregion
    }

}
