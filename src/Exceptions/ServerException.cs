
using HomematicNetJson.ApiClient.Models;

namespace HomematicNetJson.ApiClient.Exceptions
{
    public class ServerException : Exception
    {
        public virtual int Code { get; }
        public virtual string? ServerMessage { get; }

        public ServerException() : base()
        {
        }

        public ServerException(ServerError serverError) : base()
        {
            Code = serverError.Code;
            ServerMessage = serverError.Message;
        }

        public ServerException(string message) : base(message)
        {
        }
    }
}
