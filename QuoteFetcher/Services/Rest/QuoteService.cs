using System.Text.Json;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Rest;

public static class QuoteService
{
    private static Dictionary<string, List<string>> GroupQuotesByAuthor(string[] quotes)
    {
        return quotes
            .Aggregate(new Dictionary<string, List<string>>(), (acc, current) =>
            {
                Quote? currentQuote = JsonSerializer.Deserialize<Quote>(current);
                if (currentQuote == null)
                {
                    return acc;
                }
                if (!acc.ContainsKey(currentQuote.author))
                {
                    acc[currentQuote.author] = new List<string> {currentQuote.content};
                }
                else
                {
                    acc[currentQuote.author].Add(currentQuote.content);
                }

                return acc;
            });
    }

    public static async Task<Dictionary<string, List<string>>> FetchQuotes(int numberOfQuotes)
    {
        Console.WriteLine("Processing started at: " + DateTime.Now);
        HttpClient client = new();
        const string quoteUrl = "http://api.quotable.io/random";
        List<Task<string>> quoteTasks = Enumerable
            .Range(1, numberOfQuotes)
            .Select(_ => client.GetStringAsync(quoteUrl))
            .ToList();
        string[] quoteResponse = await Task.WhenAll(quoteTasks);
        Dictionary<string, List<string>> quotesGroupedByAuthor = GroupQuotesByAuthor(quoteResponse);
        Console.WriteLine("Processing ended at: " + DateTime.Now);
        return quotesGroupedByAuthor;
    }
}
