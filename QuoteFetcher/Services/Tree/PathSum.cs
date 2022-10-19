using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Tree;

public static class PathSum
{
    // recursive
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
    
    // internal calling fn
    private static void fn(BinaryTree node, List<int> accumulator, int target,  List<IList<int>>  res)
    {
        accumulator.Add(node.Value);
        if (target - node.Value == 0 && node.Left == null && node.Right == null)
        {
            res.Add(accumulator);
            return;
        }
        
        if (node.Left != null)
        {
            fn(node.Left, new List<int>(accumulator), target - node.Value, res);
        }
        if (node.Right != null)
        {
            fn(node.Right, new List<int>(accumulator), target - node.Value, res);
        }
    }
    
    // recursive
    public static IList<IList<int>> GetOptionsRecursive(BinaryTree? root, int targetSum)
    {
        List<IList<int>>  res = new ();
        if (root == null)
        {
            return res;
        }
        fn(root, new List<int>(), targetSum, res);
        return res;
    }
    
    // DFS stack
    public static IList<IList<int>> GetOptionsDFS(BinaryTree? root, int targetSum)
    {
        List<IList<int>>  res = new ();
        if (root == null)
        {
            return res;
        }
        Stack<(BinaryTree, List<int>, int)> stack = new();
        stack.Push((root, new List<int>(), targetSum));
        while (stack.Count > 0)
        {
            (BinaryTree currentNode, List<int> lst, int ts) = stack.Pop();
 
            lst.Add(currentNode.Value);
            if (ts == currentNode.Value && currentNode.Left == null && currentNode.Right == null)
            {
                res.Add(new List<int>(lst));
                continue;
            }
            
            if (currentNode.Left != null)
            {
                stack.Push((currentNode.Left, new List<int>(lst), ts - currentNode.Value));
            }
            
            if (currentNode.Right != null)
            {
                stack.Push((currentNode.Right, new List<int>(lst), ts - currentNode.Value));
            }
        }

        return res;
    }
}
