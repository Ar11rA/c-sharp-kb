namespace QuoteFetcher.Services.Math;

public static class Palindrome
{
    public static bool IsPal(int number)
    {
        if (number < 0 || number % 10 == 0 && number != 0)
        {
            return false;
        }

        int halvedRevertedNum = 0;
        while (number > halvedRevertedNum)
        {
            int temp = number % 10;
            halvedRevertedNum = halvedRevertedNum * 10 + temp;
            number /= 10;
        }

        return halvedRevertedNum == number || halvedRevertedNum / 10 == number;
    }

    public static List<int> Generate(List<int> queries, int length)
    {
        int half = (length + 1) / 2;
        int low = (int) System.Math.Pow(10, half - 1);
        int high = (int) System.Math.Pow(10, half) - 1;
        return queries.ConvertAll(query =>
        {
            if (query > high - low + 1)
            {
                return -1;
            }

            int firstHalf = low + query - 1;
            int secondHalf = length % 2 == 0 ? Reverse(firstHalf) : Reverse(firstHalf / 10);
            return int.Parse($"{firstHalf}{secondHalf}");
        });
    }

    private static int Reverse(int num)
    {
        int result = 0;
        while (num > 0)
        {
            result = result * 10 + num % 10;
            num /= 10;
        }

        return result;
    }
}
