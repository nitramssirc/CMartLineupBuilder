using Domain.Common.Models;
using Domain.SlateAggregate.ValueTypes;

namespace Domain.SlateAggregate.Models
{
    public class Projection:Entity<ProjectionID>
    {              
        #region Constructors

        private Projection() : base(new ProjectionID()) {
            Source = string.Empty;
            SlateID = new SlateID();
            PlayerID = new PlayerID();
            _data = new List<ProjectionData>();
        }

        public Projection(
            ProjectionID id,
            string source,
            SlateID slateID,
            PlayerID playerID,
            List<ProjectionData> data) : base(id)
        {
            Source = source;
            SlateID = slateID;
            PlayerID = playerID;
            _data = data;
        }

        #endregion

        #region Properties

        public string Source { get; private set; }

        public SlateID SlateID { get; private set; }

        public PlayerID PlayerID { get; private set; }

        private List<ProjectionData> _data;
        public IReadOnlyCollection<ProjectionData> Data { get { return _data; } }

        #endregion
    }
}
