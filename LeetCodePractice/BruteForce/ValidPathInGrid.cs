using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
1391. Check if There is a Valid Path in a Grid

Given a m x n grid. Each cell of the grid represents a street. The street of grid[i][j] can be:
1 which means a street connecting the left cell and the right cell.
2 which means a street connecting the upper cell and the lower cell.
3 which means a street connecting the left cell and the lower cell.
4 which means a street connecting the right cell and the lower cell.
5 which means a street connecting the left cell and the upper cell.
6 which means a street connecting the right cell and the upper cell.

You will initially start at the street of the upper-left cell (0,0). A valid path in the grid is a path which starts from the upper left cell (0,0) and ends at the bottom-right cell (m - 1, n - 1). The path should only follow the streets.

Notice that you are not allowed to change any street.

Return true if there is a valid path in the grid or false otherwise.

Example 1:

Input: grid = [[2,4,3],[6,5,2]]
Output: true
Explanation: As shown you can start at cell (0, 0) and visit all the cells of the grid to reach (m - 1, n - 1).
Example 2:

Input: grid = [[1,2,1],[1,2,1]]
Output: false
Explanation: As shown you the street at cell (0, 0) is not connected with any street of any other cell and you will get stuck at cell (0, 0)
Example 3:

Input: grid = [[1,1,2]]
Output: false
Explanation: You will get stuck at cell (0, 1) and you cannot reach cell (0, 2).
Example 4:

Input: grid = [[1,1,1,1,1,1,3]]
Output: true
Example 5:

Input: grid = [[2],[2],[2],[2],[2],[2],[6]]
Output: true
 
Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 300
1 <= grid[i][j] <= 6

Sol DFS
Time O(n) n is number of street
Space O(n)
 */
namespace LeetCodePractice.BruteForce
{
    class ValidPathInGrid
    {
        static void Main()
        //static void Main1392()
        {
            //int[][] grid = { new int[] {1,2,1},
            //                 new int[] {1,2,1} };
            int[][] grid = { new int[] {4,1},
                             new int[] {6,1} };
            Console.Out.WriteLine(HasValidPath(grid));
            Console.In.ReadLine();
        }
        public static bool HasValidPath(int[][] grid)
        {            
            return dfs(grid, 0, 0, grid.Length, grid[0].Length, new bool[grid.Length, grid[0].Length]);
        }

        static bool dfs(int[][] grid, int i, int j, int row, int col, bool[,] visited)
        {
            if (i < 0 || i >= row || j < 0 || j >= col || visited[i,j]) return false;
            if (i == row - 1 && j == col - 1) return true;
            visited[i, j] = true;
            bool step1, step2;
            int newI = i + dir[grid[i][j] - 1][0], newJ = j + dir[grid[i][j] - 1][1], newI2 = i + dir[grid[i][j] - 1][2], newJ2 = j + dir[grid[i][j] - 1][3];
            step1 = (newI < 0 || newI >= row || newJ < 0 || newJ >= col || visited[newI, newJ]) ? 
                    false : newI + dir[grid[newI][newJ] - 1][0] == i && newJ + dir[grid[newI][newJ] - 1][1] == j || newI + dir[grid[newI][newJ] - 1][2] == i && newJ + dir[grid[newI][newJ] - 1][3] == j;
            step2 = (newI2 < 0 || newI2 >= row || newJ2 < 0 || newJ2 >= col || visited[newI2, newJ2]) ? 
                    false : newI2 + dir[grid[newI2][newJ2] - 1][0] == i && newJ2 + dir[grid[newI2][newJ2] - 1][1] == j || newI2 + dir[grid[newI2][newJ2] - 1][2] == i && newJ2 + dir[grid[newI2][newJ2] - 1][3] == j;
            bool try1 = step1 ? dfs(grid, i + dir[grid[i][j] - 1][0], j + dir[grid[i][j] - 1][1], row, col, visited) : false;
            bool try2 = step2 ? dfs(grid, i + dir[grid[i][j] - 1][2], j + dir[grid[i][j] - 1][3], row, col, visited) : false;
            return try1 || try2;
        }

        static int[][] dir = { new int[] { 0, -1, 0, 1 },
                        new int[] { -1, 0, 1, 0 },
                        new int[] { 0, -1, 1, 0 },
                        new int[] { 0, 1, 1, 0 },
                        new int[] { -1, 0, 0, -1 },
                        new int[] { -1, 0, 0, 1 }};

    }
}
