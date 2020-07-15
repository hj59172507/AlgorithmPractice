"""
1513. Number of Substrings With Only 1s

Given a binary string s (a string consisting only of '0' and '1's).

Return the number of substrings with all characters 1's.

Since the answer may be too large, return it modulo 10^9 + 7.

Example 1:

Input: s = "0110111"
Output: 9
Explanation: There are 9 substring in total with only 1's characters.
"1" -> 5 times.
"11" -> 3 times.
"111" -> 1 time.
Example 2:

Input: s = "101"
Output: 2
Explanation: Substring "1" is shown 2 times in s.
Example 3:

Input: s = "111111"
Output: 21
Explanation: Each substring contains only 1's characters.
Example 4:

Input: s = "000"
Output: 0

Constraints:

s[i] == '0' or s[i] == '1'
1 <= s.length <= 10^5

Sol
Time O(n)
Space 1
Scan the string, and find all continues substring contain only 1's
For substring s with length l, number of substring with 1 of size from 1 to l is l + l-1 + l-2 ... 1
Such sum can to calculated using (l+1)*l//2
"""


class Solution:
    def numSub(self, s: str) -> int:
        res = 0
        l = 0
        mod = 10**9 + 7
        for i in s:
            if i == '1':
                l += 1
            else:
                res = (res + l*(l+1)//2) % mod
                l = 0
        res = (res + l * (l + 1) // 2) % mod
        return res