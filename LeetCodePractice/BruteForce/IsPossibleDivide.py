"""
1296. Divide Array in Sets of K Consecutive Numbers

Given an array of integers nums and a positive integer k, find whether it's possible to divide this array into sets of k consecutive numbers
Return True if its possible otherwise return False.

Example 1:

Input: nums = [1,2,3,3,4,4,5,6], k = 4
Output: true
Explanation: Array can be divided into [1,2,3,4] and [3,4,5,6].
Example 2:

Input: nums = [3,2,1,2,3,4,3,4,5,9,10,11], k = 3
Output: true
Explanation: Array can be divided into [1,2,3] , [2,3,4] , [3,4,5] and [9,10,11].
Example 3:

Input: nums = [3,3,2,2,1,1], k = 3
Output: true
Example 4:

Input: nums = [1,2,3,4], k = 3
Output: false
Explanation: Each array should be divided in subarrays of size 3.

Constraints:

1 <= nums.length <= 10^5
1 <= nums[i] <= 10^9
1 <= k <= nums.length

Sol
Time O(n)
Space O(n)
1. Get a count of numbers in array using dictionary.
2. Find the root in the dictionary by checking if n-1 exist in array
3. Test for all roots, and update dictionary
4. repeat step 2 to 3 until no more element in dictionary or test failed in step 3
"""
import collections
from typing import List



class Solution2:
    def isPossibleDivide(self, nums: List[int], k: int) -> bool:
        if len(nums) % k != 0:
            return False
        count = collections.Counter(nums)
        roots = [n for n in count if not count[n-1]]
        while roots:
            r = roots.pop()
            for i in range(r+k-1, r-1, -1):
                if not count[i] or not count[r] or count[i] < count[r]:
                    return False
                count[i] -= count[r]
                if not count[i] and count[i+1]:
                    roots.append(i+1)
        return True
