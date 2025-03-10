using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlayersForSlate
{
    public class PlayerProjectionData
    {
        public string StatName { get; private set; }
        public decimal Value { get; private set; }

        public PlayerProjectionData(ProjectionData projectionData)
        {
            StatName = projectionData.StatCategory.ToString();
            Value = projectionData.Value;
        }
    }
}
