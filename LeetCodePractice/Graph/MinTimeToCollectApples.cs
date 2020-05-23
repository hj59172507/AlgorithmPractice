using System;
using System.Collections.Generic;

/*
Given an undirected tree consisting of n vertices numbered from 0 to n-1, which has some apples in their vertices. You spend 1 second to walk over one edge of the tree. Return the minimum time in seconds you have to spend in order to collect all apples in the tree starting at vertex 0 and coming back to this vertex.

The edges of the undirected tree are given in the array edges, where edges[i] = [fromi, toi] means that exists an edge connecting the vertices fromi and toi. Additionally, there is a boolean array hasApple, where hasApple[i] = true means that vertex i has an apple, otherwise, it does not have any apple.

Example 1:

Input: n = 7, edges = [[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]], hasApple = [false,false,true,false,true,true,false]
Output: 8 
Explanation: The figure above represents the given tree where red vertices have an apple. One optimal path to collect all apples is shown by the green arrows.  
Example 2:

Input: n = 7, edges = [[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]], hasApple = [false,false,true,false,false,true,false]
Output: 6
Explanation: The figure above represents the given tree where red vertices have an apple. One optimal path to collect all apples is shown by the green arrows.  
Example 3:

Input: n = 7, edges = [[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]], hasApple = [false,false,false,false,false,false,false]
Output: 0
 

Constraints:

1 <= n <= 10^5
edges.length == n-1
edges[i].length == 2
0 <= fromi, toi <= n-1
fromi < toi
hasApple.length == n

Sol DFS
Time O(n)
Space O(n), Would be O(E:number of edges) if graph is not a tree(no cycle)

1. Create a list of list which store all reacheable node from node i
2. DFS search from root, mark each node as visited
3. If there is an apple and we visit for the first time, append the count by 2
 */
namespace LeetCodePractice.Graph
{
    class MinTimeToCollectApples
    {        
        //static void Main()
        static void Main1443()
        {
            int n = 7;
            int[][] edges = { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 4 }, new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 2, 6 } };
            List<bool> hasApples = new List<bool>{ false, false, true, false, true, true, false };
            Console.Out.WriteLine(MinTime(n, edges, hasApples));
            Console.In.ReadLine();
        }
        
        public static int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            List<List<int>> reacheable = new List<List<int>>();              
            HashSet<string> visited = new HashSet<string>();            
            for(int i = 0; i < n; i++)
            {
                reacheable.Add(new List<int>());
            }
            foreach (int[] e in edges)
            {
                reacheable[e[0]].Add(e[1]);
                reacheable[e[1]].Add(e[0]);
            }

            int count = 0;
            dfs(reacheable, hasApple, new bool[n], 0, ref count);
            return count;
        }

        public static bool dfs(List<List<int>> reacheable, IList<bool> hasApple, IList<bool> visited, int curNode, ref int count)
        {
            if (visited[curNode])
                return false;
            visited[curNode] = true;
            bool res = hasApple[curNode];
            foreach(int i in reacheable[curNode])
            {                
                if(dfs(reacheable, hasApple, visited, i, ref count))
                {
                    count+=2;
                    res = true;
                }
            }
            return res;
        }
    }
}
