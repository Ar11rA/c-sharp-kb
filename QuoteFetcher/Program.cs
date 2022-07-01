using QuoteFetcher.DTO;
using QuoteFetcher.Services;

static void Main()
{
    QuoteService.FetchQuotes(10).GetAwaiter().GetResult();

    BinaryTree grandchildLeft = new()
    {
        Value = 15
    };
    BinaryTree grandchildRight = new()
    {
        Value = 18
    };
    BinaryTree firstChild = new()
    {
        Value = 10,
        Left = grandchildLeft,
        Right = grandchildRight
    };

    BinaryTree secondChild = new()
    {
        Value = 20
    };
    BinaryTree parent = new()
    {
        Value = 30,
        Left = firstChild,
        Right = secondChild
    };
    DepthFirstSearch.Traverse(parent);

    Console.WriteLine(CountPairs.getDistinctPairCount(new List<int> {1, 1, 1, 2, 2, 3}, 1));
    Console.WriteLine(CountPairs.getDistinctPairCount(new List<int> {1, 2, 3, 4, 5, 6}, 2));

    LinqExample.Run(new List<int> {1, 2, 3, 4, 5, 6});
    LinqExample.Run(new List<int> {2, 3, 4, 5, 6});

    Console.WriteLine(JumpGame.CanJump(new List<int> {2, 3, 1, 1, 4}));
    Console.WriteLine(JumpGame.CanJump(new List<int> {3, 2, 1, 0, 4}));
    Console.WriteLine(JumpGame.CanJump(new List<int> {1, 2, 0, 3, 0, 0}));
    Console.WriteLine(JumpGame.CanJump(new List<int> {1, 0, 2}));

    CustomerTransaction.GetTransactions("debit").GetAwaiter().GetResult();
    Console.WriteLine(RootThreshold.CountDevices(45, "STOPPED", "03-2019").GetAwaiter().GetResult());
    TopArticles.GetMostViewedArticles(2).GetAwaiter().GetResult().ForEach(Console.WriteLine);
}

Main();
