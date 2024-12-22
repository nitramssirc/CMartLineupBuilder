﻿using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SlateAggregate.ValueTypes
{
    public class SalaryID : EntityID
    {
        public SalaryID(Guid id) : base(id)
        {
        }
        public SalaryID() : base(Guid.NewGuid())
        {
        }
        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            return new List<object>();
        }

    }
}
