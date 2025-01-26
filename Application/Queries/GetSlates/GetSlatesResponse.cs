using Domain.ValueTypes;

namespace Application.Queries.GetSlates
{
    public class GetSlatesResponse
    {
        public SlateID Id { get; }


        public string Name { get; }

        public GetSlatesResponse(SlateID id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
