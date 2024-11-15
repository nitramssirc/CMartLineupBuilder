namespace Domain.Common.ValueTypes
{
    public abstract class EntityID : ValueObject
    {
        Guid Id { get; }

        public EntityID(Guid id)
        {
            Id = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return GetAdditionalIDComponents();
        }

        protected abstract IEnumerable<object> GetAdditionalIDComponents();
    }
}
