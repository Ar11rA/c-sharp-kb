namespace QuoteFetcher.Services.Array;

public static class MinimumRotatedSortedArray
{
    public static int FindMin(List<int> numbers)
    {
        int low = 0, high = numbers.Count - 1;
        while (low < high)
        {
            int mid = (low + high) / 2;
            if (numbers[mid] > numbers[mid + 1])
            {
                return numbers[mid + 1];
            }

            if (numbers[mid] < numbers[mid - 1])
            {
                return numbers[mid];
            }

            if (numbers[mid] > numbers[0])
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return int.MaxValue;
    }
}
