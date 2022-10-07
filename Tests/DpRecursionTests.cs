using System.Collections.Generic;
using QuoteFetcher.Services.DPRecursion;
using Xunit;

namespace Tests;

public class DpRecursionTests
{
    [Fact]
    public void JumpGame_Success()
    {
        bool canJump = JumpGame.CanJump(new List<int> {2, 3, 1, 1, 4});
        int jumps = JumpGame.CountMinJumps(new List<int> {2, 3, 1, 1, 4});
        Assert.True(canJump);
        Assert.Equal(2, jumps);
    }

    [Fact]
    public void JumpGame_Failure()
    {
        bool canJump = JumpGame.CanJump(new List<int> {3, 2, 1, 0, 4});
        int jumps = JumpGame.CountMinJumps(new List<int> {3, 2, 1, 0, 4});
        Assert.False(canJump);
        Assert.Equal(-1, jumps);
    }

    [Fact]
    public void Climb_Success()
    {
        int jumps = Stairs.Climb(3);
        Assert.Equal(3, jumps);
    }

    [Fact]
    public void Tribonacci_Success()
    {
        int result = Stairs.Tribonacci(3);
        Assert.Equal(2, result);
    }

    [Fact]
    public void MinCost_Success()
    {
        int result = Stairs.MinCost(new List<int> {10, 15, 20});
        Assert.Equal(15, result);
    }

    [Fact]
    public void LetterCombinationsPhone_Success()
    {
        List<string> result = LetterCombinationsPhone.FindCombinations("23");
        Assert.Equal(new List<string>
        {
            "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
        }, result);
    }

    [Fact]
    public void LetterCombinationsPhoneLinq_Success()
    {
        List<string> result = LetterCombinationsPhone.FindCombinationsLinq("23");
        Assert.Equal(new List<string>
        {
            "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
        }, result);
    }

    [Fact]
    public void UniquePaths_Success_1()
    {
        int result = UniquePaths.CalculateWithoutObstacle(7, 3);
        Assert.Equal(28, result);
    }

    [Fact]
    public void UniquePaths_Success_2()
    {
        int result = UniquePaths.CalculateWithObstacles(new int[][]
        {
            new[] {0, 0, 0},
            new[] {0, 1, 0},
            new[] {0, 0, 0}
        });
        Assert.Equal(2, result);
        
        result = UniquePaths.CalculateWithObstacles(new int[][]
        {
            new[] {1, 0},
        });
        Assert.Equal(0, result);
    }
}
