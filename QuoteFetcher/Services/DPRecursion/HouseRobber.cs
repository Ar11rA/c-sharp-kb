namespace QuoteFetcher.Services.DPRecursion;

public static class HouseRobber
{
    private static int fn(int[] nums, int i)
    {
        if (i >= nums.Length)
        {
            return 0;
        }

        int option1 = fn(nums, i + 1);
        int option2 = nums[i] + fn(nums, i + 2);
        return System.Math.Max(option1, option2);
    }

    public static int RobRecursive(int[] nums)
    {
        return fn(nums, 0);
    }

    public static int RobDP(int[] nums)
    {
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        if (nums.Length == 1)
        {
            return dp[0];
        }

        dp[1] = System.Math.Max(dp[0], nums[1]);
        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = System.Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[nums.Length - 1];
    }

    public static int RobDPCircle(int[] nums)
    {
        if(nums.Length == 0)
            return 0;

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        if (nums.Length == 1)
        {
            return dp[0];
        }

        dp[1] = System.Math.Max(dp[0], nums[1]);
        for (int i = 2; i < nums.Length - 1; i++)
        {
            dp[i] = System.Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        int tmp = dp[nums.Length - 2];
        dp[0] = 0;
        dp[1] = nums[1];
        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = System.Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return System.Math.Max(tmp, dp[nums.Length - 1]);
    }
}
