using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

/*
1462. Course Schedule IV

There are a total of n courses you have to take, labeled from 0 to n-1.

Some courses may have direct prerequisites, for example, to take course 0 you have first to take course 1, which is expressed as a pair: [1,0]

Given the total number of courses n, a list of direct prerequisite pairs and a list of queries pairs.

You should answer for each queries[i] whether the course queries[i][0] is a prerequisite of the course queries[i][1] or not.

Return a list of boolean, the answers to the given queries.

Please note that if course a is a prerequisite of course b and course b is a prerequisite of course c, then, course a is a prerequisite of course c.

Example 1:

Input: n = 2, prerequisites = [[1,0]], queries = [[0,1],[1,0]]
Output: [false,true]
Explanation: course 0 is not a prerequisite of course 1 but the opposite is true.
Example 2:

Input: n = 2, prerequisites = [], queries = [[1,0],[0,1]]
Output: [false,false]
Explanation: There are no prerequisites and each course is independent.
Example 3:

Input: n = 3, prerequisites = [[1,2],[1,0],[2,0]], queries = [[1,0],[1,2]]
Output: [true,true]
Example 4:

Input: n = 3, prerequisites = [[1,0],[2,0]], queries = [[0,1],[2,0]]
Output: [false,true]
Example 5:

Input: n = 5, prerequisites = [[0,1],[1,2],[2,3],[3,4]], queries = [[0,4],[4,0],[1,3],[3,0]]
Output: [true,false,true,false]
 
Constraints:

2 <= n <= 100
0 <= prerequisite.length <= (n * (n - 1) / 2)
0 <= prerequisite[i][0], prerequisite[i][1] < n
prerequisite[i][0] != prerequisite[i][1]
The prerequisites graph has no cycles.
The prerequisites graph has no repeated edges.
1 <= queries.length <= 10^4
queries[i][0] != queries[i][1]

Sol Floyd–Warshall algorithm https://en.wikipedia.org/wiki/Floyd%E2%80%93Warshall_algorithm
Time O(n^3)
Space O(n^2)

 */
namespace LeetCodePractice.DataStructure.HashMap
{
    class CheckPrerequisite
    {
        //static void Main()
        static void Main1462()
        {
            int[][] prere = { new int[] { 0, 1 } , new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }};
            int[][] queries = { new int[] { 0, 4 }, new int[] { 4, 0 }, new int[] { 1, 3 }, new int[] { 3, 0 }, };
            int n = 5;
            Console.Out.WriteLine(CheckIfPrerequisite(n, prere, queries));
            Console.In.ReadLine();
        }
        public static IList<bool> CheckIfPrerequisite(int n, int[][] prerequisites, int[][] queries)
        {            
            bool[,] reach = new bool[n, n];
            foreach(int[] i in prerequisites)
            {
                int fromC = i[0], toC = i[1];
                reach[fromC, toC] = true;
            }
            floydWarshall(reach,n);
            bool[] ans = new bool[queries.Length];
            for(int i=0;i<queries.Length;i++)
            {
                int key = queries[i][0], target = queries[i][1];
                ans[i] = reach[key, target];
            }
            return ans;
        }
        public static void floydWarshall(bool[,] reach, int n)
        {            
            for(int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        reach[i, j] = reach[i, j] || (reach[i, k] && reach[k, j]);
                    }
                }
            }
        }
    }
}
