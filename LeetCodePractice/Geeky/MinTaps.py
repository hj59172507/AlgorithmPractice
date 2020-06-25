"""
1326. Minimum Number of Taps to Open to Water a Garden

There is a one-dimensional garden on the x-axis. The garden starts at the point 0 and ends at the point n. (i.e The length of the garden is n).

There are n + 1 taps located at points [0, 1, ..., n] in the garden.

Given an integer n and an integer array ranges of length n + 1 where ranges[i] (0-indexed) means the i-th tap can water the area [i - ranges[i], i + ranges[i]] if it was open.

Return the minimum number of taps that should be open to water the whole garden, If the garden cannot be watered return -1.

Example 1:

Input: n = 5, ranges = [3,4,1,1,0,0]
Output: 1
Explanation: The tap at point 0 can cover the interval [-3,3]
The tap at point 1 can cover the interval [-3,5]
The tap at point 2 can cover the interval [1,3]
The tap at point 3 can cover the interval [2,4]
The tap at point 4 can cover the interval [4,4]
The tap at point 5 can cover the interval [5,5]
Opening Only the second tap will water the whole garden [0,5]
Example 2:

Input: n = 3, ranges = [0,0,0,0]
Output: -1
Explanation: Even if you activate all the four taps you cannot water the whole garden.
Example 3:

Input: n = 7, ranges = [1,2,1,0,2,1,0,1]
Output: 3
Example 4:

Input: n = 8, ranges = [4,0,0,0,0,0,0,0,4]
Output: 2
Example 5:

Input: n = 8, ranges = [4,0,0,0,4,0,0,0,4]
Output: 1

Constraints:

1 <= n <= 10^4
ranges.length == n + 1
0 <= ranges[i] <= 100

Sol
Time O(n)
Space O(n)
Let max_range[i] store the maximum index we can go to at from index i,
then for each step, we only need to search for its index range, and find the max it can jump to.
return -1 if we can't jump to anywhere before end is reached.
"""
from typing import List


class Solution:
    def minTaps(self, n: int, ranges: List[int]) -> int:
        max_range = [0] * (n + 1)
        for i, r in enumerate(ranges):
            left, right = max(0, i - r), min(n, i + r)
            max_range[left] = max(max_range[left], right)
        start = end = step = 0
        while end < n:
            step += 1
            # from interval start to end, find the furthest point we can move to
            start, end = end, max(max_range[i] for i in range(start, end + 1))
            # if we couldn't move further
            if start == end:
                return -1
        return step


ss = Solution()
n = 9
ranges = [0, 5, 0, 3, 3, 3, 1, 4, 0, 4]
print(ss.minTaps(n, ranges))
