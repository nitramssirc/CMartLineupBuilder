using Domain.SlateAggregate.ValueTypes;

namespace Application.Queries.GetSlates
{
    public class GetSlateResponse
    {
        public SlateID Id { get; }


        public string Name { get; }

        public GetSlateResponse(SlateID id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
