using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class Device
{
    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("timestamp")] public long RecordedAt { get; set; }

    [JsonPropertyName("operatingParams")] public OperatingParams OperatingParams { get; set; }
}
