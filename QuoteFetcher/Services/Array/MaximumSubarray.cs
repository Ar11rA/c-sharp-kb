namespace QuoteFetcher.Services.Array;

using System;

public static class MaximumSubarray
{
    public static int Calculate(int[] array)
    {
        int max = array[0];
        int[] dp = new int[array.Length];
        dp[0] = array[0];
        for (int index = 1; index < array.Length; index++)
        {
            dp[index] = Math.Max(array[index], array[index] + dp[index - 1]);
            max = Math.Max(max, dp[index]);
        }

        return max;
    }
}
