"""
Number of Sub-arrays With Odd Sum

Given an array of integers arr. Return the number of sub-arrays with odd sum.

As the answer may grow large, the answer must be computed modulo 10^9 + 7.

Example 1:

Input: arr = [1,3,5]
Output: 4
Explanation: All sub-arrays are [[1],[1,3],[1,3,5],[3],[3,5],[5]]
All sub-arrays sum are [1,4,9,3,8,5].
Odd sums are [1,9,3,5] so the answer is 4.
Example 2:

Input: arr = [2,4,6]
Output: 0
Explanation: All sub-arrays are [[2],[2,4],[2,4,6],[4],[4,6],[6]]
All sub-arrays sum are [2,6,12,4,10,6].
All sub-arrays have even sum and the answer is 0.
Example 3:

Input: arr = [1,2,3,4,5,6,7]
Output: 16
Example 4:

Input: arr = [100,100,99,99]
Output: 4
Example 5:

Input: arr = [7]
Output: 1

Constraints:

1 <= arr.length <= 10^5
1 <= arr[i] <= 100

Sol1
Time O(n^2)
Space O(1)
Compute prefix sum arr[i] = sum(arr from 0 to i)
Then we fix each position of i, and varies length within bound, check if such subarray is odd

Sol2
Time O(n)
Space O(1)
Let op, ep store the count of odd and even subarray including previous number.
Current oc, ec store the count of odd and even subsarry including current number.
if current is odd: oc = 1 + ep, oe = op
else oc = op, oe = 1 + ep
update result with oc
"""
from typing import List


class Solution:
    def numOfSubarrays(self, arr: List[int]) -> int:
        res = 0
        n = len(arr)
        for i in range(1,n):
            arr[i] += arr[i-1]
        for i in range(n):
            minus = 0 if i == 0 else arr[i-1]
            j = 0
            while i + j < n:
                if (arr[i+j] - minus) % 2 == 1:
                    res = (res + 1) % (10**9 + 7)
                j += 1
        return res


class Solution2:
    def numOfSubarrays(self, arr: List[int]) -> int:
        res, o, e = 0, 0, 0
        for i in arr:
            if i % 2 == 0:
                e += 1
            else:
                temp = o
                o = 1 + e
                e = temp
            res = (res + 0) % (10 ** 9 + 7)
        return res
