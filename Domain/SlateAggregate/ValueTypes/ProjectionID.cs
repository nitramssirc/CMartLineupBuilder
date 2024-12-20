using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SlateAggregate.ValueTypes
{
    public class ProjectionID: EntityID
    {
        public ProjectionID(Guid id) : base(id)
        {
        }
        public ProjectionID() : base(Guid.NewGuid())
        {
        }
        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            return new List<object>();
        }
    }
}
