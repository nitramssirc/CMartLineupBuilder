using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications.SlateSpecs
{
    internal class GetSlateByIdSpec : Specification<Slate>
    {
        public override Expression<Func<Slate, bool>> Expression { get; }

        public GetSlateByIdSpec(SlateID slateID)
        {
            Expression = slate => slate.Id == slateID;
        }

    }
}
