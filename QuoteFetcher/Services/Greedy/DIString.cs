namespace QuoteFetcher.Services.Greedy;

public static class DIString
{
    public static int[] DiStringMatch(string s)
    {
        int[] result = new int[s.Length + 1];
        int lowPtr = 0, highPtr = s.Length;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'D')
            {
                result[i] = highPtr;
                highPtr--;
            }
            if (s[i] == 'I')
            {
                result[i] = lowPtr;
                lowPtr++;
            }
        }

        result[s.Length] = s[^1] == 'D' ? highPtr : lowPtr;
        return result;
    }
}
