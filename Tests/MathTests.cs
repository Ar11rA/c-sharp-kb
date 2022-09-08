using System.Collections.Generic;
using QuoteFetcher.Services.Math;
using Xunit;

namespace Tests;

public class MathTests
{
    [Fact]
    public void PrimeFactor_Success()
    {
        List<int> result = PrimeFactor.GetFactors(25);
        Assert.Equal(5, result[0]);
    }

    [Fact]
    public void PalindromeIsPal_Success()
    {
        bool res = Palindrome.IsPal(12321);
        Assert.True(res);
        res = Palindrome.IsPal(12);
        Assert.False(res);
        res = Palindrome.IsPal(-12);
        Assert.False(res);
    }

    [Fact]
    public void PalindromeGenerate_Success()
    {
        List<int> res = Palindrome.Generate(new List<int> {1, 2, 3, 4, 5, 90}, 3);
        Assert.Equal(new List<int> {101, 111, 121, 131, 141, 999}, res);
        res = Palindrome.Generate(new List<int> {2, 4, 6}, 4);
        Assert.Equal(new List<int> {1111, 1331, 1551}, res);
    }

    [Fact]
    public void HappyNumber_Success()
    {
        bool res = HappyNumber.Check(19);
        Assert.True(res);
        res = HappyNumber.Check(7);
        Assert.True(res);
    }
    
    [Fact]
    public void UglyNumber_IsUgly()
    {
        bool res = UglyNumber.IsUgly(6);
        Assert.True(res);
        res = UglyNumber.IsUgly(1);
        Assert.True(res);        
        res = UglyNumber.IsUgly(14);
        Assert.False(res);
    }
    
    [Fact]
    public void UglyNumber_NthUglyNumber()
    {
        int res = UglyNumber.NthUglyNumber(10);
        Assert.Equal(12, res);
        res = UglyNumber.NthUglyNumber(1);
        Assert.Equal(1, res);        
        res = UglyNumber.NthUglyNumber(7);
        Assert.Equal(8, res);
    }
}
