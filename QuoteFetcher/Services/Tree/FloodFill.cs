namespace QuoteFetcher.Services.Tree;

public static class FloodFill
{
    private static bool isInsideMatrix(int m, int n, int i, int j)
    {
        return i >= 0 && i < m && j >= 0 && j < n;
    }

    private static void bfs(int[][] image, int i, int j, int color, int startColor)
    {
        int m = image.Length, n = image[0].Length;
        Queue<(int, int)> queue = new();
        queue.Enqueue((i, j));
        while (queue.Count > 0)
        {
            (int r, int c) = queue.Dequeue();
            image[r][c] = color;
            // up
            if (isInsideMatrix(m, n, r - 1, c) && image[r - 1][c] == startColor)
            {
                image[r - 1][c] = color;
                queue.Enqueue((r - 1, c));
            }

            // down
            if (isInsideMatrix(m, n, r + 1, c) && image[r + 1][c] == startColor)
            {
                image[r + 1][c] = color;
                queue.Enqueue((r + 1, c));
            }

            // left
            if (isInsideMatrix(m, n, r, c - 1) && image[r][c - 1] == startColor)
            {
                image[r][c - 1] = color;
                queue.Enqueue((r, c - 1));
            }

            // right
            if (isInsideMatrix(m, n, r, c + 1) && image[r][c + 1] == startColor)
            {
                image[r][c + 1] = color;
                queue.Enqueue((r, c + 1));
            }
        }
    }

    public static int[][] Run(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] != color)
        {
            bfs(image, sr, sc, color, image[sr][sc]);
        }

        return image;
    }
}
