namespace QuoteFetcher.Services.DPRecursion;

using System;

public static class CoinGame
{
    // optimistic - wrong approach
    public static int Calculate(int[] coins, int amount)
    {
        System.Array.Sort(coins);
        int ctr = 0, index = coins.Length - 1;
        while (amount > 0)
        {
            int count = amount / coins[index];
            amount -= coins[index] * count;
            ctr += count;
            index--;
            if (index < 0 && amount > 0)
            {
                return -1;
            }
        }

        return ctr;
    }

    // Tabulation - correct approach
    public static int CalculateDP(int[] coins, int amount)
    {
        int[,] dp = new int[coins.Length + 1, amount + 1];
        for (int i = 0; i < amount + 1; i++)
        {
            dp[0, i] = int.MaxValue;
        }

        for (int i = 0; i < coins.Length + 1; i++)
        {
            dp[i, 0] = 0;
        }

        for (int i = 1; i < coins.Length + 1; i++)
        {
            for (int j = 1; j < amount + 1; j++)
            {
                if (j < coins[i - 1])
                {
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    int take = dp[i, j - coins[i - 1]] == int.MaxValue
                        ? int.MaxValue
                        : 1 + dp[i, j - coins[i - 1]];
                    int leave = dp[i - 1, j];
                    dp[i, j] = Math.Min(take, leave);
                }
            }
        }

        return dp[coins.Length, amount] == int.MaxValue
            ? -1
            : dp[coins.Length, amount];
    }
}
