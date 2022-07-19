using QuoteFetcher.DTO;

namespace QuoteFetcher.Services;

public static class LinkedListExamples
{
    public static ListNode? Add(ListNode? l1, ListNode? l2)
    {
        if (l1 == null)
        {
            return l2;
        }

        if (l2 == null)
        {
            return l1;
        }

        int carry = 0;
        ListNode result = new();
        ListNode? previous = result;

        while (l1 != null || l2 != null || carry == 1)
        {
            int sum = (l1?.Val ?? 0) + (l2?.Val ?? 0) + carry;
            carry = sum < 10 ? 0 : 1;
            previous.Next = new ListNode(sum % 10);
            previous = previous.Next;

            l1 = l1?.Next;

            l2 = l2?.Next;
        }

        return result.Next;
    }

    public static bool HasCycle(ListNode? head)
    {
        Dictionary<ListNode, bool> visitTracker = new();
        while (head != null)
        {
            if (visitTracker.ContainsKey(head))
            {
                return true;
            }

            visitTracker[head] = true;
            head = head.Next;
        }

        return false;
    }

    public static ListNode RemoveNthNodeFromEnd(ListNode? head, int n)
    {
        if (head == null)
        {
            return new ListNode();
        }

        ListNode fastPtr = head;
        ListNode slowPtr = head;
        ListNode result = slowPtr;
        for (int i = 0; i <= n; i++)
        {
            fastPtr = fastPtr.Next;
        }

        while (fastPtr != null)
        {
            fastPtr = fastPtr.Next;
            slowPtr = slowPtr.Next;
        }

        slowPtr.Next = slowPtr.Next.Next;
        return result;
    }

    public static ListNode? MergeSortedLinkedList(ListNode? l1, ListNode? l2)
    {
        if (l1 == null)
        {
            return l2;
        }

        if (l2 == null)
        {
            return l2;
        }

        ListNode result = new();
        ListNode temp = result;

        while (l1 != null && l2 != null)
        {
            if (l1.Val < l2.Val)
            {
                temp.Next = l1;
                l1 = l1.Next;
            }
            else
            {
                temp.Next = l2;
                l2 = l2.Next;
            }

            temp = temp.Next;
        }

        temp.Next = l1 ?? l2;
        return result.Next;
    }

    public static ListNode RotateList(ListNode? head, int k)
    {
        int len = 0;
        ListNode? curr = head;
        while (curr != null)
        {
            curr = curr.Next;
            len++;
        }

        if (len <= 1)
        {
            return head;
        }

        k %= len;
        if (k == 0)
        {
            return head;
        }

        ListNode? prev = head;
        curr = head;
        for (int index = 0; index < len - k; index++)
        {
            prev = curr;
            curr = curr.Next;
        }

        ListNode result = curr;
        prev.Next = null;
        while (curr.Next != null)
        {
            curr = curr.Next;
        }

        curr.Next = head;
        return result;
    }
}
