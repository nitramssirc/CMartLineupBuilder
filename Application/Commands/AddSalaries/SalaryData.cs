using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddSalaries
{
    public class SalaryData
    {
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string Team { get; set; }
        public string SiteID { get; set; }

        public string GameInfo { get; set; }

        public string _opponent = string.Empty;
        public string Opponent
        {
            get
            {
                if (string.IsNullOrEmpty(_opponent))
                {
                    _opponent = ExtractOpponentFromGameInfo();
                }

                return _opponent;
            }
        }

        public bool IsHomeTeam => Team != GameInfo.Split('@')[0];

        public DateTime _gameTime = default;
        public DateTime GameTime
        {
            get
            {
                if (_gameTime == default)
                {
                    _gameTime = ExtractGameTimeFromGameInfo();
                }

                return _gameTime;
            }
        }

        public SalaryData(
            string playerName,
            string position,
            int salary,
            string team,
            string siteID,
            string gameInfo)
        {
            PlayerName = playerName;
            Position = position;
            Salary = salary;
            Team = team;
            SiteID = siteID;
            GameInfo = gameInfo;
        }

        private SalaryData()
        {
            PlayerName = string.Empty;
            Position = string.Empty;
            Salary = 0;
            Team = string.Empty;
            SiteID = string.Empty;
            GameInfo = string.Empty;
        }

        public string ExtractOpponentFromGameInfo()
        {
            if (string.IsNullOrEmpty(GameInfo)) return string.Empty;

            var teams = GameInfo.Split(' ')[0].Split('@');
            return teams.FirstOrDefault(t => t != Team) ?? string.Empty;
        }

        public DateTime ExtractGameTimeFromGameInfo()
        {
            if (string.IsNullOrEmpty(GameInfo)) return default;

            var splitGameInfo = GameInfo.Split(' ');
            if (splitGameInfo.Length < 3) return default;

            var gameTimeString = $"{splitGameInfo[1]} {splitGameInfo[2]}";
            if (DateTime.TryParse(gameTimeString, out var gameTime)) return gameTime;

            return default;
        }
    }
}
