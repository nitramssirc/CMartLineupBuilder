using Common.Enums;

using Domain.SlateAggregate.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayerForSlateResponse
    {
        public PlayerID PlayerID { get; private set; }
        public string Name { get; private set; }
        public Team Team { get; private set; }
        public PlayerPosition[] Positions { get; private set; }
        public int Salary { get; private set; }
        public ProjectionData[] ProjectionData { get; private set; }

        public GetPlayerForSlateResponse(
            PlayerID playerID,
            string name,
            Team team,
            PlayerPosition[] positions,
            int salary,
            ProjectionData[] projections)
        {
            PlayerID = playerID;
            Name = name;
            Team = team;
            Positions = positions;
            Salary = salary;
            ProjectionData = projections;
        }
    }
}
