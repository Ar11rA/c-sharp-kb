using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Tree;

public static class PathSum
{
    public static bool HasPathSum(BinaryTree? root, int targetSum)
    {
        if (root == null)
        {
            return false;
        }

        if (root.Left == null && root.Right == null && targetSum == root.Value)
        {
            return true;
        }

        return HasPathSum(root.Left, targetSum - root.Value) || HasPathSum(root.Right, targetSum - root.Value);
    }
}
