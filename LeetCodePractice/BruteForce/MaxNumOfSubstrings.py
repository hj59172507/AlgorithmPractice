"""
1520. Maximum Number of Non-Overlapping Substrings

Given a string s of lowercase letters, you need to find the maximum number of non-empty substrings of s that meet the following conditions:

The substrings do not overlap, that is for any two substrings s[i..j] and s[k..l], either j < k or i > l is true.
A substring that contains a certain character c must also contain all occurrences of c.
Find the maximum number of substrings that meet the above conditions. If there are multiple solutions with the same number of substrings, return the one with minimum total length. It can be shown that there exists a unique solution of minimum total length.

Notice that you can return the substrings in any order.

Example 1:

Input: s = "adefaddaccc"
Output: ["e","f","ccc"]
Explanation: The following are all the possible substrings that meet the conditions:
[
  "adefaddaccc"
  "adefadda",
  "ef",
  "e",
  "f",
  "ccc",
]
If we choose the first string, we cannot choose anything else and we'd get only 1. If we choose "adefadda", we are left with "ccc" which is the only one that doesn't overlap, thus obtaining 2 substrings. Notice also, that it's not optimal to choose "ef" since it can be split into two. Therefore, the optimal way is to choose ["e","f","ccc"] which gives us 3 substrings. No other solution of the same number of substrings exist.
Example 2:

Input: s = "abbaccd"
Output: ["d","bb","cc"]
Explanation: Notice that while the set of substrings ["d","abba","cc"] also has length 3, it's considered incorrect since it has larger total length.

Constraints:

1 <= s.length <= 10^5
s contains only lowercase English letters.

Sol
Time O(n)
Space O(n)
Let interval[c] store the start and end index of a valid substring with char c
Brute force the solution by check if intervals of all c overlaps
Since there is at most 26 elements in c, worst is 26^2*n
Possible optimization:
    1.remove duplicate
    2.instead of finding valid interval for all letter,
    only consider substring starting starting at i that is already valid,
    since if it is invalid, it must be included in some other valid string already
"""
from typing import List


class Solution:
    def maxNumOfSubstrings(self, s: str) -> List[str]:
        # store first and last occurrence of a letter
        occurrence = dict()
        for i, c in enumerate(s):
            if c in occurrence:
                occurrence[c][1] = i
            else:
                occurrence[c] = [i, i]

        interval = dict()
        for c in s:
            if c in interval:
                continue
            left, right = occurrence[c][0] + 1, occurrence[c][1]
            interval[c] = [left - 1, right]
            while left < right:
                nRight = occurrence[s[left]][1]
                nLeft = occurrence[s[left]][0]
                if nRight > right:
                    right = nRight
                if nLeft < interval[c][0]:
                    interval[c][0] = nLeft
                left += 1
            interval[c][1] = right
            occurrence[c] = interval[c]

        # brute force all combination of intervals to produce best result
        res = [[], 999999999]
        for i in interval.keys():
            il, ir = interval[i][0], interval[i][1]
            include = s[il:ir + 1]
            used = [[il, ir]]
            temp = [[include], len(include)]
            for c in interval.keys():
                cl, cr = interval[c][0], interval[c][1]
                overlap = False
                for u in used:
                    if not (cl > u[1] or cr < u[0]):
                        overlap = True
                        break
                if not overlap:
                    used.append([cl, cr])
                    temp[0].append(s[cl:cr + 1])
                    temp[1] += cr - cl + 1
            if len(temp[0]) > len(res[0]) or (len(temp[0]) == len(res[0]) and temp[1] < res[1]):
                res = temp
        return res[0]


s = Solution()
st = "cabcccbaa"
print(s.maxNumOfSubstrings(st))
