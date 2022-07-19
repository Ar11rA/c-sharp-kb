namespace QuoteFetcher.Services;

public static class DSAExamples
{
    // stack use case
    public static bool ValidateParenthesis(string input)
    {
        Stack<char> stack = new();
        Dictionary<char, char> bracketMap = new()
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'}
        };
        foreach (char character in input)
        {
            if (bracketMap.Keys.ToList().Contains(character))
            {
                stack.Push(character);
            }

            if (!bracketMap.Values.ToList().Contains(character))
            {
                continue;
            }

            if (bracketMap.Values.ToList().Contains(character) && stack.Count == 0)
            {
                return false;
            }

            char curr = stack.Pop();
            char compare = bracketMap[curr];
            if (compare != character)
            {
                return false;
            }
        }

        return stack.Count <= 0;
    }

    // queue use case - https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/
    public static int CountStudents(List<int> students, List<int> sandwiches)
    {
        Queue<int> studentPreferences = new();
        students.ForEach(s => studentPreferences.Enqueue(s));
        int index = 0, ctr = 0;
        while (studentPreferences.Count > 0)
        {
            int currentPreference = studentPreferences.Dequeue();
            if (currentPreference == sandwiches[index])
            {
                ctr = 0;
                index++;
            }
            else
            {
                ctr++;
                studentPreferences.Enqueue(currentPreference);
            }

            if (ctr == studentPreferences.Count)
            {
                break;
            }
        }

        return studentPreferences.Count;
    }

    //https://leetcode.com/problems/top-k-frequent-elements
    public static List<int> TopKFrequent(List<int> numbers, int k)
    {
        // Hints: Comparator Syntax (Comparer<ObjectB>.Create((x, y) => x.Something.CompareTo(y.Something));
        PriorityQueue<int, int> frequencyPriorityQueue = new(Comparer<int>.Create((x, y) => y - x));
        Dictionary<int, int> frequencyMap = numbers.Aggregate(new Dictionary<int, int>(), (acc, curr) =>
        {
            if (acc.ContainsKey(curr))
            {
                acc[curr] += 1;
            }
            else
            {
                acc[curr] = 1;
            }

            return acc;
        });
        foreach ((int key, int value) in frequencyMap)
        {
            frequencyPriorityQueue.Enqueue(key, value);
        }

        return Enumerable.Range(1, k).Select(_ => frequencyPriorityQueue.Dequeue()).ToList();
    }
}
