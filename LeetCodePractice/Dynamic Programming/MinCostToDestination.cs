using System;
using System.Collections.Generic;

/*
1368. Minimum Cost to Make at Least One Valid Path in a Grid

Given a m x n grid. Each cell of the grid has a sign pointing to the next cell you should visit if you are currently in this cell. The sign of grid[i][j] can be:
1 which means go to the cell to the right. (i.e go from grid[i][j] to grid[i][j + 1])
2 which means go to the cell to the left. (i.e go from grid[i][j] to grid[i][j - 1])
3 which means go to the lower cell. (i.e go from grid[i][j] to grid[i + 1][j])
4 which means go to the upper cell. (i.e go from grid[i][j] to grid[i - 1][j])
Notice that there could be some invalid signs on the cells of the grid which points outside the grid.

You will initially start at the upper left cell (0,0). A valid path in the grid is a path which starts from the upper left cell (0,0) and ends at the bottom-right cell (m - 1, n - 1) following the signs on the grid. The valid path doesn't have to be the shortest.

You can modify the sign on a cell with cost = 1. You can modify the sign on a cell one time only.

Return the minimum cost to make the grid have at least one valid path.

Example 1:

Input: grid = [[1,1,1,1],[2,2,2,2],[1,1,1,1],[2,2,2,2]]
Output: 3
Explanation: You will start at point (0, 0).
The path to (3, 3) is as follows. (0, 0) --> (0, 1) --> (0, 2) --> (0, 3) change the arrow to down with cost = 1 --> (1, 3) --> (1, 2) --> (1, 1) --> (1, 0) change the arrow to down with cost = 1 --> (2, 0) --> (2, 1) --> (2, 2) --> (2, 3) change the arrow to down with cost = 1 --> (3, 3)
The total cost = 3.
Example 2:

Input: grid = [[1,1,3],[3,2,2],[1,1,4]]
Output: 0
Explanation: You can follow the path from (0, 0) to (2, 2).
Example 3:

Input: grid = [[1,2],[4,3]]
Output: 1
Example 4:

Input: grid = [[2,2,2],[2,2,2]]
Output: 3
Example 5:

Input: grid = [[4]]
Output: 0
 
Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 100

Sol
Time O(mn)
Space O(mn)
Let dp[i,j] be the min cost to reach i,j from 0,0.
We initialize dp reacheable from 0,0 to 0, and save each point in a queue.
Then we try to change the direction of each of point in queue while add a cost in each step.
The first time we reach n-1, m-1 would be our minimum cost
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class MinCostToDestination
    {   
        //static void Main()
        static void Main1368()
        {
            int[][] grid = { new int[] { 1, 1, 1, 1 }, new int[] { 2, 2, 2, 2 }, new int[] { 1, 1, 1, 1 }, new int[] { 2, 2, 2, 2 } };
            Console.Out.WriteLine(MinCost(grid));
            Console.In.ReadLine();
        }
        public static int MinCost(int[][] grid)
        {
            int row = grid.Length, col = grid[0].Length, cost = 0 ;
            Queue<int[]> bfs = new Queue<int[]>();
            int[,] dp = new int[row, col];
            for(int i = 0; i < row; ++i)
            {
                for(int j = 0; j < col; ++j)
                {
                    dp[i, j] = int.MaxValue;
                }
            }            
            DFS(grid, row, col, dp, 0, 0, bfs, cost);
            while(bfs.Count != 0 && dp[row-1, col-1] == int.MaxValue)
            {
                ++cost;
                int size = bfs.Count;
                for(int i = 0; i < size; ++i)
                {
                    int[] cell = bfs.Dequeue();
                    int r = cell[0], c = cell[1];
                    for (int j = 0; j < 4; ++j) DFS(grid, row, col, dp, r + DIR[j][0], c + DIR[j][1], bfs, cost);
                }
            }
            return dp[row-1,col-1];
        
        }
        
        static int[][] DIR = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        static void DFS(int[][] grid, int row, int col, int[,] dp, int r, int c, Queue<int[]> bfs, int cost)
        {
            if (r < 0 || r >= row || c < 0 || c >= col || dp[r, c] != int.MaxValue) return;//node ready visited or out of bound
            dp[r, c] = cost;
            bfs.Enqueue(new int[] { r, c });
            int nextDir = grid[r][c] - 1;
            DFS(grid, row, col, dp, r + DIR[nextDir][0], c + DIR[nextDir][1], bfs, cost);
        }
    }
}
