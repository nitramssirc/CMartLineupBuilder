using Domain.Common.ValueTypes;

namespace Domain.Common.Models
{
    public abstract class Entity<TID> where TID : EntityID
    {
        public TID Id { get; private set; }

        public Entity(TID id)
        {
            Id = id;
        }
    }
}
