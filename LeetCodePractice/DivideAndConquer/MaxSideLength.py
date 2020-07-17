"""
1292. Maximum Side Length of a Square with Sum Less than or Equal to Threshold

Given a m x n matrix mat and an integer threshold. Return the maximum side-length of a square with a sum less than or equal to threshold or return 0 if there is no such square.

Example 1:

Input: mat = [[1,1,3,2,4,3,2],[1,1,3,2,4,3,2],[1,1,3,2,4,3,2]], threshold = 4
Output: 2
Explanation: The maximum side length of square with sum less than 4 is 2 as shown.
Example 2:

Input: mat = [[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2]], threshold = 1
Output: 0
Example 3:

Input: mat = [[1,1,1,1],[1,0,0,0],[1,0,0,0],[1,0,0,0]], threshold = 6
Output: 3
Example 4:

Input: mat = [[18,70],[61,1],[25,85],[14,40],[11,96],[97,96],[63,45]], threshold = 40184
Output: 2

Constraints:

1 <= m, n <= 300
m == mat.length
n == mat[i].length
0 <= mat[i][j] <= 10000
0 <= threshold <= 10^5

Sol
Time O(mnlog(min(m,n)))
Space O(1)
Iteration the matrix and computer the sum given by mat[i][j] = mat[i-1][j] + mat[i][j-1] - mat[i-1][j-1] + mat[i,j]
Check each square from using binary search, return the length of largest square satisfy condition, else 0
"""
from typing import List


class Solution:
    def maxSideLength(self, mat: List[List[int]], threshold: int) -> int:
        m, n = len(mat), len(mat[0])
        if min([min(mat[i]) for i in range(m)]) > threshold:
            return 0

        for i in range(1, m):
            mat[i][0] += mat[i - 1][0]
        for i in range(1, n):
            mat[0][i] += mat[0][i - 1]
        for i in range(1, m):
            for j in range(1, n):
                mat[i][j] += mat[i - 1][j] + mat[i][j - 1] - mat[i - 1][j - 1]
        right = min(m, n)
        left = 1
        res = 0
        while left <= right:
            side = (left + right + 1) // 2
            found = False
            for i in range(side - 1, m):
                for j in range(side - 1, n):
                    subtract = 0
                    if i - side >= 0 and j - side < 0:
                        subtract += mat[i - side][j]
                    elif j - side >= 0 and i - side < 0:
                        subtract += mat[i][j - side]
                    elif i - side >= 0 and j - side >= 0:
                        subtract = mat[i - side][j] + mat[i][j - side] - mat[i - side][j - side]
                    if mat[i][j] - subtract <= threshold:
                        found = True
                        res = side
                        break
                if found:
                    break
            if found:
                left = side + 1
            else:
                right = side - 1

        return res


S = Solution()
mat = [[1, 1, 3, 2, 4, 3, 2], [1, 1, 3, 2, 4, 3, 2], [1, 1, 3, 2, 4, 3, 2]]
t = 4
print(S.maxSideLength(mat, t))
