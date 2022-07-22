namespace QuoteFetcher.Services.String;

public static class GroupAnagrams
{
    private static string SortString(string input)
    {
        char[] characters = input.ToArray();
        System.Array.Sort(characters);
        return new string(characters);
    }

    public static List<List<string>> Run(List<string> words)
    {
        Dictionary<string, List<string>> anagrams = words.Aggregate(new Dictionary<string, List<string>>(),
            (acc, curr) =>
            {
                string sortedCurr = SortString(curr);
                if (!acc.ContainsKey(sortedCurr))
                {
                    acc[sortedCurr] = new List<string> {curr};
                }
                else
                {
                    acc[sortedCurr].Add(curr);
                }

                return acc;
            });
        return anagrams.Values.ToList();
    }
}
