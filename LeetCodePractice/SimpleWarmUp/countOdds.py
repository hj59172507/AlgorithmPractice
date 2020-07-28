"""
Count Odd Numbers in an Interval Range

Add to List

Share
Given two non-negative integers low and high. Return the count of odd numbers between low and high (inclusive).

Example 1:

Input: low = 3, high = 7
Output: 3
Explanation: The odd numbers between 3 and 7 are [3,5,7].
Example 2:

Input: low = 8, high = 10
Output: 1
Explanation: The odd numbers between 8 and 10 are [9].

Constraints:

0 <= low <= high <= 10^9

Sol
Time O(1)
Space O(1)
If range has even length, then number of odd is simply length / 2
Else, number of odd is length / 2 + 1 if range start with odd
"""



class Solution:
    def countOdds(self, low: int, high: int) -> int:
        length = high - low + 1
        startOdd = 1 if low % 2 == 1 else 0
        if length%2==0:
            return length // 2
        else:
            return length // 2 + startOdd
