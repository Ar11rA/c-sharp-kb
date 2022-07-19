using System.Text.Json;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Rest;

public static class RelevantFoodOutlet
{
    public static async Task<List<string>> CollateAffordableOutlets(string city, int threshold)
    {
        int page = 1;
        HttpClient client = new();
        List<string> results = new();
        while (true)
        {
            string url =
                $"https://jsonmock.hackerrank.com/api/food_outlets?city={city}&page={page}";
            string jsonContent = await client.GetStringAsync(url);
            FoodOutletData? response = JsonSerializer.Deserialize<FoodOutletData>(jsonContent);
            if (response == null)
            {
                continue;
            }

            page++;
            results.AddRange(response.Data
                .Where(outlet => outlet.CostForTwo <= threshold)
                .Select(outlet => outlet.Name)
                .ToList()
            );
            if (page > response.TotalPages)
            {
                break;
            }
        }

        return results;
    }
}
