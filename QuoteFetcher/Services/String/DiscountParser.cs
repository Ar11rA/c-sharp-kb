using System.Text.RegularExpressions;

namespace QuoteFetcher.Services.String;

public static class DiscountParser
{
    public static string FormSentence(string sentence, int discount)
    {
        sentence += " ";
        int ptr1 = 0, ptr2 = 0;
        Regex pattern = new(@"\$\d+");
        string result = "";
        while (ptr2 < sentence.Length)
        {
            if (sentence[ptr2] == ' ')
            {
                string word = sentence.Substring(ptr1, ptr2 - ptr1);
                ptr1 += word.Length + 1;
                if (pattern.Match(word).Success && double.TryParse(word[1..], out double price))
                {
                    double newPrice = price - discount * price / 100;
                    word = $"${newPrice:0.00}";
                }

                result += word + " ";
            }

            ptr2++;
        }

        return result.TrimEnd();
    }
}
