﻿using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications.SlateSpecs
{
    internal class GetSlateByIDWithSalariesAndGamesSpec : GetSlateByIdSpec
    {
        public GetSlateByIDWithSalariesAndGamesSpec(SlateID slateID):base(slateID)
        {
            AddInclude(slate => slate.Salaries);
            AddInclude(slate => slate.Games);
        }
    }
}
