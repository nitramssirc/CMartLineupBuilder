using Domain.Common.Entities;
using Domain.ValueTypes;

namespace Domain.Entities
{
    public class Projection : Entity<ProjectionID>
    {
        #region Constructors

        private Projection() : base(new ProjectionID())
        {
            Source = string.Empty;
            SlateID = new SlateID();
            PlayerID = new PlayerID();
            _data = new List<ProjectionData>();
        }

        public Projection(
            ProjectionID id,
            string source,            
            List<ProjectionData> data) : base(id)
        {
            Source = source;            
            _data = data;           
        }

        #endregion

        #region Properties

        public string Source { get; private set; }

        public SlateID? SlateID { get; internal set; }

        public PlayerID? PlayerID { get; internal set; }

        private List<ProjectionData> _data;
        public IReadOnlyCollection<ProjectionData> Data { get { return _data; } }

        #endregion
    }
}
