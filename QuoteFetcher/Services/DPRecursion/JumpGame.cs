namespace QuoteFetcher.Services.DPRecursion;

public static class JumpGame
{
    public static bool CanJump(List<int> numbers)
    {
        return Jump(numbers, 0);
    }

    private static bool Jump(List<int> numbers, int i)
    {
        if (i > numbers.Count)
        {
            return false;
        }

        if (i == numbers.Count - 1)
        {
            return true;
        }

        for (int j = 1; j <= numbers[i]; j++)
        {
            if (Jump(numbers, i + j))
            {
                return true;
            }
        }

        return false;
    }
}
