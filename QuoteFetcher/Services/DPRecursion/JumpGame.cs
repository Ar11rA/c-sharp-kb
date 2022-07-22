namespace QuoteFetcher.Services.DPRecursion;

public static class JumpGame
{
    public static bool CanJump(List<int> numbers)
    {
        return Jump(numbers, 0);
    }

    public static int CountMinJumps(List<int> numbers)
    {
        int res = CountJump(numbers, 0);
        return res == 10001 ? -1 : res;
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

    private static int CountJump(List<int> numbers, int i)
    {
        if (i >= numbers.Count - 1)
        {
            return 0;
        }

        int minJumps = 10001;
        for (int j = 1; j <= numbers[i]; j++)
        {
            minJumps = System.Math.Min(minJumps, 1 + CountJump(numbers, i + j));
        }

        return minJumps;
    }
}
