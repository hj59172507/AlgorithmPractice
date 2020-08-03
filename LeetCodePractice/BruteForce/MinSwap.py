"""
1536. Minimum Swaps to Arrange a Binary Grid
Medium

119

35

Add to List

Share
Given an n x n binary grid, in one step you can choose two adjacent rows of the grid and swap them.

A grid is said to be valid if all the cells above the main diagonal are zeros.

Return the minimum number of steps needed to make the grid valid, or -1 if the grid cannot be valid.

The main diagonal of a grid is the diagonal that starts at cell (1, 1) and ends at cell (n, n).



Example 1:


Input: grid = [[0,0,1],[1,1,0],[1,0,0]]
Output: 3
Example 2:


Input: grid = [[0,1,1,0],[0,1,1,0],[0,1,1,0],[0,1,1,0]]
Output: -1
Explanation: All rows are similar, swaps have no effect on the grid.
Example 3:


Input: grid = [[1,0,0],[1,1,0],[1,1,1]]
Output: 0


Constraints:

n == grid.length
n == grid[i].length
1 <= n <= 200
grid[i][j] is 0 or 1

Sol
Time O(n^2)
Space O(n)
Find number of right zeros for each row, start from top where is needs most right zeros, we search if there is a row satisfy that and swap it.
If search failed for any step, return -1.
"""
from typing import List


class Solution:
    def minSwaps(self, grid: List[List[int]]) -> int:
        n = len(grid)

        # get number of right zeros
        def count(arr):
            ans = 0
            for i in range(n - 1, -1, -1):
                if arr[i] == 0:
                    ans += 1
                else:
                    break
            return ans

        arr = [count(row) for row in grid]
        ans = 0
        for i in range(n):
            target = n - i - 1
            if arr[i] >= target:
                continue
            flag = False
            for j in range(i + 1, n):
                if arr[j] >= target:
                    flag = True
                    ans += (j - i)
                    arr[i + 1:j + 1] = arr[i:j]
                    break
            if not flag:
                return -1

        return ans