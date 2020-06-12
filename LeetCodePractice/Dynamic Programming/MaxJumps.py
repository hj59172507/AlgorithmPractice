"""
1340. Jump Game V

Given an array of integers arr and an integer d. In one step you can jump from index i to index:

i + x where: i + x < arr.length and 0 < x <= d.
i - x where: i - x >= 0 and 0 < x <= d.
In addition, you can only jump from index i to index j if arr[i] > arr[j] and arr[i] > arr[k] for all indices k between i and j (More formally min(i, j) < k < max(i, j)).

You can choose any index of the array and start jumping. Return the maximum number of indices you can visit.

Notice that you can not jump outside of the array at any time.

Example 1:

Input: arr = [6,4,14,6,8,13,9,7,10,6,12], d = 2
Output: 4
Explanation: You can start at index 10. You can jump 10 --> 8 --> 6 --> 7 as shown.
Note that if you start at index 6 you can only jump to index 7. You cannot jump to index 5 because 13 > 9. You cannot jump to index 4 because index 5 is between index 4 and 6 and 13 > 9.
Similarly You cannot jump from index 3 to index 2 or index 1.
Example 2:

Input: arr = [3,3,3,3,3], d = 3
Output: 1
Explanation: You can start at any index. You always cannot jump to any index.
Example 3:

Input: arr = [7,6,5,4,3,2,1], d = 1
Output: 7
Explanation: Start at index 0. You can visit all the indicies.
Example 4:

Input: arr = [7,1,7,1,7,1], d = 2
Output: 2
Example 5:

Input: arr = [66], d = 1
Output: 1

Constraints:

1 <= arr.length <= 1000
1 <= arr[i] <= 10^5
1 <= d <= arr.length

Sol
Time O(nlog(n) + nd)
Space O(n)
Let dp[i] be the max jump start in i
Sort the index by its value, and start from the bottom
"""
from typing import List


class Solution:
    def maxJumps(self, arr: List[int], d: int) -> int:
        # sort index by value
        sortedIndex = [i[0] for i in sorted(enumerate(arr), key=lambda x: x[1])]
        # create table to store max jump starting at index i, initialize to -1
        dp = [1] * len(arr)
        for i in range(len(arr)):
            # find the max jump from least height
            currentIndex = sortedIndex[i]
            currentHeight = arr[sortedIndex[i]]
            for j in range(1, d + 1):
                # break if out side of upper bound, or new position is higher
                if currentIndex + j >= len(arr) or arr[currentIndex + j] >= currentHeight:
                    break
                dp[currentIndex] = max(dp[currentIndex], 1 + dp[currentIndex + j])
            for j in range(1, d + 1):
                # break if out side of lower bound, or new position is higher
                if currentIndex - j < 0 or arr[currentIndex - j] >= currentHeight:
                    break
                dp[currentIndex] = max(dp[currentIndex], 1 + dp[currentIndex - j])
        return max(dp)


s = Solution()
arr = [7, 6, 5, 4, 3, 2, 1]
d = 1
print(s.maxJumps(arr, d))
