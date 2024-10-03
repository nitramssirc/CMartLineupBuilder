using Domain;
using Domain.VegasLines;

using OddsAPIClient.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public interface IVegasLineFactory
    {
        VegasLine GetVegasLineForTeamFromOddsResponse(Team team, OddsResponse[] odds);
    }
}
