"""
1512. Number of Good Pairs

Given an array of integers nums.

A pair (i,j) is called good if nums[i] == nums[j] and i < j.

Return the number of good pairs.

 Example 1:

Input: nums = [1,2,3,1,1,3]
Output: 4
Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
Example 2:

Input: nums = [1,1,1,1]
Output: 6
Explanation: Each pair in the array are good.
Example 3:

Input: nums = [1,2,3]
Output: 0

Constraints:

1 <= nums.length <= 100
1 <= nums[i] <= 100

Sol
Time O(n)
Space O(n)
Use dictionary to remember how many time a number has occur, say i, for each future occurrence, there must be exactly i pairs
"""
from typing import List


class Solution:
    def numIdenticalPairs(self, nums: List[int]) -> int:
        count = dict()
        res = 0
        for n in nums:
            if n in count:
               res += count[n]
               count[n] += 1
            else:
                count[n] = 1
        return res