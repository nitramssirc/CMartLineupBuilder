using Application.Common.Responses;

using Domain.ValueTypes;

namespace Application.Commands.CreateSlate
{
    public class CreateSlateResponse : CommandResultResponse
    {
        public SlateID NewId { get; set; } = default!;

        public CreateSlateResponse(SlateID newId)
        {
            NewId = newId;
        }

        public CreateSlateResponse(string error) : base(error)
        {
        }
    }
}
