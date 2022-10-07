namespace QuoteFetcher.Services.String;

public static class ZigZagConversion
{
    public static string Convert(string s, int numRows)
    {
        if (numRows <= 1)
        {
            return s;
        }

        int ctr = 0;
        string[] result = new string[numRows];
        for (int i = 0; i < numRows; i++)
        {
            result[i] = "";
        }

        while (ctr < s.Length)
        {
            for (int i = 0; i < numRows && ctr < s.Length; i++)
            {
                result[i] += s[ctr];
                ctr++;
            }

            for (int i = numRows - 2; i >= 1 & ctr < s.Length; i--)
            {
                result[i] += s[ctr];
                ctr++;
            }
        }

        return string.Join("", result);
    }
}
