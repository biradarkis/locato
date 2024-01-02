namespace Locato.API.Application.Users.Models
{
    public class DefaultAPIResponse
    {
        public DefaultAPIResponse(string error, bool success)
        {
            Error = error;
            Success = success;
        }

        public DefaultAPIResponse(string error, bool success, string message)
        {
            Error = error;
            Success = success;
            Message = message;
        }

        public string Error { get; private set; }
        public bool Success { get; private set; }
        public string Message { get;private set; }
    }
}
