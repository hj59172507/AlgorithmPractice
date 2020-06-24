"""
1331. Rank Transform of an Array

Given an array of integers arr, replace each element with its rank.

The rank represents how large the element is. The rank has the following rules:

Rank is an integer starting from 1.
The larger the element, the larger the rank. If two elements are equal, their rank must be the same.
Rank should be as small as possible.

Example 1:

Input: arr = [40,10,20,30]
Output: [4,1,2,3]
Explanation: 40 is the largest element. 10 is the smallest. 20 is the second smallest. 30 is the third smallest.
Example 2:

Input: arr = [100,100,100]
Output: [1,1,1]
Explanation: Same elements share the same rank.
Example 3:

Input: arr = [37,12,28,9,100,56,80,5,12]
Output: [5,3,4,2,8,6,7,1,3]

Constraints:

0 <= arr.length <= 105
-109 <= arr[i] <= 109

Sol
Time O(nlogn)
Space O(n)
Sort the array and assign rank
"""
from typing import List


class Solution:
    def arrayRankTransform(self, arr: List[int]) -> List[int]:
        if not len(arr):
            return []
        arr = [[arr[i], i] for i in range(len(arr))]
        sortedArr = sorted(arr, key=lambda i: i[0])
        res = [0 for i in range(len(sortedArr))]
        res[sortedArr[0][1]] = 1
        rank = 1
        for i in range(1, len(sortedArr)):
            if sortedArr[i][0] != sortedArr[i - 1][0]:
                rank += 1
            res[sortedArr[i][1]] = rank
        # or short solutions
        # D = {j: i+1 for i,j in enumerate(sorted(set(arr)))}
        # return map(D.get, arr)
        return res

