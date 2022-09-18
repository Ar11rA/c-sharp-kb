namespace QuoteFetcher.Services.String;

public static class Checker
{
    public static bool AreIsomorphic(string s, string t)
    {
        Dictionary<char, char> charMap = new();

        for (int i = 0; i < s.Length; i++)
        {
            if (charMap.ContainsKey(s[i]))
            {
                if (charMap[s[i]] != t[i])
                {
                    return false;
                }
            }
            else
            {
                if (charMap.ContainsValue(t[i]))
                {
                    return false;
                }

                charMap.Add(s[i], t[i]);
            }
        }

        return true;
    }
}
