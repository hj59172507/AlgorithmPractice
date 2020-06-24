"""
1329. Sort the Matrix Diagonally

Given a m * n matrix mat of integers, sort it diagonally in ascending order from the top-left to the bottom-right then return the sorted array.

Example 1:

Input: mat = [[3,3,1,1],[2,2,1,2],[1,1,1,2]]
Output: [[1,1,1,1],[1,2,2,2],[1,2,3,3]]

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n <= 100
1 <= mat[i][j] <= 100

Sol
Time O(nlogm + mlogn)
Space O(max(n,m)
"""
from typing import List


class Solution:
    def diagonalSort(self, mat: List[List[int]]) -> List[List[int]]:
        # sort the diagonal starting at i, j
        def help(mat, i, j, row, col):
            arr = []
            cr = i
            cc = j
            while cr <= row and cc <= col:
                arr.append(mat[cr][cc])
                cr += 1
                cc += 1
            arr.sort()
            for a in arr:
                mat[i][j] = a
                i += 1
                j += 1
        # sort all possible diagonal starting point
        r = len(mat)
        c = len(mat[0])
        for i in range(r):
            help(mat, i, 0, r-1, c-1)
        for i in range(1, c):
            help(mat, 0, i, r-1, c-1)
        return mat



