"""
Minimum Number of Increments on Subarrays to Form a Target Array

Given an array of positive integers target and an array initial of same size with all zeros.

Return the minimum number of operations to form a target array from initial if you are allowed to do the following operation:

Choose any subarray from initial and increment each value by one.
The answer is guaranteed to fit within the range of a 32-bit signed integer.

Example 1:

Input: target = [1,2,3,2,1]
Output: 3
Explanation: We need at least 3 operations to form the target array from the initial array.
[0,0,0,0,0] increment 1 from index 0 to 4 (inclusive).
[1,1,1,1,1] increment 1 from index 1 to 3 (inclusive).
[1,2,2,2,1] increment 1 at index 2.
[1,2,3,2,1] target array is formed.
Example 2:

Input: target = [3,1,1,2]
Output: 4
Explanation: (initial)[0,0,0,0] -> [1,1,1,1] -> [1,1,1,2] -> [2,1,1,2] -> [3,1,1,2] (target).
Example 3:

Input: target = [3,1,5,4,2]
Output: 7
Explanation: (initial)[0,0,0,0,0] -> [1,1,1,1,1] -> [2,1,1,1,1] -> [3,1,1,1,1]
                                  -> [3,1,2,2,2] -> [3,1,3,3,2] -> [3,1,4,4,2] -> [3,1,5,4,2] (target).
Example 4:

Input: target = [1,1,1,1]
Output: 1

Constraints:

1 <= target.length <= 10^5
1 <= target[i] <= 10^5

Sol1:
Time O(n^2)
Space O(1)
Start from 1, split the array by 1, and solve each sub problem and sum them up.

Sol2:
Time O(n)
Space O(1)
Start from position 0 with value i going right, if we see a larger value l, we need at least l - i operation.
If we see a smaller value, we don't need any operation, but we need to update current value to smaller one since this serves as a wall
"""
from typing import List


class Solution:
    def minNumberOperations(self, target: List[int]) -> int:
        def divideAndConquer(left: int, right: int, cmin: int):
            res, i = 0, left
            while i < right:
                if target[i] == cmin:
                    if left != i:
                        # left to i is a valid range
                        res += divideAndConquer(left, i, cmin + 1)
                    left = i + 1
                i += 1
            if left != i:
                res += divideAndConquer(left, i, cmin+1)
            return res + 1
        return divideAndConquer(0, len(target), 1)

class Solution2:
    def minNumberOperations(self, target: List[int]) -> int:
        res = target[0]
        current = target[0]
        for i in range(1, len(target)):
            if target[i] > current:
                res += target[i] - current
            current = target[i]
        return res
s = Solution()
target = [1,2,3,4,3,2,1]
print(s.minNumberOperations(target))