namespace QuoteFetcher.Services.String;

public static class LongestCommonPrefix
{
    public static string Find(List<string> words)
    {
        if (words.Count == 0)
        {
            return "";
        }

        int thresholdIndex = 0;
        words.Sort();
        while (thresholdIndex < words[0].Length)
        {
            if (words[0][thresholdIndex] == words[words.Count - 1][thresholdIndex])
            {
                thresholdIndex++;
            }
            else
            {
                break;
            }
        }

        return thresholdIndex > 0 ? words[0].Substring(0, thresholdIndex) : "";
    }
}
