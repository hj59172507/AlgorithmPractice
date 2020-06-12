"""
1345. Jump Game IV

Given an array of integers arr, you are initially positioned at the first index of the array.

In one step you can jump from index i to index:

i + 1 where: i + 1 < arr.length.
i - 1 where: i - 1 >= 0.
j where: arr[i] == arr[j] and i != j.
Return the minimum number of steps to reach the last index of the array.

Notice that you can not jump outside of the array at any time.

Example 1:

Input: arr = [100,-23,-23,404,100,23,23,23,3,404]
Output: 3
Explanation: You need three jumps from index 0 --> 4 --> 3 --> 9. Note that index 9 is the last index of the array.
Example 2:

Input: arr = [7]
Output: 0
Explanation: Start index is the last index. You don't need to jump.
Example 3:

Input: arr = [7,6,9,6,9,6,9,7]
Output: 1
Explanation: You can jump directly from index 0 to index 7 which is last index of the array.
Example 4:

Input: arr = [6,1,9]
Output: 2
Example 5:

Input: arr = [11,22,7,7,7,7,7,7,7,22,13]
Output: 3

Constraints:

1 <= arr.length <= 5 * 10^4
-10^8 <= arr[i] <= 10^8

Sol
Time O(n)
Space O(n^2)
"""
from typing import List


class Solution:
    def minJumps(self, arr: List[int]) -> int:
        target = len(arr) - 1
        res = 0
        # build dictionary that map value to list of indexes they exist
        indexList = dict()
        for i in range(len(arr)):
            if arr[i] in indexList:
                indexList[arr[i]].append(i)
            else:
                indexList[arr[i]] = [i]
        # use a set to store all index visited, another set to store going to
        visited = [{0}]
        goingTo = set()
        while True:
            # found answer
            if target in visited[res]: return res
            # build going to from visited


        return res


s = Solution()
arr = [7, 6, 9, 6, 9, 6, 9, 7]
print(s.minJumps(arr))
