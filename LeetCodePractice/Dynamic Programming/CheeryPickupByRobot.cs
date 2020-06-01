using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1463. Cherry Pickup II
Given a rows x cols matrix grid representing a field of cherries. Each cell in grid represents the number of cherries that you can collect.

You have two robots that can collect cherries for you, Robot #1 is located at the top-left corner (0,0) , and Robot #2 is located at the top-right corner (0, cols-1) of the grid.

Return the maximum number of cherries collection using both robots  by following the rules below:

From a cell (i,j), robots can move to cell (i+1, j-1) , (i+1, j) or (i+1, j+1).
When any robot is passing through a cell, It picks it up all cherries, and the cell becomes an empty cell (0).
When both robots stay on the same cell, only one of them takes the cherries.
Both robots cannot move outside of the grid at any moment.
Both robots should reach the bottom row in the grid.
 
Example 1:

Input: grid = [[3,1,1],[2,5,1],[1,5,5],[2,1,1]]
Output: 24
Explanation: Path of robot #1 and #2 are described in color green and blue respectively.
Cherries taken by Robot #1, (3 + 2 + 5 + 2) = 12.
Cherries taken by Robot #2, (1 + 5 + 5 + 1) = 12.
Total of cherries: 12 + 12 = 24.
Example 2:

Input: grid = [[1,0,0,0,0,0,1],[2,0,0,0,0,3,0],[2,0,9,0,0,0,0],[0,3,0,5,4,0,0],[1,0,2,3,0,0,6]]
Output: 28
Explanation: Path of robot #1 and #2 are described in color green and blue respectively.
Cherries taken by Robot #1, (1 + 9 + 5 + 2) = 17.
Cherries taken by Robot #2, (1 + 3 + 4 + 3) = 11.
Total of cherries: 17 + 11 = 28.
Example 3:

Input: grid = [[1,0,0,3],[0,0,0,3],[0,0,3,3],[9,0,3,3]]
Output: 22
Example 4:

Input: grid = [[1,1],[1,1]]
Output: 4

Constraints:

rows == grid.length
cols == grid[i].length
2 <= rows, cols <= 70
0 <= grid[i][j] <= 100 

Sol DP
Time O()
Space O(m*n^2)
Let dp[r,c1,c2] be maxium cherry we can collect start at row r, robot 1 at col c1, robot 2 at col c2.
return dp[0,0,col-2]
We fill the table with following rule
1. If this node is already calculated, return it value
2. There are at most 9 possible combination of c1 and c2, try then all within the boundary
3. If c1 == c2, we only collect cherry once
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class CheeryPickupByRobot
    {
        //static void Main()
        static void Main1463()
        {
            int[][] grid = { new int[] { 3,1,1 },
                             new int[] { 2,5,1 },
                             new int[] { 1,5,5 },
                             new int[] { 2,1,1 } };
            Console.Out.WriteLine(CherryPickup(grid));
            Console.In.ReadLine();
        }
        public static int CherryPickup(int[][] grid)
        {
            int row = grid.Length, col = grid[0].Length;
            int?[,,] dp = new int?[row, col, col];
            return (int)dfs(grid, row, col, 0, 0, col-1, dp);
        }

        public static int? dfs(int[][] grid, int row, int col, int currentRow, int c1, int c2, int?[,,] dp)
        {
            if (currentRow == row) return 0; //finished all rows
            if (dp[currentRow, c1, c2] != null) return dp[currentRow, c1, c2];
            int ans = 0;
            for (int i = -1; i <= 1; i++) //Given current c1 and c2, there are total of 9 possible steps
            {
                for(int j = -1; j <= 1; j++)
                {
                    int newC1 = c1 + i, newC2 = c2 + j;
                    if(newC1 >= 0 && newC1 < newC2 && newC2 < col) //edge check, optimized so robot1 is always left of robot2
                    {
                        ans = Math.Max(ans, (int)dfs(grid, row, col, currentRow + 1, newC1, newC2, dp));
                    }
                }
            }
            dp[currentRow, c1, c2] = c1 == c2 ? ans + grid[currentRow][c1] : ans + grid[currentRow][c1] + grid[currentRow][c2]; //We can only collect cheery once if c1 == c2
            return dp[currentRow, c1, c2];
        }
    }
}
