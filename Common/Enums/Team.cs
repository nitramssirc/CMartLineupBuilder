using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum Team
    {
        UNKNOWN,
        [TeamName(Sport.NFL, "Arizona Cardinals")]
        ARI,
        [TeamName(Sport.NFL, "Atlanta Falcons")]
        [TeamName(Sport.NBA, "Atlanta Hawks")]
        ATL,
        [TeamName(Sport.NFL, "Baltimore Ravens")]
        BAL,
        [TeamName(Sport.NFL, "Buffalo Bills")]
        BUF,
        [TeamName(Sport.NFL, "Carolina Panthers")]
        CAR,
        [TeamName(Sport.NFL, "Chicago Bears")]
        [TeamName(Sport.NBA, "Chicago Bulls")]
        CHI,
        [TeamName(Sport.NFL, "Cincinnati Bengals")]
        CIN,
        [TeamName(Sport.NFL, "Cleveland Browns")]
        [TeamName(Sport.NBA, "Cleveland Cavaliers")]
        CLE,
        [TeamName(Sport.NFL, "Dallas Cowboys")]
        [TeamName(Sport.NBA, "Dallas Mavericks")]
        DAL,
        [TeamName(Sport.NFL, "Denver Broncos")]
        [TeamName(Sport.NBA, "Denver Nuggets")]
        DEN,
        [TeamName(Sport.NFL, "Detroit Lions")]
        [TeamName(Sport.NBA, "Detroit Pistons")]
        DET,
        [TeamName(Sport.NFL, "Green Bay Packers")]
        GB,
        [TeamName(Sport.NFL, "Houston Texans")]
        [TeamName(Sport.NBA, "Houston Rockets")]
        HOU,
        [TeamName(Sport.NFL, "Indianapolis Colts")]
        [TeamName(Sport.NBA, "Indiana Pacers")]
        IND,
        [TeamName(Sport.NFL, "Jacksonville Jaguars")]
        JAX,
        [TeamName(Sport.NFL, "Kansas City Chiefs")]
        KC,
        [TeamName(Sport.NFL, "Las Angeles Chargers")]
        [TeamName(Sport.NBA, "Los Angeles Clippers")]
        LAC,
        [TeamName(Sport.NFL, "Las Angeles Rams")]
        LAR,
        [TeamName(Sport.NFL, "Las Vegas Raiders")]
        LV,
        [TeamName(Sport.NFL, "Miami Dolphins")]
        [TeamName(Sport.NBA, "Miami Heat")]
        MIA,
        [TeamName(Sport.NFL, "Minnesota Vikings")]
        [TeamName(Sport.NBA, "Minnesota Timberwolves")]
        MIN,
        [TeamName(Sport.NFL, "New England Patriots")]
        NE,
        [TeamName(Sport.NFL, "New Orleans Saints")]
        [TeamName(Sport.NBA, "New Orleans Pelicans")]
        NO,
        [TeamName(Sport.NFL, "New York Giants")]
        NYG,
        [TeamName(Sport.NFL, "New York Jets")]
        NYJ,
        [TeamName(Sport.NFL, "Philadelphia Eagles")]
        [TeamName(Sport.NBA, "Philadelphia 76ers")]
        PHI,
        [TeamName(Sport.NFL, "Pittsburgh Steelers")]
        PIT,
        [TeamName(Sport.NFL, "Seattle Seahawks")]
        SEA,
        [TeamName(Sport.NFL, "San Francisco 49ers")]
        SF,
        [TeamName(Sport.NFL, "Tampa Bay Buccaneers")]
        TB,
        [TeamName(Sport.NFL, "Tennessee Titans")]
        TEN,
        [TeamName(Sport.NFL, "Washington Commanders")]
        [TeamName(Sport.NBA, "Washington Wizards")]
        WAS,
        [TeamName(Sport.NBA, "Boston Celtics")]
        BOS,
        [TeamName(Sport.NBA, "Brooklyn Nets")]
        BKN,
        [TeamName(Sport.NBA, "Charlotte Hornets")]
        CHA,
        [TeamName(Sport.NBA, "Golden State Warriors")]
        GS,
        [TeamName(Sport.NBA, "Los Angeles Lakers")]
        LAL,
        [TeamName(Sport.NBA, "Memphis Grizzlies")]
        MEM,
        [TeamName(Sport.NBA, "Milwaukee Bucks")]
        MIL,
        [TeamName(Sport.NBA, "New York Knicks")]
        NYK,
        [TeamName(Sport.NBA, "Oklahoma City Thunder")]
        OKC,
        [TeamName(Sport.NBA, "Orlando Magic")]
        ORL,
        [TeamName(Sport.NBA, "Phoenix Suns")]
        PHX,
        [TeamName(Sport.NBA, "Portland Trail Blazers")]
        POR,
        [TeamName(Sport.NBA, "Sacramento Kings")]
        SAC,
        [TeamName(Sport.NBA, "San Antonio Spurs")]
        SAS,
        [TeamName(Sport.NBA, "Toronto Raptors")]
        TOR,
        [TeamName(Sport.NBA, "Utah Jazz")]
        UTA,
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class TeamNameAttribute : Attribute
    {
        public Sport Sport { get; }
        public string Name { get; }


        public TeamNameAttribute(Sport sport, string name)
        {
            Sport = sport;
            Name = name;
        }
    }

    public static class TeamExtensions
    {
        public static string GetName(this Team team, Sport sport)
        {
            var field = team.GetType().GetField(team.ToString());
            var attributes = field?.GetCustomAttributes(typeof(TeamNameAttribute), false) as TeamNameAttribute[];
            var attribute = attributes?.FirstOrDefault(a => a.Sport == sport);
            return attribute?.Name ?? team.ToString();
        }
    }
}
