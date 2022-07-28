namespace QuoteFetcher.Services.Greedy;

public static class FlowerPlacer
{
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int ctr = 0;
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] != 0)
            {
                continue;
            }

            bool isLeftFree = (i == 0) || flowerbed[i - 1] == 0;
            bool isRightFree = (i == flowerbed.Length - 1) || flowerbed[i + 1] == 0;
            if (!isLeftFree || !isRightFree)
            {
                continue;
            }

            ctr++;
            flowerbed[i] = 1;
        }

        return ctr >= n;
    }
}
