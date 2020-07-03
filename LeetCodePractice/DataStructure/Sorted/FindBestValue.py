"""
1300. Sum of Mutated Array Closest to Target

Given an integer array arr and a target value target, return the integer value such that when we change all the integers larger than value in the given array to be equal to value, the sum of the array gets as close as possible (in absolute difference) to target.

In case of a tie, return the minimum such integer.

Notice that the answer is not neccesarilly a number from arr.

Example 1:

Input: arr = [4,9,3], target = 10
Output: 3
Explanation: When using 3 arr converts to [3, 3, 3] which sums 9 and that's the optimal answer.
Example 2:

Input: arr = [2,3,5], target = 10
Output: 5
Example 3:

Input: arr = [60864,25176,27249,21296,20204], target = 56803
Output: 11361

Constraints:

1 <= arr.length <= 10^4
1 <= arr[i], target <= 10^5

Sol
Time O(nlogk) k is max of arr
Space O(n) from sorting
At each iteration, compute the average of remaining sum, which would be our ideal value
First value we see that is less than previous calculated value will be answer since this indicate a decrease in average
"""
from typing import List


class Solution:
    def findBestValue(self, arr: List[int], target: int) -> int:
        arr.sort()
        s, n = 0, len(arr)

        for i in range(n):
            ans = round((target - s) / n)
            if ans <= arr[i]: return ans
            s += arr[i]
            n -= 1

        return arr[-1]
