using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SlateAggregate.ValueTypes
{
    public class PlayerID : EntityID
    {
        public PlayerID(Guid id) : base(id)
        {
        }
        public PlayerID() : base(Guid.NewGuid())
        {
        }
        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            return new List<object>();
        }
    }
}
