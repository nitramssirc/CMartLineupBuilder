using Domain.Common.ValueTypes;

namespace Domain.ValueTypes
{
    public class SlateID : EntityID
    {
        #region Constructor

        private SlateID(Guid id) : base(id)
        {
        }

        #endregion

        #region Factory Methods
        public static SlateID CreateNew()
        {
            return new SlateID(Guid.NewGuid());
        }

        #endregion

        #region EntityID Overrides

        protected override IEnumerable<object> GetAdditionalIDComponents()
        {
            return new List<object>();
        }

        #endregion
    }
}
