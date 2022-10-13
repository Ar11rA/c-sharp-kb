namespace QuoteFetcher.Services.DPRecursion;

public static class DecodeWays
{
    public static int RunDP(string s)
    {
        int[] dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;
        for (int i = 2; i <= s.Length; i++)
        {
            int first = s[i - 1] - '0';
            int second = int.Parse($"{s[i - 2]}{s[i - 1]}");
            if (first is >= 1 and <= 9)
            {
                dp[i] += dp[i - 1];
            }

            if (second is >= 10 and <= 26)
            {
                dp[i] += dp[i - 2];
            }
        }

        return dp[s.Length];
    }

    public static int RunRecursive(string s)
    {
        int result = Calculate(s, 0);
        return result;
    }

    private static int Calculate(string s, int i)
    {
        if (i >= s.Length)
        {
            return 1;
        }

        if (s[i] == '0')
        {
            return 0;
        }

        int ctr = Calculate(s, i + 1);
        if (i + 1 >= s.Length)
        {
            return ctr;
        }

        int second = int.Parse($"{s[i]}{s[i + 1]}");
        if (second is >= 10 and <= 26)
        {
            ctr += Calculate(s, i + 2);
        }

        return ctr;
    }
}
