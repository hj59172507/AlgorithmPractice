"""
1504. Count Submatrices With All Ones

Given a rows * columns matrix mat of ones and zeros, return how many submatrices have all ones.

Example 1:

Input: mat = [[1,0,1],
              [1,1,0],
              [1,1,0]]
Output: 13
Explanation:
There are 6 rectangles of side 1x1.
There are 2 rectangles of side 1x2.
There are 3 rectangles of side 2x1.
There is 1 rectangle of side 2x2.
There is 1 rectangle of side 3x1.
Total number of rectangles = 6 + 2 + 3 + 1 + 1 = 13.
Example 2:

Input: mat = [[0,1,1,0],
              [0,1,1,1],
              [1,1,1,0]]
Output: 24
Explanation:
There are 8 rectangles of side 1x1.
There are 5 rectangles of side 1x2.
There are 2 rectangles of side 1x3.
There are 4 rectangles of side 2x1.
There are 2 rectangles of side 2x2.
There are 2 rectangles of side 3x1.
There is 1 rectangle of side 3x2.
Total number of rectangles = 8 + 5 + 2 + 4 + 2 + 2 + 1 = 24.
Example 3:

Input: mat = [[1,1,1,1,1,1]]
Output: 21
Example 4:

Input: mat = [[1,0,1],[0,1,0],[1,0,1]]
Output: 5

Constraints:

1 <= rows <= 150
1 <= columns <= 150
0 <= mat[i][j] <= 1

Sol1:
Time O(n^3)
Space O(n)
Let h[i,j] be height of histogram at row i, and column j.
h[i, j] = 0 if m[i,j] = 0, else = h[i-1, j] + 1
since h only depend on previous row, we can reduced it to one dimension
number of rectangle that uses m[i,j] is sum(min(h[i,j to 0])

Sol2
Time O(n^2)
Space O(n)
from previous step, we create a stack to store monotonic increasing histogram height,
and we can calculate number of rectangle that uses m[i,j] in O(1) by maintaining stack
since each column value is enter and pop at most once, over processing for each row in O(n)
"""
from typing import List


class Solution:
    def numSubmat(self, mat: List[List[int]]) -> int:
        row, col, h, res = len(mat), len(mat[0]), [0 for _ in range(len(mat[0]))], 0
        for r in range(row):
            for c in range(col):
                h[c] = 0 if mat[r][c] == 0 else h[c] + 1
                minH = h[c]
                if minH > 0:
                    for i in range(c, -1, -1):
                        minH = min(minH, h[i])
                        res += minH
        return res

class Solution2:
    def numSubmat(self, mat: List[List[int]]) -> int:
        row, col, h, res = len(mat), len(mat[0]), [0 for _ in range(len(mat[0]))], 0
        for r in range(row):
            incStack = []
            for c in range(col):
                h[c] = 0 if mat[r][c] == 0 else h[c] + 1
                pSum = 0
                while incStack and h[incStack[-1][0]] >= h[c]:
                    incStack.pop()
                if incStack:
                    # current height is not min
                    pSum += h[c] * (c - incStack[-1][0]) + incStack[-1][1]
                else:
                    pSum += h[c] * (c + 1)
                res += pSum
                incStack.append([c, pSum])
        return res


