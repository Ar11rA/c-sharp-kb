namespace QuoteFetcher.Services.DPRecursion;

using System;

public static class MaxPathSum
{
    private static int tabulateSumTop(List<List<int>> board, int p)
    {
        int[,] dp = new int[board.Count, board[0].Count];
        int res = int.MinValue;
        for (int i = 0; i < board[0].Count; i++)
        {
            dp[0, i] = board[0][p];
        }

        for (int i = 1; i < board.Count; i++)
        {
            for (int j = p - 1; j <= p + 1; j++)
            {
                if (j < 0 || j > board[0].Count - 1)
                {
                    continue;
                }
                if (j == 0)
                {
                    dp[i, j] = Math.Max(board[i][j] + dp[i - 1, j], board[i][j + 1] + dp[i - 1, j]);
                }
                else if (j == board[0].Count - 1)
                {
                    dp[i, j] = Math.Max(board[i][j] + dp[i - 1, j], board[i][j - 1] + dp[i - 1, j]);
                }
                else
                {
                    dp[i, j] = Math.Max(board[i][j + 1] + dp[i - 1, j],
                        Math.Max(board[i][j] + dp[i - 1, j], board[i][j - 1] + dp[i - 1, j]));
                }

                if (i == board.Count - 1 && dp[i, j] > res)
                {
                    res = dp[i, j];
                }
            }
        }
        
        return res;
    }
    
    private static int tabulateSumBottom(List<List<int>> board, int q)
    {
        int[,] dp = new int[board.Count, board[0].Count];
        int res = int.MinValue;
        for (int i = 0; i < board[0].Count; i++)
        {
            dp[board.Count - 1, i] = board[^1][q];
        }

        for (int i = board.Count - 2; i >= 0; i--)
        {
            for (int j = q - 1; j <= q + 1; j++)
            {
                if (j < 0 || j > board[0].Count - 1)
                {
                    continue;
                }
                if (j == 0)
                {
                    dp[i, j] = Math.Max(board[i][j] + dp[i + 1, j], board[i][j + 1] + dp[i + 1, j]);
                }
                else if (j == board[0].Count - 1)
                {
                    dp[i, j] = Math.Max(board[i][j] + dp[i + 1, j], board[i][j - 1] + dp[i + 1, j]);
                }
                else
                {
                    dp[i, j] = Math.Max(board[i][j + 1] + dp[i + 1, j],
                        Math.Max(board[i][j] + dp[i + 1, j], board[i][j + 1] + dp[i + 1, j]));
                }

                if (i == 0 && dp[i, j] > res)
                {
                    res = dp[i, j];
                }
            }
        }
        
        return res;
    }

    public static int Run(List<List<int>> board, int p, int q)
    {
        switch (board.Count)
        {
            case 0:
                return 0;
            case 1:
                return board[0].Max();
        }

        // 0, p or len - 1, q
        int res1 = tabulateSumTop(board, p);
        int res2 = tabulateSumBottom(board, q);
        return Math.Max(res1, res2);
    }
}
