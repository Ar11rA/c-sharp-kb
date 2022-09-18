using Azure;
using Azure.Data.Tables;

namespace QuoteFetcher.DTO;

// Cosmos Table Models
public class Product : ITableEntity
{
    public string Name { get; init; } = default!;

    public int Quantity { get; init; }

    public bool Sale { get; init; }
    public string RowKey { get; set; } = default!;

    public string PartitionKey { get; set; } = default!;

    public ETag ETag { get; set; } = default!;

    public DateTimeOffset? Timestamp { get; set; } = default!;
}
