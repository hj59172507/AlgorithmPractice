"""
1328. Break a Palindrome

Given a palindromic string palindrome, replace exactly one character by any lowercase English letter so that the string becomes the lexicographically smallest possible string that isn't a palindrome.

After doing so, return the final string.  If there is no way to do so, return the empty string.

Example 1:

Input: palindrome = "abccba"
Output: "aaccba"
Example 2:

Input: palindrome = "a"
Output: ""

Constraints:

1 <= palindrome.length <= 1000
palindrome consists of only lowercase English letters.

Sol
Time O(n)
Space O(1)
If p have 1 char, it is impossible
Else replace the first non a character in p
If after replace, we have all a's, then replace the last a to b
"""


class Solution:
    def breakPalindrome(self, palindrome: str) -> str:
        if len(palindrome) == 1 and palindrome[0] == 'a':
            return ""
        p2 = ""
        for c in range(len(palindrome)):
            if palindrome[c] != 'a':
                p2 = palindrome[0:c] + 'a' + palindrome[c+1:]
                break
        if p2.count('a') == len(p2):
            return palindrome[0:len(palindrome)-1] + 'b'
        return p2


