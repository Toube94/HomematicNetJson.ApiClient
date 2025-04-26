using HomematicNetJson.ApiClient.Models;
using HomematicNetJson.ApiClient.Requests.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace HomematicNetJson.ApiClient.Client
{
    public class HomematicClient : IHomematicClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomematicClient>? _logger;
        const string _jsonApiPath = "/api/homematic.cgi";

        public string HomematicUrl { get; set; }
        public Uri JsonUrl
        {
            get
            {
                return new UriBuilder(HomematicUrl)
                {
                    Path = _jsonApiPath
                }
                .Uri;
            }
        }



        public HomematicClient(string homematicUrl, ILogger<HomematicClient>? logger = null)
        {
            HomematicUrl = homematicUrl;
            _httpClient = new HttpClient();
            _logger = logger;
        }

        public async Task<JsonApiResult<T>> SendRequest<T>(JsonApiRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(JsonUrl, request);

            try
            {
                var result = await response.Content.ReadFromJsonAsync<JsonApiResult<T>>();
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Unhandled Exception");
                throw new Exception("Unhandled Exception", ex);
            }

        }
    }
}
