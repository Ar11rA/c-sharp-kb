namespace QuoteFetcher.Services;
public static class LongestNonRepeatingSubstring
{
    public static int FindSubstring(string s)
    {
        Dictionary<char, int> characterPresence = new ();
        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (characterPresence.ContainsKey(s[i]))
            {
                result = characterPresence.Count > result ? characterPresence.Count : result;
                i = characterPresence[s[i]];
                characterPresence.Clear();
            }
            else
            {
                characterPresence.Add(s[i], i);
            }
        }
        return characterPresence.Count > result ? characterPresence.Count : result;
    }
}
