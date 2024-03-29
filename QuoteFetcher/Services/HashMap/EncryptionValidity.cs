namespace QuoteFetcher.Services.HashMap;

public static class EncryptionValidity
{
    private static Dictionary<int, int> _keyFrequencyMap;

    private static int CountDivisors(int key)
    {
        int result = 0;
        int div = 1;
        while (div * div <= key)
        {
            if (key % div == 0)
            {
                if (_keyFrequencyMap.ContainsKey(div))
                {
                    result += _keyFrequencyMap[div];
                }

                if (key / div != div && _keyFrequencyMap.ContainsKey(key / div))
                {
                    result += _keyFrequencyMap[key / div];
                }
            }

            div += 1;
        }

        return result;
    }

    public static List<int> GetStrength(int instructionCount, int validityPeriod, List<int> keys)
    {
        _keyFrequencyMap = keys.Aggregate(new Dictionary<int, int>(), (acc, curr) =>
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
        int max = 0;
        keys.ForEach(key =>
        {
            int numberOfDivisors = CountDivisors(key);
            if (max < numberOfDivisors)
            {
                max = numberOfDivisors;
            }
        });
        int encryptionStrength = max * 100000;
        long hackableKeyCount = instructionCount * (long) validityPeriod;
        return new List<int>
        {
            hackableKeyCount > encryptionStrength ? 1 : 0, encryptionStrength
        };
    }
}
