using Common.Enums;

using Domain.Common.ValueTypes;

namespace Domain.ValueTypes
{
    public class Projection : ValueObject
    {
        #region Properties

        public ProjectionSource ProjectionSource { get; private set; }

        private readonly List<ProjectionData> _data;
        public IReadOnlyCollection<ProjectionData> Data { get { return _data; } }

        #endregion

        #region Constructors

        public Projection(
            ProjectionSource projectionSource,
            IEnumerable<ProjectionData> data) : base()
        {
            ProjectionSource = projectionSource;
            _data = new List<ProjectionData>(data);
        }

        #endregion

        #region Value Object Implementation
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ProjectionSource;
            foreach (var item in _data)
            {
                yield return item;
            }
        }

        #endregion

    }
}
