namespace QuoteFetcher.Services.DPRecursion;

public static class Stairs
{
    public static int Climb(int n)
    {
        if (n <= 2)
        {
            return n;
        }

        return Climb(n - 1) + Climb(n - 2);
    }

    public static int MinCost(List<int> stairs)
    {
        int n = stairs.Count;
        return System.Math.Min(CalculateCost(stairs, n - 1), CalculateCost(stairs, n - 2));
    }

    public static int Tribonacci(int n)
    {
        switch (n)
        {
            case 0:
            case 1:
                return n;
            case 2:
                return 1;
            default:
                return Tribonacci(n - 3) + Tribonacci(n - 2) + Tribonacci(n - 1);
        }
    }

    private static int CalculateCost(List<int> stairs, int n)
    {
        switch (n)
        {
            case < 0:
                return 0;
            case 0:
            case 1:
                return stairs[n];
            default:
                return stairs[n] + System.Math.Min(CalculateCost(stairs, n - 1), CalculateCost(stairs, n - 2));
        }
    }
}
