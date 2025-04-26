using System.Text.Json.Serialization;

namespace HomematicNetJson.ApiClient.Models
{
    public class ServerError
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }

    }
}
