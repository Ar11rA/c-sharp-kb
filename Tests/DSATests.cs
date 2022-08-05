using System.Collections.Generic;
using QuoteFetcher.DTO;
using QuoteFetcher.Services.DSA;
using Xunit;

namespace Tests;

public class DsaTests
{
    [Fact]
    public void LinkedListAdd_Success()
    {
        ListNode? result = LinkedListExamples.Add(
            new ListNode(2, new ListNode(4, new ListNode(3))),
            new ListNode(5, new ListNode(6, new ListNode(4)))
        );
        Assert.Equal(7, result.Val);
        Assert.Equal(0, result.Next.Val);
        Assert.Equal(8, result.Next.Next.Val);
    }
    
    [Fact]
    public void LinkedListLoop_Success()
    {
        ListNode tail = new(2);
        ListNode head = new(1, tail);
        tail.Next = head;
        Assert.True(LinkedListExamples.HasCycle(head));
    }
    
    [Fact]
    public void LinkedListRemoveNthNodeFromEnd_Success()
    {
        ListNode nthRemoved =
            LinkedListExamples.RemoveNthNodeFromEnd(
                new ListNode(2, new ListNode(4, new ListNode(3, new ListNode(7, new ListNode(8))))), 3);
        Assert.Equal(2, nthRemoved.Val);
        Assert.Equal(4, nthRemoved.Next.Val);
        Assert.Equal(7, nthRemoved.Next.Next.Val);
    }
    
    [Fact]
    public void LinkedListMergeSortedLinkedList_Success()
    {
        ListNode? merged = LinkedListExamples.MergeSortedLinkedList(
            new ListNode(1, new ListNode(2, new ListNode(3))),
            new ListNode(1, new ListNode(3, new ListNode(4)))
        );
        Assert.Equal(1, merged.Val);
        Assert.Equal(1, merged.Next.Val);
    }    
    
    [Fact]
    public void LinkedListMergeSortedRotateList_Success()
    {
        ListNode rotated = LinkedListExamples.RotateList(
            new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2);
        Assert.Equal(4, rotated.Val);
        Assert.Equal(5, rotated.Next.Val);
    }
    
    [Fact]
    public void LinkedListMergeSortedIsPalindrome_Success()
    {
        bool result = LinkedListExamples.IsPalindrome(new ListNode(1, new ListNode(2, new ListNode(3))));
        Assert.False(result);
        result = LinkedListExamples.IsPalindrome(new ListNode(1, new ListNode(2, new ListNode(1))));
        Assert.True(result);
    }
    
    [Fact]
    public void DSAExamplesValidateParenthesis_Success()
    {
        bool result = DSAExamples.ValidateParenthesis("{{}}");
        Assert.True(result);
        result = DSAExamples.ValidateParenthesis("({)}");
        Assert.False(result);
    }
    
    [Fact]
    public void DSAExamplesCountStudents_Success()
    {
        int result = DSAExamples.CountStudents(new List<int> {1, 1, 0, 0}, new List<int> {0, 1, 0, 1});
        Assert.Equal(0, result);
        result = DSAExamples.CountStudents(new List<int> {1, 1, 1, 0, 0, 1}, new List<int> {1, 0, 0, 0, 1, 1});
        Assert.Equal(3, result);
    }    
    
    [Fact]
    public void DSAExamplesTopKFrequent_Success()
    {
        List<int> result =  DSAExamples.TopKFrequent(new List<int> {1, 1, 1, 2, 2, 3}, 2);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
    }
    
}