namespace QuoteFetcher.Services.Math;

public static class HappyNumber
{
    public static bool Check(int n)
    {
        if (n == 1)
        {
            return true;
        }
        HashSet<int> set = new() {n};
        while (n > 0)
        {
            n = SquareUp(n);
            if (set.Contains(n))
            {
                return false;
            }
            set.Add(n);
            if (n == 1)
            {
                return true;
            }
        }

        return false;
    }

    private static int SquareUp(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int temp = n % 10;
            sum += (temp * temp);
            n /= 10;
        }

        return sum;
    }
}
