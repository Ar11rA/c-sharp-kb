namespace QuoteFetcher.Services.Tree;

public static class RottingOranges
{
    private static bool isInsideMatrix(int m, int n, int i, int j)
    {
        return i >= 0 && i < m && j >= 0 && j < n;
    }

    public static int Run(int[][] grid)
    {
        Queue<(int, int)> queue = new();
        int freshCount = 0, m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                switch (grid[i][j])
                {
                    case 2:
                        queue.Enqueue((i, j));
                        break;
                    case 1:
                        freshCount++;
                        break;
                }
            }
        }

        if (queue.Count > 0 && freshCount == 0)
        {
            return 0;
        }

        int time = 0;

        while (queue.Count > 0)
        {
            int rotten = queue.Count;
            for (int i = 0; i < rotten; i++)
            {
                (int r, int c) = queue.Dequeue();
                // up
                if (isInsideMatrix(m, n, r - 1, c) && grid[r - 1][c] == 1)
                {
                    grid[r - 1][c] = 2;
                    queue.Enqueue((r - 1, c));
                    freshCount--;
                }

                // down
                if (isInsideMatrix(m, n, r + 1, c) && grid[r + 1][c] == 1)
                {
                    grid[r + 1][c] = 2;
                    queue.Enqueue((r + 1, c));
                    freshCount--;
                }

                // left
                if (isInsideMatrix(m, n, r, c - 1) && grid[r][c - 1] == 1)
                {
                    grid[r][c - 1] = 2;
                    queue.Enqueue((r, c - 1));
                    freshCount--;
                }

                // right
                if (isInsideMatrix(m, n, r, c + 1) && grid[r][c + 1] == 1)
                {
                    grid[r][c + 1] = 2;
                    queue.Enqueue((r, c + 1));
                    freshCount--;
                }
            }
            time++;
        }

        return freshCount > 0 ? -1 : System.Math.Max(time - 1, 0);

    }
}
