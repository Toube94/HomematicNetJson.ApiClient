using System.Text.Json.Serialization;

namespace HomematicNetJson.ApiClient.Models
{
    public class ChannelDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("deviceId")]
        public string? DeviceId { get; set; }
        [JsonPropertyName("index")]
        public int Index { get; set; }
        [JsonPropertyName("partnerId")]
        public string? PartnerId { get; set; }
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }
        [JsonPropertyName("category")]
        public string? Category { get; set; }
        [JsonPropertyName("isReady")]
        public bool IsReady { get; set; }
        [JsonPropertyName("isUsable")]
        public bool IsUsable { get; set; }
        [JsonPropertyName("isLogged")]
        public bool IsLogged { get; set; }
        [JsonPropertyName("isLogable")]
        public bool IsLogable { get; set; }
        [JsonPropertyName("isReadable")]
        public bool IsReadable { get; set; }
        [JsonPropertyName("isWriteable")]
        public bool IsWriteable { get; set; }
        [JsonPropertyName("isEventable")]
        public bool IsEventable { get; set; }
        [JsonPropertyName("isAesAvailable")]
        public bool IsAesAvailable { get; set; }
        [JsonPropertyName("isVirtual")]
        public bool IsVirtual { get; set; }
        [JsonPropertyName("ChannelType")]
        public string? ChannelType { get; set; }
    }
}
