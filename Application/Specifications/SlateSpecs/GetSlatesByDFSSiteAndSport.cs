using Common.Enums;

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
    public class GetSlatesByDFSSiteAndSport : Specification<Slate>
    {
        public override Expression<Func<Slate, bool>> Expression { get; }

        public GetSlatesByDFSSiteAndSport(DFSSite site, Sport sport)
        {
            Expression = slate => slate.Sport == sport && slate.DFSSite == site;
        }

    }
}
