using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.ValueTypes
{
    public abstract class EntityID : ValueObject
    {
        Guid Id { get; }

        public EntityID()
        {
            Id = Guid.NewGuid();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return GetAdditionalIDComponents();
        }

        protected abstract IEnumerable<object> GetAdditionalIDComponents();
    }
}
