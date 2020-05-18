using LeetCodePractice.DataStructure.LinkedList;
using System;
using System.Collections.Generic;

/*
Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

Example:

Input:
[
  1->4->5,
  1->3->4,
  2->6
]
Output: 1->1->2->3->4->4->5->6

Sol1:
Assumn total number of node is n
Time O(nlog(n)) //since insert n nodes, and we sort the keys that we inserted, hence log(n) operation for each n operation, in total of nlog(n)
Space O(n)
Using SortedList, which is a dictionary with keys sorted from small to large
We can use node value as key, queue of node as value in the dictionary
We start by process all the node in the list of nodes into dictionary
Then combine all the node by iterate through all node in all keys 
 */
namespace LeetCodePractice.DataStructure.Heap
{
    class MergeKListsWithHeap
    {
        static void Main()
        //static void Main23()
        {
            ListNode[] lists = new ListNode[] { new ListNode(1, new ListNode(1,new ListNode(2))),
                                               new ListNode(1, new ListNode(2,new ListNode(2)))};
            Console.Out.WriteLine(MergeKLists(lists));
            Console.In.ReadLine();
        }
        public static ListNode MergeKLists(ListNode[] lists)
        {
            SortedList<int, Queue<ListNode>> sl = new SortedList<int, Queue<ListNode>>();            
            foreach (ListNode n in lists)
            {
                ListNode temp1 = n;
                while (temp1 != null)
                {
                    if (sl.ContainsKey(temp1.val))
                    {
                        sl[temp1.val].Enqueue(new ListNode(temp1.val));
                    }
                    else
                    {
                        sl.Add(temp1.val, new Queue<ListNode>());
                        sl[temp1.val].Enqueue(new ListNode(temp1.val));
                    }
                    temp1 = temp1.next;
                }
            }            
            ListNode res = new ListNode(int.MinValue);
            ListNode temp = res;
            foreach (int i in sl.Keys)
            {
                Queue<ListNode> qln = sl[i];
                while(qln.Count != 0)
                {
                    res.next = qln.Dequeue();
                    res = res.next;
                }                
            }
            return temp.next;
        }
    }
}
