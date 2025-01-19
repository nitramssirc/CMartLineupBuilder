using Common.Enums;

using Domain.Common.Entities;
using Domain.Events.ProjectionEvents;
using Domain.ValueTypes;

namespace Domain.Entities
{
    public class Projection : Entity<ProjectionID>
    {
        #region Constructors
        
        private Projection() : base(new ProjectionID())
        {
            SlateID = new SlateID();
            _data = new List<ProjectionData>();
            PlayerName = string.Empty;
        }

        #endregion

        #region Properties

        public SlateID SlateID { get; private set; }

        public ProjectionSource ProjectionSource { get; private set; }

        public string PlayerName { get; private set; }

        public Team Team { get; private set; }

        private readonly List<ProjectionData> _data;
        public IReadOnlyCollection<ProjectionData> Data { get { return _data; } }

        #endregion

        #region Methods

        public static Projection Create(
            SlateID slateID,
            ProjectionSource projectionSource,
            string playerName,
            Team team,
            IEnumerable<ProjectionData> data)
        {
            var projection = new Projection();
            projection.SlateID = slateID;
            projection.ProjectionSource = projectionSource;
            projection.PlayerName = playerName;
            projection.Team = team;
            projection._data.AddRange(data);

            projection.AddDomainEvent(new ProjectionCreatedEvent(projection));

            return projection;
        }

        #endregion
    }
}
