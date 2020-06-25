"""
1324. Print Words Vertically

Given a string s. Return all the words vertically in the same order in which they appear in s.
Words are returned as a list of strings, complete with spaces when is necessary. (Trailing spaces are not allowed).
Each word would be put on only one column and that in one column there will be only one word.

Example 1:

Input: s = "HOW ARE YOU"
Output: ["HAY","ORO","WEU"]
Explanation: Each word is printed vertically.
 "HAY"
 "ORO"
 "WEU"
Example 2:

Input: s = "TO BE OR NOT TO BE"
Output: ["TBONTB","OEROOE","   T"]
Explanation: Trailing spaces is not allowed.
"TBONTB"
"OEROOE"
"   T"
Example 3:

Input: s = "CONTEST IS COMING"
Output: ["CIC","OSO","N M","T I","E N","S G","T"]

Constraints:

1 <= s.length <= 200
s contains only upper case English letters.
It's guaranteed that there is only one space between 2 words.

Sol
Time O(n^2)
Space O(n^2)
Split string into words, and find the max length.
map strings vertically to 2d array with max length row and len(words) cols
r strip empty space for each word at the end
"""
from typing import List


class Solution:
    def printVertically(self, s: str) -> List[str]:
        strs = s.split(" ")
        maxWord = max([len(i) for i in strs])
        strMap = [[' ' for j in range(len(strs))] for i in range(maxWord)]
        for r in range(len(strs)):
            for c in range(maxWord):
                word = strs[r]
                if c < len(word):
                    strMap[c][r] = word[c]
        res = []
        for i in strMap:
            res.append("".join(i).rstrip())
        return res
