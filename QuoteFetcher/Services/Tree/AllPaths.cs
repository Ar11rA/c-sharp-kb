namespace QuoteFetcher.Services.Tree;

internal class Node
{
    public int Value { get; }
    public List<int> Path { get; }

    public Node(int value, List<int> path)
    {
        Value = value;
        Path = path;
    }
}

public static class AllPaths
{
    public static IList<IList<int>> Run(int[][] graph)
    {
        List<IList<int>> result = new ();
        Stack<Node> stack = new ();
        stack.Push(new Node(0, new List<int>{0}));
        
        // dfs
        while (stack.Count > 0)
        {
            Node current = stack.Pop();
            List<int> path = current.Path;
            List<int> nextNodes = new (graph[current.Value]);
            if (current.Value == graph.Length - 1)
            {
                result.Add(path);
                continue;
            }
            nextNodes.ForEach(node =>
            {
                List<int> pathCopy = new (path) {node};
                stack.Push(new Node(node, pathCopy));
            });
        }

        return result;
    }
}
