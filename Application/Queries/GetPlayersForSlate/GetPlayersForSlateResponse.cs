using Common.Enums;

using Domain.Entities;
using Domain.ValueTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlayersForSlate
{
    public class GetPlayersForSlateResponse
    {
        public SlatePlayer[] Players { get; private set; }

        public GetPlayersForSlateResponse(Slate? slate)
        {
            Players = slate?.Salaries
                .Select(salary => 
                    new SlatePlayer(slate, 
                                    salary, 
                                    slate.Projections.Where(proj => proj.PlayerName == salary.PlayerName).ToArray())).ToArray() ?? [];
        }
    }
}
