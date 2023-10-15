using OddsAPIClient.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OddsAPIClient.Services
{
    public class OddsAPIService : IOddsAPIService
    {
        private const string _getOddsUrl = @"https://api.the-odds-api.com/v4/sports/americanfootball_nfl/odds";
        public async Task<OddsResponse[]?> GetOdds(string apiKey)
        {
            var url = $@"{_getOddsUrl}?apiKey={apiKey}&regions=us&markets=spreads,totals";

            return await new HttpClient().GetFromJsonAsync<OddsResponse[]>(url);

        }
    }
}
