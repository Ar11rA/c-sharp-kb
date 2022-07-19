namespace QuoteFetcher.Services;

public static class PascalTriangle
{
    public static List<List<int>> Generate(int numRows)
    {
        List<List<int>> triangle = new();
        triangle.Add(new List<int> {1});
        if (numRows == 1)
        {
            return triangle;
        }
        triangle.Add(new List<int>{1,1});
        if (numRows == 2)
        {
            return triangle;
        }

        for (int i = 2; i < numRows; i++)
        {
            List<int> temp = new() {1};
            for (int j = 2; j <= i; j++)
            {
                temp.Add(triangle[i-1][j-2] + triangle[i-1][j-1]);
            }
            temp.Add(1);
            triangle.Add(temp);
        }

        return triangle;
    }
}
