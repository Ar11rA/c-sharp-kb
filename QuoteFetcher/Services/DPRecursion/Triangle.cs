namespace QuoteFetcher.Services.DPRecursion;

public static class Triangle
{
    public static int MinimumTotal(IList<IList<int>> triangle)
    {
        for (int i = triangle.Count - 2; i >= 0; i--)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                triangle[i][j] += System.Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
            }
        }

        return triangle[0][0];
    }

    public static int MinimumTotalRecursive(IList<IList<int>> triangle)
    {
        return fn(triangle, 0, 0);
    }

    private static int fn(IList<IList<int>> triangle, int i, int j)
    {
        if (i == triangle.Count - 1)
        {
            return triangle[i][j];
        }

        return System.Math.Min(triangle[i][j] + fn(triangle, i + 1, j), triangle[i][j] + fn(triangle, i + 1, j + 1));
    }
}
