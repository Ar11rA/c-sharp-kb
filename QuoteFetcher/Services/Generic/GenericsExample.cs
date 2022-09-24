namespace QuoteFetcher.Services.Generic;

public class GenericsExample<T> : List<T>
{
    public GenericsExample() : base()
    {
    }

    public void Print()
    {
        Type t = typeof(T);
        Console.WriteLine($"List of {t.ToString().Substring(t.ToString().IndexOf('.') + 1)}s");
        foreach (T item in this)
        {
            Console.WriteLine(item?.ToString());
        }
    }
}
