using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlayersForSlate
{
    public class PlayerProjection
    {
        public string Source { get; private set; }
        public PlayerProjectionData[] Data { get; private set; }

        public PlayerProjection(Projection projection)
        {
            Source = projection.ProjectionSource.ToString();
            Data = projection.Data.Select(d => new PlayerProjectionData(d)).ToArray();
        }
    }
}
