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
}
