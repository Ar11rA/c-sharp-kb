namespace QuoteFetcher.Services.Greedy;

public static class MaxAreaContainer
{
    public static int Calculate(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int max = int.MinValue;
        while (left < right)
        {
            int currArea = (right - left) * System.Math.Min(height[left], height[right]);
            if (currArea > max)
            {
                max = currArea;
            }

            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return max;
    }
}
