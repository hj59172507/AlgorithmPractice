using LeetCodePractice.DataStructure.LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.DataStructure.HashMap
{
    class SortedListPlayGround
    {
        //static void Main()
        static void MainSortedListPlayGround()
        {
            SortedList<int, ListNode> sl = new SortedList<int, ListNode>();
            for(int i = 0; i < 100; i++)
            {
                sl.Add(i, new ListNode(i));
            }
            foreach(int i in sl.Keys)
            {
                Console.Out.WriteLine(sl[i].val);
            }
            Console.Out.WriteLine(sl.First().Value.val);
            Console.In.ReadLine();
        }
    }
}
