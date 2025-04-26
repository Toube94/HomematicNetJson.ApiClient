using HomematicNetJson.ApiClient.Models;

namespace HomematicNetJson.ApiClient.Exceptions
{
    public class ArgumentNotFoundException : ServerException
    {
        public ArgumentNotFoundException(ServerError serverError) : base(serverError)
        {
        }
    }
}
