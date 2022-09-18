namespace QuoteFetcher.Services.Math;

public static class UglyNumber
{
    public static bool IsUgly(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        while (n % 2 == 0)
        {
            n /= 2;
        }

        while (n % 3 == 0)
        {
            n /= 3;
        }

        while (n % 5 == 0)
        {
            n /= 5;
        }

        return n == 1;
    }

    public static int NthUglyNumber(int n)
    {
        int ptr2 = 0, ptr3 = 0, ptr5 = 0;
        int[] dp = new int[n];
        dp[0] = 1;

        for (int index = 1; index < n; index++)
        {
            int min = System.Math.Min(dp[ptr2] * 2, System.Math.Min(dp[ptr3] * 3, dp[ptr5] * 5));
            dp[index] = min;
            if (dp[ptr2] * 2 == min)
            {
                ptr2++;
            }

            if (dp[ptr3] * 3 == min)
            {
                ptr3++;
            }

            if (dp[ptr5] * 5 == min)
            {
                ptr5++;
            }
        }

        return dp[n - 1];
    }
}
