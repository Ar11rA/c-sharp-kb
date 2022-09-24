using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Tree;

public static class TreeTraversal
{
    // In binary tree, DFS search can be done 3 ways - inorder, preorder, postorder
    public static void DfsRecursive(BinaryTree? binaryTree)
    {
        if (binaryTree == null)
        {
            return;
        }

        Console.Write(binaryTree.Value + " ");
        DfsRecursive(binaryTree.Left);
        DfsRecursive(binaryTree.Right);
    }

    // preorder iterative
    public static void DfsIterative(BinaryTree? binaryTree)
    {
        Stack<BinaryTree> stack = new();
        stack.Push(binaryTree);
        while (stack.Count != 0)
        {
            BinaryTree curr = stack.Pop();
            Console.Write(curr.Value + " ");
            if (curr.Right != null)
            {
                stack.Push(curr.Right);
            }

            if (curr.Left != null)
            {
                stack.Push(curr.Left);
            }
        }
    }

    // BFS can be done only as level order using Queue
    public static void BfsIterative(BinaryTree? binaryTree)
    {
        Queue<BinaryTree> queue = new();
        queue.Enqueue(binaryTree);
        while (queue.Count != 0)
        {
            BinaryTree curr = queue.Dequeue();
            Console.Write(curr.Value + " ");
            if (curr.Left != null)
            {
                queue.Enqueue(curr.Left);
            }

            if (curr.Right != null)
            {
                queue.Enqueue(curr.Right);
            }
        }
    }
}
