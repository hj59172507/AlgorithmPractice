"""
1492. The kth Factor of n

Given two positive integers n and k.

A factor of an integer n is defined as an integer i where n % i == 0.

Consider a list of all factors of n sorted in ascending order, return the kth factor in this list or return -1 if n has less than k factors.

Example 1:

Input: n = 12, k = 3
Output: 3
Explanation: Factors list is [1, 2, 3, 4, 6, 12], the 3rd factor is 3.
Example 2:

Input: n = 7, k = 2
Output: 7
Explanation: Factors list is [1, 7], the 2nd factor is 7.
Example 3:

Input: n = 4, k = 4
Output: -1
Explanation: Factors list is [1, 2, 4], there is only 3 factors. We should return -1.
Example 4:

Input: n = 1, k = 1
Output: 1
Explanation: Factors list is [1], the 1st factor is 1.
Example 5:

Input: n = 1000, k = 3
Output: 4
Explanation: Factors list is [1, 2, 4, 5, 8, 10, 20, 25, 40, 50, 100, 125, 200, 250, 500, 1000].

Constraints:

1 <= k <= n <= 1000

Sol
Time O(logn)
Space O(logn)
Get all factors up to log(n)
"""
import collections
import math


class Solution:
    def kthFactor(self, n: int, k: int) -> int:
        smallF, bigF = collections.deque(), collections.deque()
        for i in range(1, int(math.sqrt(n))+1):
            if n % i == 0:
                if i**2 == n:
                    smallF.append(i)
                else:
                    smallF.append(i)
                    bigF.appendleft(n // i)
        if len(smallF) + len(bigF) < k:
            return -1
        if len(smallF) >= k:
            return smallF[k-1]
        return bigF[k - len(smallF) - 1]

