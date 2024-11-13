using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Slate.ValueTypes
{
    public class SlateID : EntityID
    {
        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            yield break;
        }
    }
}
