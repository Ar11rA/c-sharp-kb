using QuoteFetcher.DTO;
using QuoteFetcher.Services.Tree;
using Xunit;

namespace Tests;

public class TreeTests
{
    [Fact]
    public void HasPathSum_Success()
    {
        BinaryTree bt = new()
        {
            Value = 1,
            Left = null,
            Right = new BinaryTree
            {
                Value = 2,
                Left = null,
                Right = null
            }
        };
        bool result1 = PathSum.HasPathSum(bt, 4);
        bool result2 = PathSum.HasPathSum(bt, 3);
        Assert.False(result1);
        Assert.True(result2);
    }

    [Fact]
    public void TreeTraversal_Success()
    {
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
        TreeTraversal.DfsRecursive(parent);
        TreeTraversal.DfsIterative(parent);
        TreeTraversal.BfsIterative(parent);
    }
}
