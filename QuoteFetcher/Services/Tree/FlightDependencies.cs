namespace QuoteFetcher.Services.Tree;

public static class FlightDependencies
{
    public static List<int> CountDelayedFlights(int flightNodes, List<int> flightFrom, List<int> flightTo,
        List<int> delayed)
    {
        SortedSet<int> flights = new();
        HashSet<int> visited = new();
        Dictionary<int, List<int>> adj = new();
        for (int i = 0; i < flightFrom.Count; i++)
        {
            if (!adj.ContainsKey(flightTo[i]))
            {
                adj[flightTo[i]] = new List<int> {flightFrom[i]};
            }
            else
            {
                adj[flightTo[i]].Add(flightFrom[i]);
            }
        }

        Queue<int> queue = new();
        foreach (int delayedFlight in delayed)
        {
            queue.Enqueue(delayedFlight);
            flights.Add(delayedFlight);
            visited.Add(delayedFlight);
        }

        while (queue.Count > 0)
        {
            int delayedFlight = queue.Dequeue();
            if (!adj.ContainsKey(delayedFlight))
            {
                continue;
            }

            List<int> connectedFlight = adj[delayedFlight];
            connectedFlight.ForEach(flight =>
            {
                if (!visited.Contains(flight))
                {
                    flights.Add(flight);
                    visited.Add(flight);
                    queue.Enqueue(flight);
                }
            });
        }

        return flights.ToList();
    }
}
