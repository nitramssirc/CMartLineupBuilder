using Domain.Common.ValueTypes;

namespace Domain.SlateAggregate.ValueTypes
{
    public class SlateID : EntityID
    {
        public SlateID(Guid id) : base(id)
        {
        }

        public SlateID() : base(Guid.NewGuid())
        {
        }

        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            yield break;
        }
    }
}
