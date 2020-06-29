"""
1309. Decrypt String from Alphabet to Integer Mapping

Given a string s formed by digits ('0' - '9') and '#' . We want to map s to English lowercase characters as follows:

Characters ('a' to 'i') are represented by ('1' to '9') respectively.
Characters ('j' to 'z') are represented by ('10#' to '26#') respectively.
Return the string formed after mapping.

It's guaranteed that a unique mapping will always exist.

Example 1:

Input: s = "10#11#12"
Output: "jkab"
Explanation: "j" -> "10#" , "k" -> "11#" , "a" -> "1" , "b" -> "2".
Example 2:

Input: s = "1326#"
Output: "acz"
Example 3:

Input: s = "25#"
Output: "y"
Example 4:

Input: s = "12345678910#11#12#13#14#15#16#17#18#19#20#21#22#23#24#25#26#"
Output: "abcdefghijklmnopqrstuvwxyz"

Constraints:

1 <= s.length <= 1000
s[i] only contains digits letters ('0'-'9') and '#' letter.
s will be valid string such that mapping is always possible.

Sol
Time O(n)
Space O(1)
Find index of first #, process all digits that are 2 index before # individually, and process 2 digits before # as group.
Remember the last place we see #, can continue the following until we can't find #.
Process all the left over as single digit
"""


class Solution:
    def freqAlphabets(self, s: str) -> str:
        index = s.find('#', 0)
        previousIndex = 0
        res = []
        while index != -1:
            for i in range(previousIndex, index - 2):
                res.append(chr(ord('`') + int(s[i])))
            res.append(chr(ord('`') + int(s[index-2:index])))
            previousIndex = index + 1
            index = s.find('#', previousIndex + 1)
        for i in range(previousIndex, len(s)):
            res.append(chr(ord('`') + int(s[i])))
        return ''.join(res)
        # one line regex
        # return ''.join(chr(int(i[:2]) + 96) for i in re.findall(r'\d\d#|\d', s))
