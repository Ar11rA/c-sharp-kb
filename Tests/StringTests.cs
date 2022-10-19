using System.Collections.Generic;
using QuoteFetcher.Services.Greedy;
using QuoteFetcher.Services.String;
using Xunit;

namespace Tests;

public class StringTests
{
    [Fact]
    public void Converter_Success()
    {
        int result1 = Converter.RomanToNumber("IV");
        Assert.Equal(4, result1);
        result1 = Converter.RomanToNumber("XVII");
        Assert.Equal(17, result1);
        string result2 = Converter.NumberToRoman(45);
        Assert.Equal("XLV", result2);
        result2 = Converter.NumberToRoman(14);
        Assert.Equal("XIV", result2);
        int result3 = Converter.StrStr("hello", "ll");
        Assert.Equal(2, result3);
        int result4 = Converter.LengthOfLastWord("   world");
        Assert.Equal(5, result4);
        Converter.LengthOfLastWord("Hello world ");
        Assert.Equal(5, result4);
    }

    [Fact]
    public void LongestCommonPrefix_Success()
    {
        string res = LongestCommonPrefix.Find(new List<string> {"flow", "flight", "flower"});
        Assert.Equal("fl", res);
    }

    [Fact]
    public void GroupedAnagram_Success()
    {
        List<List<string>> groupedAnagrams =
            GroupAnagrams.Run(new List<string> {"eat", "tea", "tan", "ate", "nat", "bat"});
        Assert.Equal(3, groupedAnagrams.Count);
    }

    [Fact]
    public void LongestNonRepeatingSubstring_Success()
    {
        int res = LongestNonRepeatingSubstring.FindSubstring("abcabcbb");
        Assert.Equal(3, res);
        res = LongestNonRepeatingSubstring.FindSubstring("bbbbb");
        Assert.Equal(1, res);
    }

    [Fact]
    public void DiStringMatch_Success()
    {
        int[] res = DiString.DiStringMatch("IDID");
        Assert.Equal(new[] {0, 4, 1, 3, 2}, res);
    }

    [Fact]
    public void AreIsomorphic_Success()
    {
        bool res = Checker.AreIsomorphic("egg", "add");
        Assert.True(res);
        res = Checker.AreIsomorphic("foo", "bar");
        Assert.False(res);
        res = Checker.AreIsomorphic("paper", "title");
        Assert.True(res);
        res = Checker.AreIsomorphic("badc", "baba");
        Assert.False(res);
    }

    [Fact]
    public void FormSentence_Success()
    {
        string res = DiscountParser.FormSentence("there are $1 $2 and 5$ candies in the shop", 50);
        Assert.Equal("there are $0.50 $1.00 and 5$ candies in the shop", res);
    }
    
    [Fact]
    public void LongestPalindromicSubstring_Success()
    {
        string res = LongestPalindromicSubstring.BruteForce("babad");
        Assert.Matches("bab|aba", res);
        res = LongestPalindromicSubstring.BruteForce("cbbd");
        Assert.Equal("bb", res);
        res = LongestPalindromicSubstring.BruteForce("abcd");
        Assert.Matches("a|b|c|d", res);
        
        res = LongestPalindromicSubstring.ExpandAroundCenter("babad");
        Assert.Matches("bab|aba", res);
        res = LongestPalindromicSubstring.ExpandAroundCenter("cbbd");
        Assert.Equal("bb", res);
        res = LongestPalindromicSubstring.ExpandAroundCenter("abcd");
        Assert.Matches("a|b|c|d", res);
    }
    
    [Fact]
    public void ZigZagConversion_Success()
    {
        string res = ZigZagConversion.Convert("PAYPALISHIRING", 3);
        Assert.Equal("PAHNAPLSIIGYIR", res);
        res = ZigZagConversion.Convert("PAYPALISHIRING", 4);
        Assert.Equal("PINALSIGYAHRPI", res);
    }
    
    [Fact]
    public void DnaSequence_Success()
    {
        List<string> res = (List<string>) DnaSequence.Find("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT");
        Assert.Equal(2, res.Count);
    }
}
