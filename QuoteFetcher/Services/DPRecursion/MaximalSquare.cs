namespace QuoteFetcher.Services.DPRecursion;

public static class MaximalSquare
{
    public static int Calculate(char[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length, maxSide = 0;
        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = matrix[i][0] - '0';
            if (dp[i, 0] > maxSide)
            {
                maxSide = dp[i, 0];
            }
        }

        for (int j = 0; j < n; j++)
        {
            dp[0, j] = matrix[0][j] - '0';
            if (dp[0, j] > maxSide)
            {
                maxSide = dp[0, j];
            }
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = matrix[i][j] == '1'
                    ? System.Math.Min(System.Math.Min(dp[i - 1, j], dp[i, j - 1]),
                        dp[i - 1, j - 1]) + 1
                    : 0;
                if (dp[i, j] > maxSide)
                {
                    maxSide = dp[i, j];
                }
            }
        }

        return maxSide * maxSide;
    }
}
