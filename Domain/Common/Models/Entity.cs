using Domain.Common.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Models
{
    public abstract class Entity<TID> where TID : EntityID
    {
        public TID Id { get; }

        protected Entity()
        {
            Id = Activator.CreateInstance<TID>();
        }
    }
}
