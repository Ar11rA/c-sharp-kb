namespace QuoteFetcher.DTO;

public class ListNode
{
    public ListNode(int val = 0, ListNode? next = null)
    {
        Val = val;
        Next = next;
    }

    public int Val { get; set; }
    public ListNode? Next { get; set; }
}
