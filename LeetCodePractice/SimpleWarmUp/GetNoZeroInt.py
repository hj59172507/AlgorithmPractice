"""
1317. Convert Integer to the Sum of Two No-Zero Integers

Given an integer n. No-Zero integer is a positive integer which doesn't contain any 0 in its decimal representation.

Return a list of two integers [A, B] where:

A and B are No-Zero integers.
A + B = n
It's guarateed that there is at least one valid solution. If there are many valid solutions you can return any of them.

Example 1:

Input: n = 2
Output: [1,1]
Explanation: A = 1, B = 1. A + B = n and both A and B don't contain any 0 in their decimal representation.
Example 2:

Input: n = 11
Output: [2,9]
Example 3:

Input: n = 10000
Output: [1,9999]
Example 4:

Input: n = 69
Output: [1,68]
Example 5:

Input: n = 1010
Output: [11,999]

Constraints:

2 <= n <= 10^4
Accepted

Sol
Time O(digit)
Space O(digit)
build the int a, b from least signification digit, treat 0 and 1 as 10 and 11 by borrowing
"""
from typing import List


class Solution:
    def getNoZeroIntegers(self, n: int) -> List[int]:
        a, b, step = 0, 0, 1
        while n > 0:
            d = n % 10
            n = n // 10
            if (d == 1 or d == 0) and n > 0:
                a += step * (1 + d)
                b += step * (9)
                n -= 1
            else:
                a += step * 1
                b += step * (d - 1)
            step *= 10
        return [a, b]
