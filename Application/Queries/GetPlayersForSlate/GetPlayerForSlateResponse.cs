﻿using Common.Enums;

using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayerForSlateResponse
    {
        public string Name { get; private set; }
        public Team Team { get; private set; }
        public string TeamName { get; private set; }
        public PlayerPosition[] Positions { get; private set; }
        public int Salary { get; private set; }
        public ProjectionData[] ProjectionData { get; private set; }

        public GetPlayerForSlateResponse(
            string name,
            Team team,
            string teamName,
            PlayerPosition[] positions,
            int salary,
            ProjectionData[] projections)
        {
            Name = name;
            Team = team;
            TeamName = teamName;
            Positions = positions;
            Salary = salary;
            ProjectionData = projections;
        }
    }
}
