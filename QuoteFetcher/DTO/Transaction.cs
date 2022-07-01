using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class Transaction
{
    [JsonPropertyName("userId")] public int UserId { get; set; }

    [JsonPropertyName("amount")] public string Amount { get; set; }
}
