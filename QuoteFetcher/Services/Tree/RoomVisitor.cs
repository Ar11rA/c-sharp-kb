namespace QuoteFetcher.Services.Tree;

public static class RoomVisitor
{
    public static bool Check(IList<IList<int>> rooms)
    {
        Queue<int> queue = new();
        queue.Enqueue(0);
        HashSet<int> visited = new();

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            visited.Add(current);
            List<int> nextRooms = new (rooms[current]);
            nextRooms.ForEach(room =>
            {
                if (!visited.Contains(room))
                {
                    queue.Enqueue(room);
                }
            });
        }

        return visited.Count == rooms.Count;
    }
}
