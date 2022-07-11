namespace QuoteFetcher.Services;

public static class PrimeFactor
{
    public static List<int> GetFactors(int number)
    {
        int initialFactor = 2;
        List<int> factors = new();
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i != 0)
            {
                continue;
            }

            while (number % i == 0)
            {
                number /= i;
            }

            factors.Add(i);
        }

        return factors;
    }
}
