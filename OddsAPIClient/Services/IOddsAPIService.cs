using OddsAPIClient.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddsAPIClient.Services
{
    public interface IOddsAPIService
    {
        Task<OddsResponse[]> GetOdds(string apiKey);
    }
}
