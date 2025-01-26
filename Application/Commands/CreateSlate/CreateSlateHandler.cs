using Application.Repositories;

using Domain.Entities;
using Domain.ValueTypes;

using MediatR;

namespace Application.Commands.CreateSlate
{
    public class CreateSlateHandler : IRequestHandler<CreateSlateCommand, CreateSlateResponse>
    {
        private readonly ICommandRepository<Slate> _repository;

        public CreateSlateHandler(ICommandRepository<Slate> repository)
        {
            _repository = repository;
        }

        public async Task<CreateSlateResponse> Handle(CreateSlateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slate = Slate.Create(
                    DateTime.Now,
                    request.Sport,
                    request.GameType,
                    request.Site,
                    request.Name);

                await _repository.AddAsync(slate);
                await _repository.SaveAsync();

                return new CreateSlateResponse(slate.Id);
            }
            catch (Exception ex)
            {
                // Log error
                return new CreateSlateResponse(ex.ToString());
            }
        }
    }
}
