namespace Application.Common.Responses
{
    public abstract class CommandResultResponse
    {
        public bool Success { get; }
        public string Error { get; }

        protected CommandResultResponse()
        {
            Success = true;
            Error = string.Empty;
        }

        protected CommandResultResponse(string error)
        {
            Success = false;
            Error = error;
        }
    }
}
