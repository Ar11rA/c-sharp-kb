using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class OperatingParams
{
    [JsonPropertyName("rotorSpeed")] public double RotorSpeed { get; set; }

    [JsonPropertyName("slack")] public double Slack { get; set; }

    [JsonPropertyName("rootThreshold")] public double Threshold { get; set; }
}
