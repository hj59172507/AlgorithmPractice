"""
1318. Minimum Flips to Make a OR b Equal to c

Given 3 positives numbers a, b and c. Return the minimum flips required in some bits of a and b to make ( a OR b == c ). (bitwise OR operation).
Flip operation consists of change any single bit 1 to 0 or change the bit 0 to 1 in their binary representation.

Example 1:

Input: a = 2, b = 6, c = 5
Output: 3
Explanation: After flips a = 1 , b = 4 , c = 5 such that (a OR b == c)
Example 2:

Input: a = 4, b = 2, c = 7
Output: 1
Example 3:

Input: a = 1, b = 2, c = 3
Output: 0

Constraints:

1 <= a <= 10^9
1 <= b <= 10^9
1 <= c <= 10^9

Sol
Time O(number of digit in binary)
Space O(number of digit in binary)
Brute force and compare each digit
If a | b != c:
1. if c == 1, then only 1 change needed
2. if c == 0, then we need to change a and b to 0
"""


class Solution:
    def minFlips(self, a: int, b: int, c: int) -> int:
        a = bin(a)[2:]
        b = bin(b)[2:]
        c = bin(c)[2:]
        longest = max(len(a), len(b), len(c))
        a = '0' * (longest - len(a)) + a
        b = '0' * (longest - len(b)) + b
        c = '0' * (longest - len(c)) + c
        ans = 0
        for i in range(longest):
            ai, bi, ci = int(a[i]), int(b[i]), int(c[i])
            if ai | bi != ci:
               ans += 1 if ci == 1 else ai + bi
        return ans






