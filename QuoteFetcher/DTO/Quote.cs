using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class Quote
{
    [JsonPropertyName("content")] public string Content { get; set; }
    [JsonPropertyName("author")] public string Author { get; set; }
}
