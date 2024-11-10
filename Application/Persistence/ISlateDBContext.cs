using Common.Enums;

using Domain.Slate.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface ISlateDBContext
    {
        void Add(Slate slate);

        List<Slate> Get(Sport sport, DFSSite site);
    }
}
