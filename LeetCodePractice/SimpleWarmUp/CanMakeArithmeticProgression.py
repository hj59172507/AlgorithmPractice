"""
1502. Can Make Arithmetic Progression From Sequence

Given an array of numbers arr. A sequence of numbers is called an arithmetic progression if the difference between any two consecutive elements is the same.

Return true if the array can be rearranged to form an arithmetic progression, otherwise, return false.

Example 1:

Input: arr = [3,5,1]
Output: true
Explanation: We can reorder the elements as [1,3,5] or [5,3,1] with differences 2 and -2 respectively, between each consecutive elements.
Example 2:

Input: arr = [1,2,4]
Output: false
Explanation: There is no way to reorder the elements to obtain an arithmetic progression.

Constraints:

2 <= arr.length <= 1000
-10^6 <= arr[i] <= 10^6

Sol1
Time O(nlogn)
Space O(1)
Sort the array and loop to check difference

Sol2
Time O(n)
Space O(n)
Find min, max of array, so we can calculate the difference
Check that each num - min is multiple of difference, and there is no duplicate values
"""
from typing import List


class Solution:
    def canMakeArithmeticProgression(self, arr: List[int]) -> bool:
        arr.sort()
        diff = arr[1] - arr[0]
        for i in range(1, len(arr) - 1):
            if arr[i + 1] - arr[i] != diff:
                return False
        return True


class Solution2:
    def canMakeArithmeticProgression(self, arr: List[int]) -> bool:
        least, most = min(arr), max(arr)
        if least == most:
            return True
        diff = (most - least) / (len(arr) - 1)
        s = set(i - least for i in arr)
        return len(s) == len(arr) and all(i % diff == 0 for i in s)
