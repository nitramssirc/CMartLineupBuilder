using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlayersForSlate
{
    public class SlatePlayer
    {
        public string Name { get; private set; }
        public Team Team { get; private set; }
        public string TeamName { get; private set; }
        public PlayerPosition[] Positions { get; private set; }
        public int Salary { get; private set; }
        public PlayerProjection[] Projections { get; private set; }

        public SlatePlayer(
            Slate slate,
            Salary salary,
            Projection[] projections)
        {

            Name = salary.PlayerName;
            Team = salary.Team;
            TeamName = salary.Team.GetName(slate.Sport);
            Positions = salary.Positions;
            Salary = salary.SalaryAmount;
            Projections = projections.Select(p => new PlayerProjection(p)).ToArray();
        }
    }
}
