"""
1351. Count Negative Numbers in a Sorted Matrix

Given a m * n matrix grid which is sorted in non-increasing order both row-wise and column-wise.

Return the number of negative numbers in grid.

Example 1:

Input: grid = [[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
Output: 8
Explanation: There are 8 negatives number in the matrix.
Example 2:

Input: grid = [[3,2],[1,0]]
Output: 0
Example 3:

Input: grid = [[1,-1],[-1,-1]]
Output: 3
Example 4:

Input: grid = [[-1]]
Output: 1

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 100
-100 <= grid[i][j] <= 100

Sol
Time O(m+n)
Space O(1)
Since matrix is sorted by row and column, we can start at last row i and first column j
If grid[i][j] < 0, then all column follow it is < 0, and we can process next row.
Else advance the column j.
"""

from typing import List


class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        row = len(grid)
        col = len(grid[0])
        count, i, j = 0, row - 1, 0
        while i >= 0 and j < col:
            if grid[i][j] < 0:
                count += col - j
                i -= 1
            else:
                j += 1
        return count


s = Solution()
grid = [[4, 3, 2, -1], [3, 2, 1, -1], [1, 1, -1, -2], [-1, -1, -2, -3]]
print(s.countNegatives(grid))
