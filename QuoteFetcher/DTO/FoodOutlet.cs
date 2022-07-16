using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class FoodOutlet
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("estimated_cost")]
    public int CostForTwo { get; set; }
}
