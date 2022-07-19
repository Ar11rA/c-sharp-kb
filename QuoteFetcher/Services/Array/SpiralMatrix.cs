namespace QuoteFetcher.Services.Array;

public static class SpiralMatrix
{
    public static List<int> Traverse(List<List<int>> matrix)
    {
        int n = matrix.Count, m = matrix[0].Count, left = 0, right = m - 1, bottom = n - 1, top = 0;
        int direction = 1;
        List<int> traversedList = new();
        while (left <= right && top <= bottom)
        {
            switch (direction)
            {
                case 1:
                {
                    for (int i = left; i <= right; i++)
                    {
                        traversedList.Add(matrix[top][i]);
                    }

                    direction = 2;
                    top++;
                    break;
                }
                case 2:
                {
                    for (int i = top; i <= bottom; i++)
                    {
                        traversedList.Add(matrix[i][right]);
                    }

                    direction = 3;
                    right--;
                    break;
                }
                case 3:
                {
                    for (int i = right; i >= left; i--)
                    {
                        traversedList.Add(matrix[bottom][i]);
                    }

                    direction = 4;
                    bottom--;
                    break;
                }
                case 4:
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        traversedList.Add(matrix[i][left]);
                    }

                    direction = 1;
                    left++;
                    break;
                }
            }
        }

        return traversedList;
    }
}
