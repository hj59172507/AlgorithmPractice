"""
1287. Element Appearing More Than 25% In Sorted Array

Given an integer array sorted in non-decreasing order, there is exactly one integer in the array that occurs more than 25% of the time.

Return that integer.

Example 1:

Input: arr = [1,2,2,6,6,6,6,7,10]
Output: 6

Constraints:

1 <= arr.length <= 10^4
0 <= arr[i] <= 10^5


Sol
Time O(n)
Space O(1)
Do a linear scan, answer must appear again in first position + len/4

Sol2
Time O(1)
Space O(1)
Solution must cross 0, 25, 50, 75 percentile range. If len is mulitple of 4, we can just check 4 position and done
Can't get off by 1 error right...
"""
from typing import List


class Solution:
    def findSpecialInteger(self, arr: List[int]) -> int:
        n = len(arr) // 4
        for i in range(len(arr)):
            if arr[i] == arr[i + n]:
                return arr[i]

s = Solution()
arr = [1,2,2,6,6,6,6,7,10]
print(s.findSpecialInteger(arr))