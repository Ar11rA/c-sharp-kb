namespace QuoteFetcher.Services.DPRecursion;

public static class DecodeWays
{
    public static int Run(string s)
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
