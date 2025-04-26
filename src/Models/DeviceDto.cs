using System.Text.Json.Serialization;

namespace HomematicNetJson.ApiClient.Models
{
    public class DeviceDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("interface")]
        public string? Interface { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("operateGroupOnly")]
        public string? OperateGroupOnly { get; set; }
        [JsonPropertyName("isReady")]
        public string? IsReady { get; set; }
        [JsonPropertyName("channels")]
        public List<ChannelDto>? Channels { get; set; }
    }
}
