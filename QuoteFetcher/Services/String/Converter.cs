namespace QuoteFetcher.Services.String;

public static class Converter
{
    public static int RomanToNumber(string input)
    {
        Dictionary<char, int> romanValues = new()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        int result = 0;
        for (int index = 0; index <= input.Length - 2; index++)
        {
            int currentValue = romanValues[input[index]];
            int nextValue = romanValues[input[index + 1]];
            result += (currentValue < nextValue ? -1 : 1) * currentValue;
        }

        result += romanValues[input[^1]];
        return result;
    }

    public static string NumberToRoman(int input)
    {
        int[] val = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] rom = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        int index = 0;
        string result = "";
        while (input > 0)
        {
            while (input >= val[index])
            {
                result += rom[index];
                input -= val[index];
            }

            index++;
        }

        return result;
    }

    public static int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
        {
            return 0;
        }

        int len = haystack.Length - needle.Length;
        for (int i = 0; i <= len; i++)
        {
            int j = i;
            foreach (char _ in needle.TakeWhile(word => word == haystack[j]))
            {
                j++;
            }

            if (j - i != needle.Length)
            {
                continue;
            }

            return i;
        }

        return -1;
    }

    public static int LengthOfLastWord(string s)
    {
        string trimmed = s.Trim();
        int endPtr = trimmed.Length - 1;
        while (endPtr > 0)
        {
            if (trimmed[endPtr] == ' ')
            {
                break;
            }

            endPtr--;
        }

        return trimmed.Contains(' ') ? trimmed.Length - 1 - endPtr : trimmed.Length - endPtr;
    }
}
