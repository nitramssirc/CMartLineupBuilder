namespace Application.Queries.GetSlates
{
    public class GetSlateResponse
    {
        public Guid Id { get; }


        public string Name { get; }

        public GetSlateResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
