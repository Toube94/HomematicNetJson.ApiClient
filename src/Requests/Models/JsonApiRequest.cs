using System.Text.Json.Serialization;

namespace HomematicNetJson.ApiClient.Requests.Models
{
    public class JsonApiRequest
    {
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;
        [JsonPropertyName("params")]
        public Dictionary<string, object> Parameters { get; set; } = [];
    }
}
