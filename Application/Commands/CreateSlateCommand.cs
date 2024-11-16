using Application.Common.Repositories;

using Domain.SlateAggregate.Models;
using Domain.SlateAggregate.ValueTypes;

using MediatR;

namespace Application.Commands
{
    public class CreateSlateCommand:IRequestHandler<CreateSlateRequest, CreateSlateResponse>
    {
        private readonly ICommandRepository<Slate, SlateID> _repository;

        public CreateSlateCommand(ICommandRepository<Slate, SlateID> repository)
        {
            _repository = repository;
        }

        public async Task<CreateSlateResponse> Handle(CreateSlateRequest request, CancellationToken cancellationToken)
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
