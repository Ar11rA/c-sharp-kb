using System.Text.Json;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services;

public class CustomerTransaction
{
    public static async Task GetTransactions(string transactionType)
    {
        HttpClient client = new();
        int page = 1;
        Dictionary<int, double> customerTotals = new();
        while (true)
        {
            string url =
                $"https://jsonmock.hackerrank.com/api/transactions/search?txnType={transactionType}&page={page}";
            string transactions = await client.GetStringAsync(url);
            CustomerTransactionData? response = JsonSerializer.Deserialize<CustomerTransactionData>(transactions);
            if (response == null)
            {
                continue;
            }

            response.Data.ForEach(data =>
            {
                if (!customerTotals.ContainsKey(data.UserId))
                {
                    customerTotals[data.UserId] = double.Parse(data.Amount.Split("$")[1]);
                }
                else
                {
                    customerTotals[data.UserId] += double.Parse(data.Amount.Split("$")[1]);
                }
            });
            page++;
            if (page > response.TotalPages)
            {
                break;
            }
        }

        foreach ((int? key, double? value) in customerTotals)
        {
            Console.WriteLine(key + ": " + value);
        }
    }
}
