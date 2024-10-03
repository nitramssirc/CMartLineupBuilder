using Domain;
using Domain.VegasLines;

using OddsAPIClient.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public class VegasLineFactory : IVegasLineFactory
    {
        public VegasLine GetVegasLineForTeamFromOddsResponse(Team team, OddsResponse[] odds)
        {
            var teamName = GetOddsTeamName(team);
            var gameOdds = GetOddsFor
        }

        private string GetOddsTeamName(Team team)
        {
            switch (team)
            {
                case Team.ARI: return "Arizona Cardinals";
                case Team.ATL: return "Atlanta Falcons";
                case Team.BAL: return "Baltimore Ravens";
                case Team.BUF: return "Buffalo Bills";
                case Team.CAR: return "Carolina Panthers";
                case Team.CHI: return "Chicago Bears";
                case Team.CIN: return "Cincinatti Bengals";
                case Team.CLE: return "Cleveland Browns";
                case Team.DAL: return "Dallas Cowboys";
                case Team.DEN: return "Denver Broncos";
                case Team.DET: return "Detroit Lions";
                case Team.GB : return "Green Bay Packers";
                case Team.HOU: return "Houston Texans";
                case Team.IND: return "Indianapolis Colts";
                case Team.JAC: return "Jacksonville Jaguars";
                case Team.KC : return "Kansas City Chiefs";
                case Team.LV : return "Las Vegas Raiders";
                case Team.LAC: return "Los Angeles Chargers";
                case Team.LAR: return "Los Angeles Rams";
                case Team.MIA: return "Miami Dolphins";
                case Team.MIN: return "Minnesota Vikings";
                case Team.NE : return "New England Patriots";
                case Team.NO : return "New Orleans Saints";
                case Team.NYG: return "New York Giants";
                case Team.NYJ: return "New York Jets";
                case Team.PHI: return "Philadelphia Eagles";
                case Team.PIT: return "Pittsburgh Steelers";
                case Team.SF : return "San Francisco 49ers";
                case Team.SEA: return "Seatle Seahawks";
                case Team.TB : return "Tampa Bay Bucaneers";
                case Team.TEN: return "Tennessee Titains";
                case Team.WAS: return "Washington Commanders";
                default: return "";
            }
        }
    }
}
