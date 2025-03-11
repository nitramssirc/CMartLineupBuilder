using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetGamesForSlate
{
    public class GameInfo
    {
        public GameID GameID { get; set; }
        public Team HomeTeam { get; set; }
        public string HomeTeamName { get; set; }
        public Team AwayTeam { get; set; }
        public string AwayTeamName { get; set; }
        public TimeOnly StartTime { get; set; }
        public decimal HomePoints { get; set; }
        public decimal AwayPoints { get; set; }

        internal GameInfo(
            Game game,
            Slate slate)
        {
            GameID = game.Id;
            HomeTeam = game.HomeTeam;
            HomeTeamName = game.HomeTeam.GetName(slate.Sport);
            AwayTeam = game.AwayTeam;
            AwayTeamName = game.AwayTeam.GetName(slate.Sport);
            StartTime = game.StartTime;
            HomePoints = game.HomePoints;
            AwayPoints = game.AwayPoints;
        }
    }
}
