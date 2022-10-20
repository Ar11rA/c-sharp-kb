namespace QuoteFetcher.Services.String;

public static class CountAndSay
{
    public static string Run(int n)
    {
        string s = "1";
        for (int i = 1; i < n; i++)
        {
            s = calculate(s);
        }

        return s;
    }

    private static string calculate(string s)
    {
        char init = s[0];
        string res = "";
        int count = 1;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == init)
            {
                count++;
            }
            else
            {
                res += $"{count}{init}";
                init = s[i];
                count = 1;
            }
        }
        res += $"{count}{init}";
        return res;
    }
}
