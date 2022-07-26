using QuoteFetcher.DTO;
using QuoteFetcher.Services.Array;
using QuoteFetcher.Services.BinarySearch;
using QuoteFetcher.Services.DPRecursion;
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

    // Rest APIs
    Console.WriteLine("Rest API problems");
    QuoteService.FetchQuotes(10).GetAwaiter().GetResult();
    CustomerTransaction.GetTransactions("debit").GetAwaiter().GetResult();
    Console.WriteLine(RootThreshold.CountDevices(45, "STOPPED", "03-2019").GetAwaiter().GetResult());
    TopArticles.GetMostViewedArticles(2).GetAwaiter().GetResult().ForEach(Console.WriteLine);
    Console.WriteLine();
    List<int> filteredRecords = MedicalRecords
        .FilterRecordsIdsByAgeAndBp(28, 31, 13).GetAwaiter().GetResult();
    Console.WriteLine("Number of filtered medical records:" + filteredRecords.Count);
    RelevantFoodOutlet.CollateAffordableOutlets("Seattle", 135).GetAwaiter().GetResult().ForEach(Console.WriteLine);
    Console.WriteLine("******************************************************************************");

    // CP
    Console.WriteLine("CP problems");
    BinaryTree grandchildLeft = new()
    {
        Value = 15
    };
    BinaryTree grandchildRight = new()
    {
        Value = 18
    };
    BinaryTree firstChild = new()
    {
        Value = 10,
        Left = grandchildLeft,
        Right = grandchildRight
    };

    BinaryTree secondChild = new()
    {
        Value = 20
    };
    BinaryTree parent = new()
    {
        Value = 30,
        Left = firstChild,
        Right = secondChild
    };
    Console.WriteLine("DFS Recursive");
    TreeTraversal.DFSRecursive(parent);
    Console.WriteLine();
    Console.WriteLine("DFS Stack");
    TreeTraversal.DFSIterative(parent);
    Console.WriteLine();
    Console.WriteLine("BFS Queue");
    TreeTraversal.BFSIterative(parent);
    Console.WriteLine();

    Console.WriteLine(CountPairs.getDistinctPairCount(new List<int> {1, 1, 1, 2, 2, 3}, 1));
    Console.WriteLine(CountPairs.getDistinctPairCount(new List<int> {1, 2, 3, 4, 5, 6}, 2));

    Console.WriteLine(JumpGame.CanJump(new List<int> {2, 3, 1, 1, 4}) + " " +
                      JumpGame.CountMinJumps(new List<int> {2, 3, 1, 1, 4}));
    Console.WriteLine(JumpGame.CanJump(new List<int> {3, 2, 1, 0, 4}) + " " +
                      JumpGame.CountMinJumps(new List<int> {3, 2, 1, 0, 4}));
    Console.WriteLine(JumpGame.CanJump(new List<int> {1, 2, 0, 3, 0, 0}) + " " +
                      JumpGame.CountMinJumps(new List<int> {1, 2, 0, 3, 0, 0}));
    Console.WriteLine(JumpGame.CanJump(new List<int> {1, 0, 2}) + " " +
                      JumpGame.CountMinJumps(new List<int> {1, 0, 2}));

    PrimeFactor.GetFactors(25).ForEach(Console.WriteLine);
    Console.WriteLine();
    Console.WriteLine(KokoEatingBananas.GetMinEatingSpeed(new List<int> {30, 11, 23, 4, 20}, 5));
    Console.WriteLine(KokoEatingBananas.GetMinEatingSpeed(new List<int> {30, 11, 23, 4, 20}, 6));
    Console.WriteLine(KokoEatingBananas.GetMinEatingSpeed(new List<int> {3, 6, 7, 11}, 8));

    TwoSum.FindPair(new[] {3, 2, 4}, 6);
    Console.WriteLine(MinimumRotatedSortedArray.FindMin(new List<int> {3, 4, 5, 1, 2}));
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

    List<List<string>> groupedAnagrams = GroupAnagrams.Run(new List<string> {"eat", "tea", "tan", "ate", "nat", "bat"});
    foreach (List<string> groupedAnagram in groupedAnagrams)
    {
        groupedAnagram.ForEach(Console.WriteLine);
    }

    List<int> spiral = SpiralMatrix.Traverse(new List<List<int>>
    {
        new() {1, 2, 3},
        new() {4, 5, 6},
        new() {7, 8, 9}
    });
    spiral.ForEach(Console.Write);
    Console.WriteLine();
    Console.WriteLine(LongestNonRepeatingSubstring.FindSubstring("abcabcbb"));
    Console.WriteLine(LongestNonRepeatingSubstring.FindSubstring("bbbbb"));
    Console.WriteLine(LongestNonRepeatingSubstring.FindSubstring("pwwkew"));
    Console.WriteLine(LongestNonRepeatingSubstring.FindSubstring(" "));
    Console.WriteLine(LongestNonRepeatingSubstring.FindSubstring("dvdf"));

    List<List<int>> triangle = PascalTriangle.Generate(6);
    triangle.ForEach(ut =>
    {
        ut.ForEach(lt => { Console.Write(lt + " "); });
        Console.WriteLine();
    });

    Console.WriteLine(Stairs.Climb(3));
    Console.WriteLine(Stairs.Tribonacci(4));
    Console.WriteLine(Stairs.MinCost(new List<int> {10, 15, 20}));

    Console.WriteLine(Palindrome.IsPal(12321));
    Console.WriteLine(Palindrome.IsPal(12));
    Console.WriteLine(Palindrome.IsPal(-123));
    Palindrome.Generate(new List<int> {1, 2, 3, 4, 5, 90}, 3).ForEach(Console.WriteLine);
    Palindrome.Generate(new List<int> {2, 4, 6}, 4).ForEach(Console.WriteLine);
    Console.WriteLine(SquareRoot.MySqrt(16));
    Console.WriteLine(HappyNumber.Check(19));
    Console.WriteLine(HappyNumber.Check(7));
    Console.WriteLine();

    Console.WriteLine(Converter.RomanToNumber("IV"));
    Console.WriteLine(Converter.RomanToNumber("XVII"));
    Console.WriteLine(Converter.NumberToRoman(45));
    Console.WriteLine(Converter.NumberToRoman(14));
    Console.WriteLine(Converter.StrStr("hello", "ll"));
    Console.WriteLine(Converter.LengthOfLastWord("   world"));
    Console.WriteLine(Converter.LengthOfLastWord("Hello world "));

    Console.WriteLine(LongestCommonPrefix.Find(new List<string> {"flow", "flight", "flower"}));
    Console.WriteLine(InplaceOperations.ReplaceDuplicatesCount(new[] {1, 1, 2, 2, 2, 3, 4, 5}));
    Console.WriteLine(InplaceOperations.RemoveElement(new[] {1, 2, 3, 2, 1, 2}, 2));

    Console.WriteLine("******************************************************************************");
}

Main();
