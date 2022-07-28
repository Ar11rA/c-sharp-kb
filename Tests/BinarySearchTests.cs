using System.Collections.Generic;
using QuoteFetcher.Services.Array;
using QuoteFetcher.Services.BinarySearch;
using Xunit;

namespace Tests;

public class BinarySearchTests
{
    [Fact]
    public void KokoEatingBananas_Success_1()
    {
        int result = KokoEatingBananas.GetMinEatingSpeed(new List<int> {30, 11, 23, 4, 20}, 5);
        Assert.Equal(30, result);
    }

    [Fact]
    public void KokoEatingBananas_Success_2()
    {
        int result = KokoEatingBananas.GetMinEatingSpeed(new List<int> {30, 11, 23, 4, 20}, 6);
        Assert.Equal(23, result);
    }

    [Fact]
    public void KokoEatingBananas_Success_3()
    {
        int result = KokoEatingBananas.GetMinEatingSpeed(new List<int> {3, 6, 7, 11}, 8);
        Assert.Equal(4, result);
    }

    [Fact]
    public void MinimumRotatedSortedArray_Success()
    {
        int result = MinimumRotatedSortedArray.FindMin(new List<int> {3, 4, 5, 1, 2});
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void SquareRoot_Success_1()
    {
        int result = SquareRoot.MySqrt(16);
        Assert.Equal(4, result);
    }
    
    [Fact]
    public void SquareRoot_Success_2()
    {
        int result = SquareRoot.MySqrt(27);
        Assert.Equal(5, result);
    }
}
