using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.Tree;

public static class TreeTraversal
{
    // In binary tree, DFS search can be done 3 ways - inorder, preorder, postorder
    public static void DFSRecursive(BinaryTree? binaryTree)
    {
        if (binaryTree == null)
        {
            return;
        }

        Console.Write(binaryTree.Value + " ");
        DFSRecursive(binaryTree.Left);
        DFSRecursive(binaryTree.Right);
    }

    // preorder iterative
    public static void DFSIterative(BinaryTree? binaryTree)
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
    public static void BFSIterative(BinaryTree? binaryTree)
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
