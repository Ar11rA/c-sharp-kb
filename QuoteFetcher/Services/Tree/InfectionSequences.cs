namespace QuoteFetcher.Services.Tree;

public static class InfectionSequences
{
    private static int factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact = (int)((fact * i) % (System.Math.Pow(10, 9) + 7));
        }

        return (int) (fact % ((System.Math.Pow(10, 9) + 7)));
    }
    
    public static int GetCount(int n, int[] infectedHouses)
    {
        Queue<(int, int)> queue = new();
        int[] dayCtr = new int[n+1];
        HashSet<int> visited = new();
        foreach (int house in infectedHouses)
        {
            queue.Enqueue((house, 0));
            visited.Add(house);
        }

        while (queue.Count > 0)
        {
            (int house, int day) = queue.Dequeue();
            if (house - 1 >= 1 && !visited.Contains(house - 1))
            {
                visited.Add(house - 1);
                dayCtr[day + 1] += 1;
                queue.Enqueue((house - 1, day + 1));
            }
            
            if (house + 1 <= n && !visited.Contains(house + 1))
            {
                visited.Add(house + 1);
                dayCtr[day + 1] += 1;
                queue.Enqueue((house + 1, day + 1));
            }
        }

        return dayCtr.Aggregate(1, (acc, curr) =>
        {
            acc *= factorial(curr);
            return acc;
        });
    }
}
