namespace QuoteFetcher.Services.String;

public static class DnaSequence
{
    public static IList<string> Find(string s)
    {
        HashSet<string> hs = new();
        HashSet<string> res = new();
        if (s.Length < 10)
        {
            return res.ToList();
        }

        for (int i = 0; i <= s.Length - 10; i++)
        {
            string current = s.Substring(i, 10);
            if (hs.Contains(current))
            {
                res.Add(current);
            }
            else
            {
                hs.Add(current);
            }
        }

        return res.ToList();
    }
}