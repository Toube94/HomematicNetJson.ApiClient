
using HomematicNetJson.ApiClient.Models;

namespace HomematicNetJson.ApiClient.Exceptions
{
    public class ApplicationSpecificErrorException : ServerException
    {
        public ApplicationSpecificErrorException(ServerError serverError) : base(serverError)
        {
        }
    }
}
