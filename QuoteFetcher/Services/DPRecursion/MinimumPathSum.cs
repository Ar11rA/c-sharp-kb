namespace QuoteFetcher.Services.DPRecursion;

public static class MinimumPathSum
{
    public static int Run(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j != 0)
                {
                    dp[i, j] = grid[i][j] + dp[i, j - 1];
                } 
                else if (j == 0 && i != 0)
                {
                    dp[i, j] = grid[i][j] + dp[i - 1, j];
                }
                else if (i == 0 && j == 0)
                {
                    dp[i, j] = grid[i][j];
                }
                else
                {
                    dp[i, j] = System.Math.Min(grid[i][j] + dp[i - 1, j], grid[i][j]+ dp[i, j - 1]);
                }
            }
        }

        return dp[m - 1, n - 1];
    }
}
