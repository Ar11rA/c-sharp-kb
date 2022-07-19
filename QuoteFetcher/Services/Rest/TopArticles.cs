using System.Text.Json;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Rest;

public static class TopArticles
{
    private static async Task<List<Article>> FetchAllArticles()
    {
        HttpClient client = new();
        int page = 1;
        List<Article> articles = new();
        while (true)
        {
            string url = $"https://jsonmock.hackerrank.com/api/articles?page={page}";
            string jsonData = await client.GetStringAsync(url);
            ArticleData? response = JsonSerializer.Deserialize<ArticleData>(jsonData);
            if (response == null)
            {
                continue;
            }

            articles.AddRange(response.Data);
            page++;
            if (page > response.TotalPages)
            {
                break;
            }
        }

        return articles;
    }

    public static async Task<List<string>> GetMostViewedArticles(int limit)
    {
        List<Article> articles = await FetchAllArticles();
        List<Article> orderedArticles = articles
            .OrderByDescending(article => article.NumberOfComments)
            .ToList();
        return Enumerable.Range(1, limit)
            .Select(index => orderedArticles[index].Title)
            .ToList();
    }
}
