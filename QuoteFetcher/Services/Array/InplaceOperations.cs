namespace QuoteFetcher.Services.Array;

public static class InplaceOperations
{
    public static int ReplaceDuplicatesCount(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int j = 0, result = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[j])
            {
                continue;
            }

            j++;
            nums[j] = nums[i];
            result++;
        }

        return result;
    }

    public static int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int j = 0, result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                continue;
            }

            nums[j] = nums[i];
            j++;
        }

        return j;
    }
}
