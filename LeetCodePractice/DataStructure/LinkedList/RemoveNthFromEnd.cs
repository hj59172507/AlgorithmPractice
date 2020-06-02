using System;
/*
Given a linked list, remove the n-th node from the end of list and return its head.

Example:

Given linked list: 1->2->3->4->5, and n = 2.

After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:

Given n will always be valid.

Follow up:

Sol:
Time O(n)
Space O(1)
1.Create a node preTarget that has next set to head of the list
2.Loop to find the tail, while keeping preTarget n+1 node away from tail
3.Link preTarget.next to preTarget.next.next
 */
namespace LeetCodePractice.DataStructure.LinkedList
{
    class RemoveNthFromEnd
    {
        //static void Main()
        static void Main19()
        {
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            int n = 2;
            Console.Out.WriteLine(RemoventhFromEnd(head, n));
            Console.In.ReadLine();
        }

        public static ListNode RemoventhFromEnd(ListNode head, int n)
        {
            if (head.next == null)
                return null;
            ListNode preTarget = new ListNode(1, head);
            ListNode tail = head;
            while (true)
            {
                for(int i = 0; i < n-1; i++)
                {
                    tail = tail.next;
                }
                if(tail.next == null)
                {
                    if (preTarget.next == head)
                        return head.next;
                    else
                    {
                        preTarget.next = preTarget.next.next;
                        return head;
                    }                    
                }
                preTarget = preTarget.next;
                tail = preTarget.next;
            }
        }
    }
}
