"""
1288. Remove Covered Intervals

Given a list of intervals, remove all intervals that are covered by another interval in the list. Interval [a,b) is covered by interval [c,d) if and only if c <= a and b <= d.

After doing so, return the number of remaining intervals.

Example 1:

Input: intervals = [[1,4],[3,6],[2,8]]
Output: 2
Explanation: Interval [3,6] is covered by [2,8], therefore it is removed.

Constraints:

1 <= intervals.length <= 1000
0 <= intervals[i][0] < intervals[i][1] <= 10^5
intervals[i] != intervals[j] for all i != j

Sol
Time O(nlogn)
Space O(n) from sorting
Sort the array by first value, check each value against a base value. if next value and base can't be merge, update answer. update base regardless.
"""
from typing import List


class Solution:
    def removeCoveredIntervals(self, intervals: List[List[int]]) -> int:
        intervals.sort(key=lambda x: x[0])
        base = intervals[0]
        res = 1
        for i in range(1, len(intervals)):
            if intervals[i][1] > base[1]:
                # only add answer if we can't merge two intervals
                if base[0] < intervals[i][0]:
                    res += 1
                base = intervals[i]
        return res
