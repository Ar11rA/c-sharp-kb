namespace QuoteFetcher.Services.Math;

using System;

public static class RestoreIPAddress
{
    public static IList<string> Run(string s)
    {
        List<string> result = new();
        for (int a = 1; a <= 3; a++)
        {
            for (int b = 1; b <= 3; b++)
            {
                for (int c = 1; c <= 3; c++)
                {
                    int d = s.Length - (a + b + c);
                    if (d is >= 1 and <= 3)
                    {
                        int part1 = int.Parse(s.Substring(0, a));
                        int part2 = int.Parse(s.Substring(a, b));
                        int part3 = int.Parse(s.Substring(a + b, c));
                        int part4 = int.Parse(s.Substring(a + b + c, d));
                        if (part1 <= 255 && part2 <= 255 && part3 <= 255 && part4 <= 255)
                        {
                            string store = $"{part1}.{part2}.{part3}.{part4}";
                            if (store.Length == s.Length + 3)
                            {
                                result.Add(store);
                            }
                        }
                    }
                }
            }
        }

        return result;
    }
}
