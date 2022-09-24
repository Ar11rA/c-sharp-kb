using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class IotDeviceData
{
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("data")] public List<Device> Data { get; set; }
}
