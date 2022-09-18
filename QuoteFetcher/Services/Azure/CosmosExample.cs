using Azure.Data.Tables;
using Microsoft.Azure.Cosmos;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Azure;

public class CosmosExample
{
    // Table API
    public async Task RunTable()
    {
        TableServiceClient tableServiceClient = new(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));

        // add table
        TableClient tableClient = tableServiceClient.GetTableClient(
            "products"
        );

        await tableClient.CreateIfNotExistsAsync();

        // Add new entry
        Product product = new()
        {
            RowKey = "12",
            PartitionKey = "category-1",
            Name = "Nutella",
            Quantity = 8,
            Sale = true
        };

        await tableClient.AddEntityAsync(product);

        // Get
        global::Azure.Response<Product>? fetchedProduct = await tableClient.GetEntityAsync<Product>(
            rowKey: "12",
            partitionKey: "category-1"
        );
        Console.WriteLine("Single product:");
        Console.WriteLine(fetchedProduct.Value.Name);
    }

    // SQL API
    public async Task RunSQL()
    {
        // connect
        CosmosClient client = new(
            Environment.GetEnvironmentVariable("COSMOS_ENDPOINT")!,
            Environment.GetEnvironmentVariable("COSMOS_KEY")!
        );

        // create db and container
        Database database = await client.CreateDatabaseIfNotExistsAsync(
            "sample"
        );
        Container container = await database.CreateContainerIfNotExistsAsync(
            "products",
            "/category",
            400
        );

        // querying SQL way
        QueryDefinition? query = new QueryDefinition(
                "SELECT * FROM products p WHERE p.category = @key"
            )
            .WithParameter("@key", "gear-surf-surfboards");

        FeedIterator<Product> feed = container.GetItemQueryIterator<Product>(
            query
        );
    }
}
