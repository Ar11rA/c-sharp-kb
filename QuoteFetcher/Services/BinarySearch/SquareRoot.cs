namespace QuoteFetcher.Services.BinarySearch;

public static class SquareRoot
{
    public static int MySqrt(int x)
    {
        int low = 1, high = x;
        while (true)
        {
            int mid = (low + high) / 2;
            if (mid * mid <= x && x < (mid + 1) * (mid + 1))
            {
                return mid;
            }

            if (mid * mid > x)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
    }
}
