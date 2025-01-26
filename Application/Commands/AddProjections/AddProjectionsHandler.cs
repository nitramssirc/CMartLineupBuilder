using Application.Commands.AddProjections.NBARotoGrinders;
using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProjections
{
    public class AddProjectionsHandler
        : IRequestHandler<AddRotoGrindersNBAProjectionsCommand, AddProjectionsResponse>
    {
        #region Dependencies

        private readonly ICommandRepository<Slate> _slateRepository;
        private readonly ISpecificationFactory _specFactory;

        #endregion

        #region Constructor

        public AddProjectionsHandler(
            ICommandRepository<Slate> slateRepository,
            ISpecificationFactory specFactory)
        {
            _slateRepository = slateRepository;
            _specFactory = specFactory;
        }

        #endregion

        #region Handlers


        async Task<AddProjectionsResponse> IRequestHandler<AddRotoGrindersNBAProjectionsCommand, AddProjectionsResponse>.
            Handle(AddRotoGrindersNBAProjectionsCommand request, CancellationToken cancellationToken)
        {
            return await AddProjections(request);
        }

        #endregion

        #region Private Methods


        private async Task<AddProjectionsResponse> AddProjections(AddProjectionsCommandBase request)
        {
            try
            {
                var slate = await LoadSlate(request.SlateID);
                if (slate == null)
                {
                    return new AddProjectionsResponse("Error Adding Projections: Slate Not Found");
                }

                slate.ClearProjectionsFromSource(request.ProjectionSource);

                var projections = request.GetProjections();
                foreach (var projectionDTO in projections)
                {
                    slate.AddProjection(ConstructProjection(request, projectionDTO));
                }

                await _slateRepository.SaveAsync();

                return new AddProjectionsResponse();
            }
            catch (Exception ex)
            {
                return new AddProjectionsResponse($"Error Adding Projections: {ex}");
            }
        }

        private async Task<Slate?> LoadSlate(SlateID slateID)
        {
            var spec = _specFactory.Create<GetSlateByIDWithProjectionsSpec>(slateID);
            return (await _slateRepository.GetEntity(spec));
        }

        private Projection ConstructProjection(AddProjectionsCommandBase request, ProjectionDTO projectionDTO)
        {
            return Projection.Create(
                request.SlateID,
                request.ProjectionSource,
                projectionDTO.PlayerName,
                projectionDTO.Team,
                projectionDTO.Data);
        }

        #endregion

    }
}
