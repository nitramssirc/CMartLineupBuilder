using Domain.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.SetGameLine
{
    public class SetGameLineCommand: IRequest<SetGameLineResponse>
    {
        public SlateID SlateID { get; private set; }
        public GameID GameID { get; private set; }
        public decimal HomePoints { get; private set; }
        public decimal AwayPoints { get; private set; }

        public SetGameLineCommand(SlateID slateID, GameID gameID, decimal homePoints, decimal awayPoints)
        {
            SlateID = slateID;
            GameID = gameID;
            HomePoints = homePoints;
            AwayPoints = awayPoints;
        }
    }
}
