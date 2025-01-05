namespace Domain.Common.ValueTypes
{
    public abstract class EntityID : ValueObject
    {
        public Guid Id { get; }

        internal EntityID(Guid id)
        {
            Id = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;

            var additionalComponents = GetAdditionalIDComponents();
            foreach (var component in additionalComponents)
            {
                yield return component;
            }
        }

        protected abstract IEnumerable<object> GetAdditionalIDComponents();
    }
}
