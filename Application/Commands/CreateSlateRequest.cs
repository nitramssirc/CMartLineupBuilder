using Common.Enums;

using MediatR;

namespace Application.Commands
{
    public class CreateSlateRequest:IRequest<CreateSlateResponse>
    {
        public Sport Sport { get; }
        public DFSSite Site { get; }
        public GameType GameType { get; }
        public string Name { get; }

        public CreateSlateRequest(
            Sport sport, 
            DFSSite site, 
            GameType gameType, 
            string name)
        {
            Sport = sport;
            Site = site;
            GameType = gameType;
            Name = name;
        }
    }
}
