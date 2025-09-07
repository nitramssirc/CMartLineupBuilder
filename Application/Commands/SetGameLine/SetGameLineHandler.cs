using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Domain.Entities;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.SetGameLine
{
    public class SetGameLineHandler : IRequestHandler<SetGameLineCommand, SetGameLineResponse>
    {

        #region Dependencies

        private readonly ICommandRepository<Slate> _slateCommandRepository;
        private readonly ISpecificationFactory _specificationFactory;

        #endregion

        public SetGameLineHandler(ICommandRepository<Slate> slateCommandRepository, ISpecificationFactory specificationFactory)
        {
            _slateCommandRepository = slateCommandRepository;
            _specificationFactory = specificationFactory;
        }

        public async Task<SetGameLineResponse> Handle(SetGameLineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var spec = _specificationFactory.Create<GetSlateByIDWithGamesSpec>(request.SlateID);
                var slate = await _slateCommandRepository.GetEntity(spec);
                if (slate == null)
                {
                    return new SetGameLineResponse("Slate not found");
                }

                var game = slate.Games.FirstOrDefault(x => x.Id == request.GameID);
                if (game == null)
                {
                    return new SetGameLineResponse("Game not found");
                }

                game.UpdateLine(request.HomePoints, request.AwayPoints);

                await _slateCommandRepository.SaveAsync();

                return new SetGameLineResponse();
            }
            catch (Exception ex)
            {
                return new SetGameLineResponse(ex.Message);
            }
        }
    }
}
