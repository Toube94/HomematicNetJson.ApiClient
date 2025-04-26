using HomematicNetJson.ApiClient.Models;
using HomematicNetJson.ApiClient.Requests.Models;

namespace HomematicNetJson.ApiClient.Client
{
    public interface IHomematicClient
    {
        public Task<JsonApiResult<T>> SendRequest<T>(JsonApiRequest request);
    }
}
