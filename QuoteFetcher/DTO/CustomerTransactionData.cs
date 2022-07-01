using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class CustomerTransactionData
{
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("data")] public List<Transaction> Data { get; set; }
}
