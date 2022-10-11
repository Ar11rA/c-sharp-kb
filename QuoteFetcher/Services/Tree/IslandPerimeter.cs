namespace QuoteFetcher.Services.Tree;

public static class IslandPerimeter
{
    public static int Run(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        Queue<(int, int)> queue = new();
        Dictionary<(int, int), bool> visited = new();
        int perimeter = 0;

        // find first 1
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    queue.Enqueue((i, j));
                    break;
                }
            }

            if (queue.Count > 0)
            {
                break;
            }
        }

        // bfs
        while (queue.Count > 0)
        {
            int sides = 4;
            (int r, int c) = queue.Dequeue();
            if (visited.ContainsKey((r, c)))
            {
                continue;
            }

            visited[(r, c)] = true;
            // check if anyone of these is 1
            // up
            if (r - 1 >= 0 && grid[r - 1][c] == 1)
            {
                sides--;
                if (!visited.ContainsKey((r - 1, c)))
                {
                    queue.Enqueue((r - 1, c));
                }
            }

            // down
            if (r + 1 < m && grid[r + 1][c] == 1)
            {
                sides--;
                if (!visited.ContainsKey((r + 1, c)))
                {
                    queue.Enqueue((r + 1, c));
                }
            }

            // right
            if (c - 1 >= 0 && grid[r][c - 1] == 1)
            {
                sides--;
                if (!visited.ContainsKey((r, c - 1)))
                {
                    queue.Enqueue((r, c - 1));
                }
            }

            // left
            if (c + 1 < n && grid[r][c + 1] == 1)
            {
                sides--;
                if (!visited.ContainsKey((r, c + 1)))
                {
                    queue.Enqueue((r, c + 1));
                }
            }

            perimeter += sides;
        }

        return perimeter;
    }
}
