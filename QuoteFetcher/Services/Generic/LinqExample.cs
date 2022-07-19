using QuoteFetcher.DTO;
using QuoteFetcher.Enums;

namespace QuoteFetcher.Services.Generic;

public static class LinqExample
{
    public static void Run(List<int> numbers)
    {
        // linq queries using sql like syntax
        IEnumerable<int> found = from number in numbers
            where number == 1
            select number;
        Console.WriteLine(found.FirstOrDefault(-1));

        // Map
        numbers.Select(x => x * 2).ToList().ForEach(Console.Write);
        Console.WriteLine();

        // Filter
        numbers.Where(x => x % 2 == 0).ToList().ForEach(Console.Write);
        Console.WriteLine();

        // Reduce
        Console.WriteLine(numbers.Aggregate(0, (acc, item) => acc + item));

        // Group By
        List<Person> people = new()
        {
            new Person
            {
                Name = "Aritra",
                City = "Jamshedpur",
                Status = Status.Active
            },
            new Person
            {
                Name = "Paridhi",
                City = "Jamshedpur",
                Status = Status.New
            },
            new Person
            {
                Name = "Aritra",
                City = "Bangalore",
                Status = Status.Old
            }
        };
        Dictionary<string, List<Person>> groupedPeople = people
            .GroupBy(x => x.Name)
            .ToDictionary(x => x.Key, x => x.ToList());
        foreach ((string? key, List<Person>? value) in groupedPeople)
        {
            Console.WriteLine(key + ": " + value
                .Select(x => x.City)
                .Aggregate("", (a, b) => a.ToString() + "|" + b.ToString()));
        }

        // Sort
        numbers.Sort((n1, n2) => n2 - n1);
        numbers.ForEach(Console.Write);
        numbers.Skip(1).Take(2).ToList().ForEach(Console.Write);
        Console.WriteLine();
    }
}
