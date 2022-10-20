namespace QuoteFetcher.Services.Array;

public static class Backtracking
{
    private static void SubsetFn(int[] nums, int i, List<int> tmp, List<IList<int>> res)
    {
        res.Add(new List<int>(tmp));

        for (int index = i; index < nums.Length; index++)
        {
            tmp.Add(nums[index]);
            SubsetFn(nums, index + 1, new List<int>(tmp), res);
            tmp.Remove(nums[index]);
        }
    }

    public static IList<IList<int>> Subsets(int[] nums)
    {
        System.Array.Sort(nums);
        List<IList<int>> res = new();
        SubsetFn(nums, 0, new List<int>(), res);
        return res;
    }

    private static void PermuteFn(int[] nums, List<int> tmp, List<IList<int>> res)
    {
        if (tmp.Count == nums.Length)
        {
            res.Add(new List<int>(tmp));
        }

        foreach (int num in nums)
        {
            if (tmp.Contains(num))
            {
                continue;
            }

            tmp.Add(num);
            PermuteFn(nums, new List<int>(tmp), res);
            tmp.Remove(num);
        }
    }

    public static IList<IList<int>> Permute(int[] nums)
    {
        System.Array.Sort(nums);
        List<IList<int>> res = new();
        PermuteFn(nums, new List<int>(), res);
        return res;
    }

    private static void CombinationFn(int[] candidates, int target, int start, List<int> tmp, List<IList<int>> res)
    {
        if (target == 0)
        {
            res.Add(new List<int>(tmp));
            return;
        }

        for (int i = start;  i < candidates.Length && candidates[i] <= target; i++)
        {
            tmp.Add(candidates[i]);
            CombinationFn(candidates, target - candidates[i], i, new List<int>(tmp), res);
            tmp.RemoveAt(tmp.Count - 1);
        }
    }
    
    public static IList<IList<int>> CombinationSum(int[] candidates, int target) {
        System.Array.Sort(candidates);
        List<IList<int>> result = new();
        CombinationFn(candidates, target, 0, new List<int>(), result);
        return result;
    }
}
