using Domain.Common.Events;
using Domain.Common.ValueTypes;

namespace Domain.Common.Entities
{
    public abstract class Entity<TID> where TID : EntityID
    {
        public TID Id { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public Entity(TID id)
        {
            Id = id;
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public IDomainEvent[] PublishDomainEvents()
        {
            var publishedEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return publishedEvents;
        }
    }
}
