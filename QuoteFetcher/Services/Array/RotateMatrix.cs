namespace QuoteFetcher.Services.Array;

public static class RotateMatrix
{
    public static void Perform90(int[][] matrix)
    {
        System.Array.Reverse(matrix);
        for (int i = 0; i < matrix.Length; i++) 
        {
            for (int j = 0; j < i; j++) 
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }
    } 
}
