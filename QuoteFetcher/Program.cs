using QuoteFetcher.Services.Generic;

static void Main()
{
    Console.WriteLine("Essentials");
    LinqExample.Run(new List<int> {1, 2, 3, 4, 5, 6});
    LinqExample.Run(new List<int> {2, 3, 4, 5, 6});
    MappingExample.Run();
    CustomReader.ParseXml("QuoteFetcher.Resources.user-data.xml", "QuoteFetcher.Resources.numbers.txt");
    Console.WriteLine("******************************************************************************");
}

Main();
