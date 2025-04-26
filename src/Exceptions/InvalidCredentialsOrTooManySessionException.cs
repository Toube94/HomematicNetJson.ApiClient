using HomematicNetJson.ApiClient.Models;

namespace HomematicNetJson.ApiClient.Exceptions
{
    public class InvalidCredentialsOrTooManySessionException : ApplicationSpecificErrorException
    {
        public InvalidCredentialsOrTooManySessionException(ServerError serverError) : base(serverError)
        {
        }

        public override string Message => "Invalid credentials or too many sessions.";
    }
}
