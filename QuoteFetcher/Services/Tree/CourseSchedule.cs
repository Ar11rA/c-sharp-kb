namespace QuoteFetcher.Services.Tree;

public static class CourseSchedule
{
    public static bool CanFinish(int numCourses, int[][] prerequisites)
    {
        Dictionary<int, List<int>> adjacencyMatrix = new();
        int[] inDegree = new int[numCourses];
        Queue<int> queue = new();
        int count = 0;

        foreach (int[] prerequisite in prerequisites)
        {
            int subject1 = prerequisite[0];
            int subject2 = prerequisite[1];
            if (!adjacencyMatrix.ContainsKey(subject1))
            {
                adjacencyMatrix[subject1] = new List<int> {subject2};
            }
            else
            {
                adjacencyMatrix[subject1].Add(subject2);
            }

            inDegree[subject2]++;
        }

        for (int i = 0; i < inDegree.Length; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
                count++;
            }
        }

        while (queue.Count > 0)
        {
            int currVertex = queue.Dequeue();
            List<int> nextVertices = new();
            if (adjacencyMatrix.ContainsKey(currVertex))
            {
                nextVertices = adjacencyMatrix[currVertex];
            }

            nextVertices.ForEach(v =>
            {
                inDegree[v]--;
                if (inDegree[v] == 0)
                {
                    queue.Enqueue(v);
                    count++;
                }
            });
        }

        return count == numCourses;
    }
}
