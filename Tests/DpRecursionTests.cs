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
}
