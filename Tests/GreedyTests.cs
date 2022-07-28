using QuoteFetcher.Services.Greedy;
using Xunit;

namespace Tests;

public class GreedyTests
{
    [Fact]
    public void FlowerPlacer_Success()
    {
        bool result = FlowerPlacer.CanPlaceFlowers(new[] {1, 0, 0, 0, 1}, 1);
        Assert.True(result);
    }
    
    [Fact]
    public void FlowerPlacer_Failure()
    {
        bool result = FlowerPlacer.CanPlaceFlowers(new[] {1, 0, 1, 0, 1}, 1);
        Assert.False(result);
    }
    
    [Fact]
    public void AssignCookies_Success_1()
    {
        int result = AssignCookies.FindContentChildren(new[] {1, 2, 3}, new[] {1, 1});
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void AssignCookies_Success_2()
    {
        int result = AssignCookies.FindContentChildren(new[] {1, 2, 3}, new[] {1, 2});
        Assert.Equal(2, result);
    }
}