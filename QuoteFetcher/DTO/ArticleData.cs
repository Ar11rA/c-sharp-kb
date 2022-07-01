using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class ArticleData
{
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("data")] public List<Article> Data { get; set; }
}
