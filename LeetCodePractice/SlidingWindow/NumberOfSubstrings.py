"""
1358. Number of Substrings Containing All Three Characters

Given a string s consisting only of characters a, b and c.

Return the number of substrings containing at least one occurrence of all these characters a, b and c.

Example 1:

Input: s = "abcabc"
Output: 10
Explanation: The substrings containing at least one occurrence of the characters a, b and c are "abc", "abca", "abcab", "abcabc", "bca", "bcab", "bcabc", "cab", "cabc" and "abc" (again).
Example 2:

Input: s = "aaacb"
Output: 3
Explanation: The substrings containing at least one occurrence of the characters a, b and c are "aaacb", "aacb" and "acb".
Example 3:

Input: s = "abc"
Output: 1

Constraints:

3 <= s.length <= 5 x 10^4
s only consists of a, b or c characters.

Sol
Time O(n)
Space O(1)
1.Start from i, and scan until we have at least of of each 'a', 'b', and 'c'.
2.If we achieve above condition at j, then we have len(s) - j solutions from i.
3.Move i forward and update the count, if condition still true, append result again. Else repeat step 1.
"""


def numberOfSubstrings(s):
    res = i = 0
    count = {c: 0 for c in 'abc'}
    for j in range(len(s)):
        count[s[j]] += 1
        while all(count.values()):
            count[s[i]] -= 1
            i += 1
        res += i
    return res


print(numberOfSubstrings("aaacb"))
