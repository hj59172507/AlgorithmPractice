using System;
using System.Collections.Generic;
using System.Linq;

/*
Suppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k), where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. Write an algorithm to reconstruct the queue.

Note:
The number of people is less than 1,100.

Example

Input:
[[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]

Output:
[[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]

Sol
Time O(nlog(n))
Space O(n)
Sort the list by height, and process starting from shortest person.
Also define an list that stores availble spot left so we dont spend time search for next available spot.
If p is the shortest person in list with height h and k people before him, we fetch the kth availble spot and put him there.
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class QueueReconstructionByHeight
    {
        static void Main()
        //static void Main1386()
        {
            int[][] people= { new int[] { 7, 0 }, new int[] { 4, 4 }, new int[] { 7, 1 }, new int[] { 5, 0 }, new int[] { 6, 1 }, new int[] { 5, 2 }, };
            Console.Out.WriteLine(ReconstructQueue(people));
            Console.In.ReadLine();
        }
        public static int[][] ReconstructQueue(int[][] people)
        {
            int[][] reP = new int[people.Length][];            
            SortedDictionary<int, List<int>> heightToPos = new SortedDictionary<int, List<int>>();
            SortedSet<int> availSpot = new SortedSet<int>();
            SortedSet<int> remove = new SortedSet<int>();
            availSpot.UnionWith(Enumerable.Range(0, people.Length));
            foreach(int[] p in people)
            {
                if (heightToPos.ContainsKey(p[0])) heightToPos[p[0]].Add(p[1]);
                else heightToPos[p[0]] = new List<int>() { p[1]};
            }
            foreach(int k in heightToPos.Keys)
            {                
                foreach(int pos in heightToPos[k])
                {
                    int spot = availSpot.ElementAt(pos);
                    reP[spot] = new int[] {k, pos };
                    remove.Add(spot);
                }
                while(remove.Count != 0)
                {
                    availSpot.Remove(remove.Last());
                    remove.Remove(remove.Last());
                }
            }
            return reP;
        }
    }
}
