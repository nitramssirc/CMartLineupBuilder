using Common.Enums;

using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections
{
    internal class ProjectionDTO

    {
        public string PlayerName { get; private set; }

        public Team Team { get; private set; }

        private readonly List<ProjectionData> _data;
        public IReadOnlyCollection<ProjectionData> Data { get { return _data; } }

        public ProjectionDTO(string playerName, Team team, IEnumerable<ProjectionData> data)
        {
            PlayerName = playerName;
            Team = team;
            _data = new List<ProjectionData>(data);
        }
    }
}
