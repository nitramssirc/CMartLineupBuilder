using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueTypes
{
    public class GameID : EntityID
    {
        public GameID(Guid id) : base(id)
        {
        }
        public GameID() : base(Guid.NewGuid())
        {
        }
        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            return new List<object>();
        }
    }
}
