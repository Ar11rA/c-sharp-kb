using AutoMapper;
using QuoteFetcher.Config;
using QuoteFetcher.DTO.MapperExample;

namespace QuoteFetcher.Services;

public static class MappingExample
{
    public static void Run()
    {
        UserInput userInput = new()
        {
            FirstName = "Raplh",
            LastName = "Makkerson",
            Income = 100000,
            Expense = 10000,
            Address = "New York"
        };

        // adding address as ignore field
        UserOutput userOutput = new()
        {
            Address = "California"
        };
        Mapper mapper = new(MappingConfig.Setup());
        // method 1
        Console.WriteLine("Method #1");
        userOutput = mapper.Map<UserOutput>(userInput);
        Console.WriteLine(userOutput.Address);
        Console.WriteLine(userOutput.FullName);
        Console.WriteLine(userOutput.NetSaving);

        // method 2
        userOutput = new UserOutput
        {
            Address = "California"
        };
        userOutput = mapper.Map(userInput, userOutput);
        Console.WriteLine("Method #2");
        Console.WriteLine(userOutput.Address);
        Console.WriteLine(userOutput.FullName);
        Console.WriteLine(userOutput.NetSaving);
    }
}
