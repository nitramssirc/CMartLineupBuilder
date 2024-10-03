using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddsAPIClient.Models
{
    public class OddsResponse
    {
        public string id {  get; set; }

        public string sport_key { get; set; }

        public string sport_title { get; set; }

        public string home_team { get; set; }

        public string away_team { get; set; }

        public Bookmaker[] bookmakers { get; set; }
    }
}
