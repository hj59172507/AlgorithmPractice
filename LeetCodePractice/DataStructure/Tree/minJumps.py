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
Time O(v+e)
Space O(n)
Trim the arr with 3 or more consecutive same value to 2: 7,7,7,7,7 would be same as 7,7
It eliminates the possibility of v^2 edges, leaving us at most 3v edges.
Then, create a graph and perform bfs on it.
"""
import collections
import itertools
from typing import List


class Solution:
    def minJumps(self, arr: List[int]) -> int:
        res = 0

        # trim the array
        trim_arr = []
        if len(arr) >= 3:
            trim_arr.append(arr[0])
            trim_arr.append(arr[1])
            for i in range(2, len(arr)):
                if not (arr[i - 2] == arr[i - 1] and arr[i - 1] == arr[i]):
                    trim_arr.append(arr[i])
        else:
            trim_arr = arr
        target = len(trim_arr) - 1

        # build dictionary that map value to list of indexes they exist
        indexList = dict()
        for i in range(len(trim_arr)):
            if trim_arr[i] in indexList:
                indexList[trim_arr[i]].append(i)
            else:
                indexList[trim_arr[i]] = [i]

        # build a graph from indexList and each node's neighbor, each edge is a tuple
        graph = dict()
        for i in range(len(trim_arr)):
            graph[i] = set()
            for j in indexList[trim_arr[i]]:
                if j != i:
                    graph[i].add(j)
            if i - 1 >= 0:
                graph[i].add(i - 1)
            if i + 1 < len(trim_arr):
                graph[i].add(i + 1)

        # use a set to store all index visited, another set to store going to
        visited = {0}
        while True:
            # found answer
            if target in visited:
                break
            # get all next visit
            nextVisit = set()
            for i in visited:
                for j in graph[i]:
                    nextVisit.add(j)
                    if i in graph[j]:
                        graph[j].remove(i)
            visited.clear()
            visited = nextVisit
            res += 1
        return res


s = Solution()
arr = [80, -86, 40, 12, 40, -98, 12, -86, -79, -4, -79, 71, 44, -43, -9, -88, 88, -43, 31, 4, 71, -86, 55, -9, -65]
print(s.minJumps(arr))


# faster way
def minJumps2(self, arr: List[int]) -> int:
    neighbors = collections.defaultdict(set)
    for i, num in enumerate(arr):
        neighbors[num].add(i)

    visited, visiting = {-1}, {0}
    last = len(arr) - 1

    for steps in itertools.count():
        if last in visiting:
            return steps
        visited.update(visiting)
        next_ = set()
        for i in visiting:
            next_.add(i - 1)
            next_.add(i + 1)
            next_.update(neighbors.pop(arr[i], set()))

        visiting = next_ - visited
