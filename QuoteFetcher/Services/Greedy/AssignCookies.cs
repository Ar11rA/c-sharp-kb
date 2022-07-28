namespace QuoteFetcher.Services.Greedy;

public static class AssignCookies
{
    public static int FindContentChildren(int[] g, int[] s)
    {
        List<int> greed = new(g);
        greed.Sort();
        List<int> sizes = new(s);
        sizes.Sort();
        int i = 0, j = 0;
        while (i < greed.Count && j < sizes.Count)
        {
            if (greed[i] <= sizes[j])
            {
                i++;
            }

            j++;
        }

        return i;
    }
}
