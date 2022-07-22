namespace QuoteFetcher.Services.BinarySearch;

public static class KokoEatingBananas
{
    public static int GetMinEatingSpeed(List<int> piles, int hours)
    {
        int low = 1, high = piles.Max();
        while (low < high)
        {
            int mid = (low + high) / 2;
            int threshold = piles.Aggregate(0, (acc, curr) => acc + (int) System.Math.Ceiling((double) curr / mid));
            if (threshold <= hours)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return high;
    }
}
