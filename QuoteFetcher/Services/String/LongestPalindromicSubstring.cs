namespace QuoteFetcher.Services.String;

public static class LongestPalindromicSubstring
{
    private static bool isPalindrome(string word)
    {
        return string.Concat(word.Reverse().ToList()) == word;
    }

    private static string findPalindrome(string s, int i, int j)
    {
        string res = "";
        while (i >= 0 && j < s.Length && s[i] == s[j])
        {
            res = s.Substring(i, j - i + 1);
            i--;
            j++;
        }

        return res;
    }

    public static string BruteForce(string word)
    {
        int max = 0;
        string result = "";
        for (int iter1 = 0; iter1 < word.Length; iter1++)
        {
            for (int iter2 = iter1 + 1; iter2 <= word.Length; iter2++)
            {
                string substring = word.Substring(iter1, word.Length - iter2 + 1);
                if (isPalindrome(substring) && substring.Length > max)
                {
                    result = substring;
                    max = substring.Length;
                }
            }
        }

        return result;
    }

    public static string ExpandAroundCenter(string word)
    {
        if (word.Length == 1)
            return word;
        
        string result = "";
        for (int iter = 0; iter < word.Length; iter++)
        {
            string s1 = findPalindrome(word, iter, iter);
            string s2 = findPalindrome(word, iter, iter+1);
            
            result = s1.Length > result.Length ? s1 : result;
            result = s2.Length > result.Length ? s2 : result;
        }

        return result;
    }
}
