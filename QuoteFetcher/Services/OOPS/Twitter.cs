using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.OOPS;

public class Twitter
{
    private readonly List<Tweet> _tweets;
    private readonly Dictionary<int, HashSet<int>> _userToFollowers;
    private readonly Dictionary<int, List<Tweet>> _userToTweets;

    public Twitter()
    {
        _tweets = new List<Tweet>();
        _userToTweets = new Dictionary<int, List<Tweet>>();
        _userToFollowers = new Dictionary<int, HashSet<int>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (_tweets.FindIndex(t => t.TweetId == tweetId) != -1)
        {
            throw new Exception("Tweet ID exists!");
        }

        Tweet tweet = new(tweetId);
        _tweets.Add(tweet);
        if (!_userToTweets.ContainsKey(userId))
        {
            _userToTweets[userId] = new List<Tweet> {tweet};
        }
        else
        {
            _userToTweets[userId].Add(tweet);
        }
    }

    public IList<int> GetNewsFeed(int userId)
    {
        PriorityQueue<Tweet, Tweet> tweetIds =
            new(Comparer<Tweet>.Create((t1, t2) => DateTime.Compare(t2.CreatedAt, t1.CreatedAt)));

        if (!_userToTweets.ContainsKey(userId))
        {
            throw new Exception("No such user!");
        }

        _userToTweets[userId].ForEach(tweet => { tweetIds.Enqueue(tweet, tweet); });

        if (_userToFollowers.ContainsKey(userId))
        {
            HashSet<int> followers = _userToFollowers[userId];
            followers.ToList().ForEach(uid =>
            {
                List<Tweet> tweets = _userToTweets[uid];
                tweets.ForEach(tweet => { tweetIds.Enqueue(tweet, tweet); });
            });
        }

        List<int> result = new();
        int ctr = 1;
        while (tweetIds.Count > 0)
        {
            result.Add(tweetIds.Dequeue().TweetId);
            ctr++;
            if (ctr == 10)
            {
                break;
            }
        }

        return result;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!_userToFollowers.ContainsKey(followerId))
        {
            _userToFollowers[followerId] = new HashSet<int> {followeeId};
        }
        else
        {
            _userToFollowers[followerId].Add(followeeId);
        }
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (_userToFollowers.ContainsKey(followerId))
        {
            _userToFollowers[followerId].Remove(followeeId);
        }
    }
}
