using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetGamesForSlate
{
    public class GetGamesForSlateResponse
    {
        public GameInfo[] Games { get; private set; }

        internal GetGamesForSlateResponse(Slate? slate)
        {
            Games = slate?.Games.Select(game => new GameInfo(game, slate)).ToArray() ?? [];
        }
    }
}
