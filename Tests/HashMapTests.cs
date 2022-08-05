using System.Collections.Generic;
using QuoteFetcher.Services.HashMap;
using Xunit;

namespace Tests;

public class HashMapTests
{
    [Fact]
    public void TwoSum_Success() {
        int[] result = TwoSum.FindPair(new[] {3, 2, 4}, 6);
        Assert.Equal(1, result[0]);
    }
    
    [Fact]
    public void GetDistinctPairCount_Success()
    {
        int result = CountPairs.GetDistinctPairCount(new List<int> {1, 1, 1, 2, 2, 3}, 1);
        Assert.Equal(2, result);
        result = CountPairs.GetDistinctPairCount(new List<int> {1, 2, 3, 4, 5, 6}, 2);
        Assert.Equal(4, result);
    }
}
