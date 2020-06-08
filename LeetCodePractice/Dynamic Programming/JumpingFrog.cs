using System;
using System.Collections.Generic;
/*
1377. Frog Position After T Seconds

Given an undirected tree consisting of n vertices numbered from 1 to n. A frog starts jumping from the vertex 1. In one second, the frog jumps from its current vertex to another unvisited vertex if they are directly connected. The frog can not jump back to a visited vertex. In case the frog can jump to several vertices it jumps randomly to one of them with the same probability, otherwise, when the frog can not jump to any unvisited vertex it jumps forever on the same vertex. 

The edges of the undirected tree are given in the array edges, where edges[i] = [fromi, toi] means that exists an edge connecting directly the vertices fromi and toi.

Return the probability that after t seconds the frog is on the vertex target.

Example 1:

Input: n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 2, target = 4
Output: 0.16666666666666666 
Explanation: The figure above shows the given graph. The frog starts at vertex 1, jumping with 1/3 probability to the vertex 2 after second 1 and then jumping with 1/2 probability to vertex 4 after second 2. Thus the probability for the frog is on the vertex 4 after 2 seconds is 1/3 * 1/2 = 1/6 = 0.16666666666666666. 
Example 2:

Input: n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 1, target = 7
Output: 0.3333333333333333
Explanation: The figure above shows the given graph. The frog starts at vertex 1, jumping with 1/3 = 0.3333333333333333 probability to the vertex 7 after second 1. 
Example 3:

Input: n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 20, target = 6
Output: 0.16666666666666666
 
Constraints:

1 <= n <= 100
edges.length == n-1
edges[i].length == 2
1 <= edges[i][0], edges[i][1] <= n
1 <= t <= 50
1 <= target <= n
Answers within 10^-5 of the actual value will be accepted as correct.

Sol
Time O(n)
Space O(n)
Use DFS to jump to each availble path, carring the position coming from and steps left.
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class JumpingFrog
    {
        //static void Main()
        static void Main1377()
        {
            int n = 7, t = 2, target = 4;
            int[][] edges = { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };
            Console.Out.WriteLine(FrogPosition(n, edges, t, target));
            Console.In.ReadLine();
        }
        public static double FrogPosition(int n, int[][] edges, int t, int target)
        {
            bool[] visited = new bool[n];
            IList<int>[] graph = new IList<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0] - 1].Add(edge[1] - 1);
                graph[edge[1] - 1].Add(edge[0] - 1);
            }

            double res = 0;
            res = Helper(0, target - 1, t, visited, graph);
            return res;
        }

        private static double Helper(int node, int target, int time, bool[] visited, IList<int>[] graph)
        {
            if (node < 0 || node >= graph.Length || time < 0)
            {
                return 0;
            }

            if (time == 0 && node == target)
            {
                return 1;
            }


            double res = 0;
            visited[node] = true;

            int variantCount = 0;
            foreach (var next in graph[node])
            {
                if (!visited[next])
                {
                    variantCount++;
                    var inner = Helper(next, target, time - 1, visited, graph);
                    res += inner;
                }
            }

            if (variantCount > 0)
            {
                visited[node] = false;
                res /= variantCount;
                return res;
            }

            //stay here
            return Helper(node, target, time - 1, visited, graph);
        }
    }
}
