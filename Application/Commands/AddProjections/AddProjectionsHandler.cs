using Application.Commands.AddProjections.Models;
using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications.SlateSpecs;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Commands.AddProjections
{
    public class AddProjectionsHandler
        : IRequestHandler<AddProjectionsCommand, AddProjectionsResponse>
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


        async Task<AddProjectionsResponse> IRequestHandler<AddProjectionsCommand, AddProjectionsResponse>.
            Handle(AddProjectionsCommand request, CancellationToken cancellationToken)
        {
            return await AddProjections(request);
        }

        #endregion

        #region Private Methods


        private async Task<AddProjectionsResponse> AddProjections(AddProjectionsCommand request)
        {
            try
            {
                var slate = await LoadSlate(request.SlateID);
                if (slate == null)
                {
                    return new AddProjectionsResponse("Error Adding Projections: Slate Not Found");
                }

                slate.ClearProjectionsFromSource(request.ProjectionSource);

                var projections = request.UploadedProjections;
                foreach (var projection in projections)
                {
                    slate.AddProjection(ConstructProjection(request, projection));
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

        private Projection ConstructProjection(AddProjectionsCommand request, UploadedProjection projection)
        {
            return Projection.Create(
                request.SlateID,
                request.ProjectionSource,
                projection.Name,
                projection.Team,
                projection.ProjectionData);
        }

        #endregion

    }
}
