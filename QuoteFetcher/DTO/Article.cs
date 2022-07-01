using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class Article
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("author")] public string? Author { get; set; }
    [JsonPropertyName("num_comments")] public int? NumberOfComments { get; set; }
}
