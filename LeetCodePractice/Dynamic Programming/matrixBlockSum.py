"""
1314. Matrix Block Sum

Given a m * n matrix mat and an integer K, return a matrix answer where each answer[i][j] is the sum of all elements mat[r][c] for i - K <= r <= i + K, j - K <= c <= j + K, and (r, c) is a valid position in the matrix.

Example 1:

Input: mat = [[1,2,3],[4,5,6],[7,8,9]], K = 1
Output: [[12,21,16],[27,45,33],[24,39,28]]
Example 2:

Input: mat = [[1,2,3],[4,5,6],[7,8,9]], K = 2
Output: [[45,45,45],[45,45,45],[45,45,45]]

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n, K <= 100
1 <= mat[i][j] <= 100

Sol:
Time O(mn)
Space O(mn)
Define matrix preSum[i][j] that store sum of all elements in mat[a][b] such that a >= 0, b >=0
preSum[i][j] = mat[i][j] + preSum[i-1][j] + preSum[i][-1] - preSum[i-1][j-1]
Then ans[i][j] = preSum[i+k][j+k] - preSum[i-k] - preSum[j-k] + preSum[i-k][j-k], for i-k and j-k >= 0
"""
from typing import List


class Solution:
    def matrixBlockSum(self, mat: List[List[int]], K: int) -> List[List[int]]:
        n = len(mat)
        m = len(mat[0])
        preSum = [[0 for i in range(m + 1)] for j in range(n + 1)]
        for i in range(1, n + 1):
            for j in range(1, m + 1):
                preSum[i][j] = preSum[i - 1][j] + preSum[i][j - 1] + mat[i - 1][j - 1] - preSum[i - 1][j - 1]
        for i in range(n):
            for j in range(m):
                low_i = max(0, i - K)
                low_j = max(0, j - K)
                high_i = min(n - 1, i + K) + 1
                high_j = min(m - 1, j + K) + 1
                mat[i][j] = preSum[high_i][high_j] - preSum[low_i][high_j] - \
                            preSum[high_i][low_j] + preSum[low_i][low_j]
        return mat


s = Solution()
mat = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
K = 1
print(s.matrixBlockSum(mat, K))
