using QuoteFetcher.DTO;

namespace QuoteFetcher.Services;

public static class DepthFirstSearch
{
    public static void Traverse(BinaryTree? binaryTree)
    {
        if (binaryTree == null)
        {
            return;
        }

        Console.WriteLine(binaryTree.Value);
        Traverse(binaryTree.Left);
        Traverse(binaryTree.Right);
    }
}
