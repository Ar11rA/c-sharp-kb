namespace QuoteFetcher.DTO;

public class Tweet
{
    public Tweet(int tweetId)
    {
        TweetId = tweetId;
        CreatedAt = DateTime.Now;
    }

    public int TweetId { set; get; }
    public DateTime CreatedAt { set; get; }
}
