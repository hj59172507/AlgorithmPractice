"""
1307. Verbal Arithmetic Puzzle

Given an equation, represented by words on left side and the result on right side.

You need to check if the equation is solvable under the following rules:

Each character is decoded as one digit (0 - 9).
Every pair of different characters they must map to different digits.
Each words[i] and result are decoded as one number without leading zeros.
Sum of numbers on left side (words) will equal to the number on right side (result).
Return True if the equation is solvable otherwise return False.

Example 1:

Input: words = ["SEND","MORE"], result = "MONEY"
Output: true
Explanation: Map 'S'-> 9, 'E'->5, 'N'->6, 'D'->7, 'M'->1, 'O'->0, 'R'->8, 'Y'->'2'
Such that: "SEND" + "MORE" = "MONEY" ,  9567 + 1085 = 10652
Example 2:

Input: words = ["SIX","SEVEN","SEVEN"], result = "TWENTY"
Output: true
Explanation: Map 'S'-> 6, 'I'->5, 'X'->0, 'E'->8, 'V'->7, 'N'->2, 'T'->1, 'W'->'3', 'Y'->4
Such that: "SIX" + "SEVEN" + "SEVEN" = "TWENTY" ,  650 + 68782 + 68782 = 138214
Example 3:

Input: words = ["THIS","IS","TOO"], result = "FUNNY"
Output: true
Example 4:

Input: words = ["LEET","CODE"], result = "POINT"
Output: false

Constraints:

2 <= words.length <= 5
1 <= words[i].length, result.length <= 7
words[i], result contains only upper case English letters.
Number of different characters used on the expression is at most 10.

Sol
Use backtracking, key is to start from least signification digit, since all upper digit dependent on it
"""


class Solution:
    def isSolvable(self, words, result):
        if result in words: return 0
        words.append(result)
        R, C = len(words), max(map(len, words))
        d, inv = {}, [None] * 10

        def search(col, row, bal):
            if col >= C:
                return bal == 0
            if row == R:
                return bal % 10 == 0 and search(col + 1, 0, bal // 10)

            word = words[row]
            if col >= len(word):
                return search(col, row + 1, bal)
            letter = word[~col]
            sign = 1 if row < R - 1 else -1
            if letter in d:
                return search(col, row + 1, bal + sign * d[letter])
            else:
                for i, ad in enumerate(inv):
                    if ad is None and (i or col != len(word) - 1):
                        inv[i] = letter
                        d[letter] = i
                        if search(col, row + 1, bal + sign * i):
                            return 1
                        inv[i] = None
                        del(d[letter])
            return 0
        return search(0, 0, 0)