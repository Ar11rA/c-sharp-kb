using System.Text;

namespace QuoteFetcher.Services.Math;

public static class BitManipulation
{
    public static int CountSetBits(uint n)
    {
        int ctr = 0;
        while (n > 0)
        {
            n &= n - 1;
            ctr++;
        }

        return ctr;
    }

    public static string AddBinary(string a, string b)
    {
        int n1 = a.Length - 1;
        int n2 = b.Length - 1;
        int carry = 0;

        StringBuilder result = new();
        while (carry > 0 || n1 >= 0 || n2 >= 0)
        {
            int c1 = n1 >= 0 ? a[n1] - '0' : 0;
            int c2 = n2 >= 0 ? b[n2] - '0' : 0;

            int sum = c1 ^ c2 ^ carry;
            carry = (c1 | carry) & (c2 | carry) & (c1 | c2);

            result.Insert(0, sum);

            n1--;
            n2--;
        }

        return result.ToString();
    }
}
