using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class FoodOutletData
{
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("data")] public List<FoodOutlet> Data { get; set; }
}
