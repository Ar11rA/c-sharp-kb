namespace QuoteFetcher.Services.HashMap;

public static class CountPairs
{
    public static int getDistinctPairCount(List<int> numbers, int k)
    {
        Dictionary<int, bool> numberPresence = numbers.Aggregate(new Dictionary<int, bool>(), (acc, curr) =>
        {
            acc[curr] = true;
            return acc;
        });
        return numberPresence.Keys.Aggregate(0, (acc, key) =>
        {
            if (numberPresence.ContainsKey(key + k))
            {
                acc += 1;
            }

            return acc;
        });
    }
}
