using System.Text.Json.Serialization;

namespace HomematicNetJson.ApiClient.Models
{
    public class JsonApiResult<T>
    {
        [JsonPropertyName("version")]
        public string? Version { get; set; }
        [JsonPropertyName("result")]
        public T? Result { get; set; }
        [JsonPropertyName("error")]
        public ServerError? Error { get; set; }
    }
}
