using System.Text;

namespace QuoteFetcher.Services.DPRecursion;

public static class LetterCombinationsPhone
{
    private static readonly List<string> _letterMap = new()
    {
        "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"
    };

    private static readonly List<string> _result = new();

    public static List<string> FindCombinations(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return _result;
        }

        Combine(0, new StringBuilder(), s);
        return _result;
    }

    public static List<string> FindCombinationsLinq(string s)
    {
        List<char> chars = new();
        List<string> result = new() {""};
        chars.AddRange(s);
        chars.ForEach(c =>
        {
            List<char> possibility = _letterMap[c - '0']
                .Select(x => x)
                .ToList();
            result = result
                .SelectMany(r => possibility
                    .Select(x => r + x))
                .ToList();
        });
        return result;
    }

    private static void Combine(int start, StringBuilder str, string input)
    {
        if (str.Length == input.Length)
        {
            _result.Add(str.ToString());
            return;
        }

        string possibility = _letterMap[int.Parse(input[start].ToString())];
        foreach (char letter in possibility)
        {
            str.Append(letter);
            Combine(start + 1, str, input);
            str.Remove(str.Length - 1, 1);
        }
    }
}
