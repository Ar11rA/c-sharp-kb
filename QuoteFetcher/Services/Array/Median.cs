namespace QuoteFetcher.Services.Array;

public static class Median
{
    public static double CalculateTwoSortedArrays(int[] nums1, int[] nums2)
    {
        int i = 0, j = 0, ctr = 0, mid = (nums1.Length + nums2.Length) / 2;
        int[] resultant = new int[nums1.Length + nums2.Length];
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                resultant[ctr] = nums1[i];
                i++;
            }
            else
            {
                resultant[ctr] = nums2[j];
                j++;
            }

            ctr++;
        }

        while (i < nums1.Length)
        {
            resultant[ctr] = nums1[i];
            i++;
            ctr++;
        }

        while (j < nums2.Length)
        {
            resultant[ctr] = nums2[j];
            j++;
            ctr++;
        }

        return resultant.Length % 2 == 0 ? (resultant[mid] + resultant[mid - 1]) / 2.0 : resultant[mid];
    }
}
