using System;
using System.Collections.Generic;
using QuoteFetcher.Services.OOPS;
using Xunit;

namespace Tests;

public class OopsTests
{
    [Fact]
    public void NumberContainerTests()
    {
        NumberContainer container = new();
        container.Change(2, 10);
        container.Change(1, 10);
        container.Change(3, 10);
        container.Change(5, 10);
        int res = container.Find(10);
        Assert.Equal(1, res);
    }

    [Fact]
    public void AtmMachineTests()
    {
        AtmMachine atm = new();
        atm.Deposit(new[] {0, 0, 1, 2, 1});
        int[] res = atm.Withdraw(600);
        Assert.Equal(new[] {0, 0, 1, 0, 1}, res);
        atm.Deposit(new[] {0, 1, 0, 1, 1});
        res = atm.Withdraw(600);
        Assert.Equal(new[] {-1}, res);
    }

    [Fact]
    public void FoodRatingSystemTests_Success()
    {
        FoodRatingSystem foodRatingSystem = new(
            new[] {"kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi"},
            new[] {"korean", "japanese", "japanese", "greek", "japanese", "korean"},
            new[] {9, 12, 8, 15, 14, 7}
        );
        Assert.Equal("ramen", foodRatingSystem.HighestRated("japanese"));
    }
    
    [Fact]
    public void FoodRatingSystemTests_NoSuchCuisine()
    {
        FoodRatingSystem foodRatingSystem = new(
            new[] {"kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi"},
            new[] {"korean", "japanese", "japanese", "greek", "japanese", "korean"},
            new[] {9, 12, 8, 15, 14, 7}
        );
        Exception exception = Assert.Throws<Exception>(() => foodRatingSystem.HighestRated("indian"));
        Assert.Equal("Cuisine not found!", exception.Message);
    }

    [Fact]
    public void TwitterTests_Success()
    {
        Twitter twitter = new();
        twitter.PostTweet(1, 5);
        Assert.Equal(new List<int> {5}, twitter.GetNewsFeed(1));
        twitter.Follow(1, 2);
        twitter.PostTweet(2, 6);
        Assert.Equal(new List<int> {6, 5}, twitter.GetNewsFeed(1));
        twitter.Unfollow(1, 2);
        Assert.Equal(new List<int> {5}, twitter.GetNewsFeed(1));
    }


    [Fact]
    public void TwitterTests_TweetIDExists()
    {
        Twitter twitter = new();
        twitter.PostTweet(1, 5);
        Exception exception = Assert.Throws<Exception>(() => twitter.PostTweet(2, 5));
        Assert.Equal("Tweet ID exists!", exception.Message);
    }
    
    [Fact]
    public void TwitterTests_NoSuchUser()
    {
        Twitter twitter = new();
        twitter.PostTweet(1, 5);
        Exception exception = Assert.Throws<Exception>(() => twitter.GetNewsFeed(2));
        Assert.Equal("No such user!", exception.Message);
    }
}
