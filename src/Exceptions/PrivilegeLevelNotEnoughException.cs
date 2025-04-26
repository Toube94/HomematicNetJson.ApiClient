using HomematicNetJson.ApiClient.Models;

namespace HomematicNetJson.ApiClient.Exceptions
{
    public class PrivilegeLevelNotEnoughException : ServerException
    {
        public PrivilegeLevelNotEnoughException(ServerError serverError) : base(serverError)
        {
        }
    }
}
