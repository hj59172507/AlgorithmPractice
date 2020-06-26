"""
1316. Distinct Echo Substrings

Return the number of distinct non-empty substrings of text that can be written as the concatenation of some string with itself (i.e. it can be written as a + a where a is some string).

Example 1:

Input: text = "abcabcabc"
Output: 3
Explanation: The 3 substrings are "abcabc", "bcabca" and "cabcab".
Example 2:

Input: text = "leetcodeleetcode"
Output: 2
Explanation: The 2 substrings are "ee" and "leetcodeleetcode".

Constraints:

1 <= text.length <= 2000
text has only lowercase English letters.

Sol
Time O(n)
Space O(n)
Brute force all substring, and hash first half and second half.
Also keep a set of found answer
"""


class Solution:
    def distinctEchoSubstrings(self, text: str) -> int:
        size = 2
        res = set()
        while size <= len(text):
            i = 0
            while i + size <= len(text):
                sub = text[i:i+size]
                mid = len(sub)//2
                if hash(sub[0:mid]) == hash(sub[mid:len(sub)]) and sub[0:mid] not in res:
                    res.add(sub[0:mid])
                i += 1
            size += 2
        return len(res)

