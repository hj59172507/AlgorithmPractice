"""
1297. Maximum Number of Occurrences of a Substring

Given a string s, return the maximum number of ocurrences of any substring under the following rules:

The number of unique characters in the substring must be less than or equal to maxLetters.
The substring size must be between minSize and maxSize inclusive.

Example 1:

Input: s = "aababcaab", maxLetters = 2, minSize = 3, maxSize = 4
Output: 2
Explanation: Substring "aab" has 2 ocurrences in the original string.
It satisfies the conditions, 2 unique letters and size 3 (between minSize and maxSize).
Example 2:

Input: s = "aaaa", maxLetters = 1, minSize = 3, maxSize = 3
Output: 2
Explanation: Substring "aaa" occur 2 times in the string. It can overlap.
Example 3:

Input: s = "aabcabcab", maxLetters = 2, minSize = 2, maxSize = 3
Output: 3
Example 4:

Input: s = "abcde", maxLetters = 2, minSize = 3, maxSize = 3
Output: 0

Constraints:

1 <= s.length <= 10^5
1 <= maxLetters <= 26
1 <= minSize <= maxSize <= min(26, s.length)
s only contains lowercase English letters.

Sol
Time O(nk)
Space O(nk)
It is sufficient to just check minSize substring.
If a string si have most frequency in s with size > minSize and satisfy given condition,
then we can always find sj with size(sj) < size(si) with at least same frequency because si simply contains sj
"""
import collections


class Solution:
    def maxFreq(self, s: str, maxLetters: int, minSize: int, maxSize: int) -> int:
        counter = collections.Counter([s[i:i+minSize] for i in range(0, len(s)-minSize+1)])
        return max([counter[w] for w in counter if len(set(w)) <= maxLetters] + [0])
