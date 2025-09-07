using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications.SlateSpecs
{
    internal class GetSlateByIDWithGamesSpec : GetSlateByIdSpec
    {
        public GetSlateByIDWithGamesSpec(SlateID slateID) : base(slateID)
        {
            AddInclude(x => x.Games);
        }
    }
}
