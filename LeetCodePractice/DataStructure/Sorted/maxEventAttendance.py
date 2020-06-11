"""
1353. Maximum Number of Events That Can Be Attended

Given an array of events where events[i] = [startDayi, endDayi]. Every event i starts at startDayi and ends at endDayi.

You can attend an event i at any day d where startTimei <= d <= endTimei. Notice that you can only attend one event at any time d.

Return the maximum number of events you can attend.

Example 1:

Input: events = [[1,2],[2,3],[3,4]]
Output: 3
Explanation: You can attend all the three events.
One way to attend them all is as shown.
Attend the first event on day 1.
Attend the second event on day 2.
Attend the third event on day 3.
Example 2:

Input: events= [[1,2],[2,3],[3,4],[1,2]]
Output: 4
Example 3:

Input: events = [[1,4],[4,4],[2,2],[3,4],[1,1]]
Output: 4
Example 4:

Input: events = [[1,100000]]
Output: 1
Example 5:

Input: events = [[1,1],[1,2],[1,3],[1,4],[1,5],[1,6],[1,7]]
Output: 7

Constraints:

1 <= events.length <= 10^5
events[i].length == 2
1 <= events[i][0] <= events[i][1] <= 10^5

Sol
Time O(nlog(n))
Space O(1)
Sort by event start day, then one each day, attend the event that will end earliest.
Proof by contradiction:
If there are events E1 and E2 where both are available to attend but E1 ends earlier.
Suppose we have schedule s1 that picks E2 over E1,
then there must exist s2 that E1 is pick over E2 and s2 is not worse then s1.
1. If both E1 and E2 are picked with E2 first, then swap them won't cause s2 be worse than s1.
2. If E1 is not picked, then replace E2 with E1 won't cause s2 be worse than s1.
"""

from typing import List
import heapq


class Solution:
    def maxEvents(self, events: List[List[int]]) -> int:
        events.sort()
        lastDay = max(e[1] for e in events)
        minHeap = []
        day, res, eventNum = 1, 0, 0
        while day <= lastDay:
            # jump to day of first available event
            if eventNum < len(events) and not minHeap:
                day = events[eventNum][0]
            # add events start on today to min heap
            while eventNum < len(events) and events[eventNum][0] <= day:
                heapq.heappush(minHeap, events[eventNum][1])
                eventNum += 1
            # discard any events already ended
            while minHeap and minHeap[0] < day:
                heapq.heappop(minHeap)
            # attend event by popping from min heap, which has earliest end day
            if minHeap:
                heapq.heappop(minHeap)
                res += 1
            elif eventNum >= len(events):
                break
            day += 1
        return res


ec = Solution()
print(ec.maxEvents([[1, 2], [2, 3], [3, 4], [1, 2]]))
