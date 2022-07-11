namespace QuoteFetcher.Services;

public static class TwoSum
{
    public static int[] FindPair(int[] nums, int target)
    {
        Dictionary<int, int> pairMap = new();
        List<int> output = new();

        for (int ind = 0; ind < nums.Length; ind++)
        {
            if (pairMap.ContainsKey(nums[ind]))
            {
                output.Add(pairMap[nums[ind]]);
                output.Add(ind);
                break;
            }

            pairMap[target - nums[ind]] = ind;
        }

        return output.ToArray();
    }
}
