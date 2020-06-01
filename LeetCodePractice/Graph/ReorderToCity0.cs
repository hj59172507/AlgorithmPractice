using System;
using System.Collections.Generic;
/*
1466. Reorder Routes to Make All Paths Lead to the City Zero

There are n cities numbered from 0 to n-1 and n-1 roads such that there is only one way to travel between two different cities (this network form a tree). Last year, The ministry of transport decided to orient the roads in one direction because they are too narrow.

Roads are represented by connections where connections[i] = [a, b] represents a road from city a to b.

This year, there will be a big event in the capital (city 0), and many people want to travel to this city.

Your task consists of reorienting some roads such that each city can visit the city 0. Return the minimum number of edges changed.

It's guaranteed that each city can reach the city 0 after reorder.


Example 1:

Input: n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
Output: 3
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).
Example 2:

Input: n = 5, connections = [[1,0],[1,2],[3,2],[3,4]]
Output: 2
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).
Example 3:

Input: n = 3, connections = [[1,0],[2,0]]
Output: 0
 
Constraints:

2 <= n <= 5 * 10^4
connections.length == n-1
connections[i].length == 2
0 <= connections[i][0], connections[i][1] <= n-1
connections[i][0] != connections[i][1]

Sol DFS
Time O(n)
Space O(n)
Create two dictionary to and from which store all nodes given key going to, and all nodes given key coming from respectively.
Starting from zero, process each node by following rule:
1. If current node is already processed, return.
2. Mark current node as processed.
3. For nodes from current node, continue to process each.
4. For nodes going to current node, increase answer counter since we this is a route we want to revert.
 */
namespace LeetCodePractice.Graph
{
    class ReorderToCity0
    {
        //static void Main()
        static void Main1466()
        {
            int[][] con = { new int[]{ 1,0},
                            new int[]{ 1,2},
                            new int[]{ 3,2},
                            new int[]{ 3,4}
                            };
            int n = 6;
            Console.Out.WriteLine(MinReorder(n,con));
            Console.In.ReadLine();
        }
        public static int MinReorder(int n, int[][] connections)
        {
            Dictionary<int, List<int>> to = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> from = new Dictionary<int, List<int>>();                         
            foreach(int[] i in connections)
            {
                if (to.ContainsKey(i[0])) to[i[0]].Add(i[1]);
                else to[i[0]] = new List<int>() { i[1]};
                if (from.ContainsKey(i[1])) from[i[1]].Add(i[0]);
                else from[i[1]] = new List<int>() { i[0] };                
            }
            int ans = 0;
            ChangePathForCity(0, to, from, new HashSet<int>(), ref ans);
            return ans;
        }

        public static void ChangePathForCity(int city, Dictionary<int, List<int>> to, Dictionary<int, List<int>> from, HashSet<int> finished, ref int ans)
        {
            if (finished.Contains(city)) return;
            finished.Add(city);
            if (from.ContainsKey(city))
            {
                foreach(int i in from[city])
                {                    
                    ChangePathForCity(i, to, from, finished, ref ans);
                }
            }
            if (to.ContainsKey(city))
            {
                foreach (int i in to[city])
                {
                    if (!finished.Contains(i))
                    {
                        ans++;
                        ChangePathForCity(i, to, from, finished, ref ans);
                    }
                }
            }
        }
    }
}
