"""
1312. Minimum Insertion Steps to Make a String Palindrome

Given a string s. In one step you can insert any character at any index of the string.

Return the minimum number of steps to make s palindrome.

A Palindrome String is one that reads the same backward as well as forward.

Example 1:

Input: s = "zzazz"
Output: 0
Explanation: The string "zzazz" is already palindrome we don't need any insertions.
Example 2:

Input: s = "mbadm"
Output: 2
Explanation: String can be "mbdadbm" or "mdbabdm".
Example 3:

Input: s = "leetcode"
Output: 5
Explanation: Inserting 5 characters the string becomes "leetcodocteel".
Example 4:

Input: s = "g"
Output: 0
Example 5:

Input: s = "no"
Output: 1

Constraints:

1 <= s.length <= 500
All characters of s are lower case English letters.

Sol
Time O(n^2)
Space O(n^2)
Let dp[i][j] be the longest common subsequence for s1 start at i and s2 start at j where s1 = reverse(s2)
In other words, dp[n][n] will have longest subsequence of s that is a palindrome
Thus, answer is n - dp[n][n]
"""


class Solution:
    def minInsertions(self, s: str) -> int:
        n = len(s)
        dp = [[0] * (n + 1) for i in range(n+1)]
        for i in range(n):
            for j in range(n):
                dp[i+1][j+1] = dp[i][j] + 1 if s[i] == s[-j-1] else max(dp[i][j+1], dp[i+1][j])
        return n - dp[n][n]

