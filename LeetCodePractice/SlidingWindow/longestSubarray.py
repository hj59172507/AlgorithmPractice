"""
1493. Longest Subarray of 1's After Deleting One Element

Given a binary array nums, you should delete one element from it.

Return the size of the longest non-empty subarray containing only 1's in the resulting array.

Return 0 if there is no such subarray.

Example 1:

Input: nums = [1,1,0,1]
Output: 3
Explanation: After deleting the number in position 2, [1,1,1] contains 3 numbers with value of 1's.
Example 2:

Input: nums = [0,1,1,1,0,1,1,0,1]
Output: 5
Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest subarray with value of 1's is [1,1,1,1,1].
Example 3:

Input: nums = [1,1,1]
Output: 2
Explanation: You must delete one element.
Example 4:

Input: nums = [1,1,0,0,1,1,1,0,1]
Output: 4
Example 5:

Input: nums = [0,0,0]
Output: 0

Constraints:

1 <= nums.length <= 10^5
nums[i] is either 0 or 1

Sol
Time O(n)
Space O(1)
find the length of first 1's, get index of next 1's and well as its length.
If they are only 1 zeros part, update result, else update the variable
"""
from typing import List


class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        i, res = 0, 0
        n = len(nums)
        prevSize, prevIndex = 0, 0
        while i < n and nums[i] == 0:
            i += 1
        while i + prevSize < n and nums[i + prevSize] == 1:
            prevSize += 1
        prevIndex = i + prevSize - 1
        i += prevSize
        res = prevSize
        while i < n:
            size = 0
            while i < n and nums[i] == 0:
                i += 1
            while i + size < n and nums[i + size] == 1:
                size += 1
            if i - prevIndex > 2:
                res = max(res, size)
            else:
                res = max(res, prevSize + size)
            prevSize = size
            i += size
            prevIndex = i - 1

        return res if res != n else res - 1


s = Solution()
a = [0, 1, 1, 1, 0, 1, 1, 0, 1]
print(s.longestSubarray(a))
