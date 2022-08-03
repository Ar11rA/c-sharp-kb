using QuoteFetcher.DTO;
using QuoteFetcher.Services.DSA;
using QuoteFetcher.Services.Generic;
using QuoteFetcher.Services.HashMap;
using QuoteFetcher.Services.Math;
using QuoteFetcher.Services.Rest;
using QuoteFetcher.Services.String;
using QuoteFetcher.Services.Tree;

static void Main()
{
    // Essentials
    Console.WriteLine("Essentials");
    LinqExample.Run(new List<int> {1, 2, 3, 4, 5, 6});
    LinqExample.Run(new List<int> {2, 3, 4, 5, 6});
    MappingExample.Run();
    CustomReader.ParseXml("QuoteFetcher.Resources.user-data.xml", "QuoteFetcher.Resources.numbers.txt");
    Console.WriteLine("******************************************************************************");
    
    // CP
    Console.WriteLine("CP problems");

    Console.WriteLine(CountPairs.getDistinctPairCount(new List<int> {1, 1, 1, 2, 2, 3}, 1));
    Console.WriteLine(CountPairs.getDistinctPairCount(new List<int> {1, 2, 3, 4, 5, 6}, 2));

    PrimeFactor.GetFactors(25).ForEach(Console.WriteLine);
    Console.WriteLine();
    
    TwoSum.FindPair(new[] {3, 2, 4}, 6);
    ListNode? result = LinkedListExamples.Add(
        new ListNode(2, new ListNode(4, new ListNode(3))),
        new ListNode(5, new ListNode(6, new ListNode(4)))
    );
    while (result != null)
    {
        Console.Write(result.Val);
        result = result.Next;
    }

    Console.WriteLine();
    ListNode tail = new(2);
    ListNode head = new(1, tail);
    tail.Next = head;
    Console.WriteLine(LinkedListExamples.HasCycle(head));

    ListNode nthRemoved =
        LinkedListExamples.RemoveNthNodeFromEnd(
            new ListNode(2, new ListNode(4, new ListNode(3, new ListNode(7, new ListNode(8))))), 3);
    while (nthRemoved != null)
    {
        Console.Write(nthRemoved.Val);
        nthRemoved = nthRemoved.Next;
    }

    Console.WriteLine();
    ListNode? merged = LinkedListExamples.MergeSortedLinkedList(
        new ListNode(1, new ListNode(2, new ListNode(3))),
        new ListNode(1, new ListNode(3, new ListNode(4)))
    );
    while (merged != null)
    {
        Console.Write(merged.Val);
        merged = merged.Next;
    }

    Console.WriteLine();

    ListNode rotated = LinkedListExamples.RotateList(
        new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2);
    while (rotated != null)
    {
        Console.Write(rotated.Val);
        rotated = rotated.Next;
    }

    Console.WriteLine();

    Console.WriteLine("Linked list palindrome");
    Console.WriteLine(LinkedListExamples.IsPalindrome(new ListNode(1, new ListNode(2, new ListNode(3)))));
    Console.WriteLine(LinkedListExamples.IsPalindrome(new ListNode(1, new ListNode(2, new ListNode(1)))));

    Console.WriteLine(DSAExamples.ValidateParenthesis("{{}}"));
    Console.WriteLine(DSAExamples.ValidateParenthesis("({)}"));
    Console.WriteLine(DSAExamples.CountStudents(new List<int> {1, 1, 0, 0}, new List<int> {0, 1, 0, 1}));
    Console.WriteLine(DSAExamples.CountStudents(new List<int> {1, 1, 1, 0, 0, 1}, new List<int> {1, 0, 0, 0, 1, 1}));
    DSAExamples.TopKFrequent(new List<int> {1, 1, 1, 2, 2, 3}, 2).ForEach(Console.WriteLine);

    
    Console.WriteLine();
    Console.WriteLine(Palindrome.IsPal(12321));
    Console.WriteLine(Palindrome.IsPal(12));
    Console.WriteLine(Palindrome.IsPal(-123));
    Palindrome.Generate(new List<int> {1, 2, 3, 4, 5, 90}, 3).ForEach(Console.WriteLine);
    Palindrome.Generate(new List<int> {2, 4, 6}, 4).ForEach(Console.WriteLine);
    Console.WriteLine(HappyNumber.Check(19));
    Console.WriteLine(HappyNumber.Check(7));
    Console.WriteLine();

    Console.WriteLine();
    Console.WriteLine("******************************************************************************");
}

Main();
