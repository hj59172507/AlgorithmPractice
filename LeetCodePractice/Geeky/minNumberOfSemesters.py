"""
1494. Parallel Courses II

Given the integer n representing the number of courses at some university labeled from 1 to n, and the array dependencies where dependencies[i] = [xi, yi]  represents a prerequisite relationship, that is, the course xi must be taken before the course yi.  Also, you are given the integer k.

In one semester you can take at most k courses as long as you have taken all the prerequisites for the courses you are taking.

Return the minimum number of semesters to take all courses. It is guaranteed that you can take all courses in some way.

Example 1:

Input: n = 4, dependencies = [[2,1],[3,1],[1,4]], k = 2
Output: 3
Explanation: The figure above represents the given graph. In this case we can take courses 2 and 3 in the first semester, then take course 1 in the second semester and finally take course 4 in the third semester.
Example 2:

Input: n = 5, dependencies = [[2,1],[3,1],[4,1],[1,5]], k = 2
Output: 4
Explanation: The figure above represents the given graph. In this case one optimal way to take all courses is: take courses 2 and 3 in the first semester and take course 4 in the second semester, then take course 1 in the third semester and finally take course 5 in the fourth semester.
Example 3:

Input: n = 11, dependencies = [], k = 2
Output: 6

Constraints:

1 <= n <= 15
1 <= k <= n
0 <= dependencies.length <= n * (n-1) / 2
dependencies[i].length == 2
1 <= xi, yi <= n
xi != yi
All prerequisite relationships are distinct, that is, dependencies[i] != dependencies[j].
The given graph is a directed acyclic graph.

Sol
Time O(n^2*2^n)
Space O(n*2^n)
npc problem, similar to traveling salesman problem
"""
from itertools import permutations
from typing import List


class Solution:
    def minNumberOfSemesters(self, n: int, dependencies: List[List[int]], k: int) -> int:
        dp = [[(0, 100)] * n for _ in range(1 << n)]

        bm_dep = [0] * n
        for i, j in dependencies:
            bm_dep[j - 1] ^= (1 << (i - 1))

        for i in range(n):
            if bm_dep[i] == 0: dp[1 << i][i] = (1 << i, 1)

        for i in range(1 << n):
            n_z_bits = [len(bin(i)) - p - 1 for p, c in enumerate(bin(i)) if c == "1"]

            for t, j in permutations(n_z_bits, 2):
                if bm_dep[j] & i == bm_dep[j]:
                    mask, cand = dp[i ^ (1 << j)][t]
                    if bm_dep[j] & mask == 0 and bin(mask).count('1') < k:
                        if dp[i][j][1] > cand:
                            dp[i][j] = mask + (1 << j), cand
                    else:
                        if dp[i][j][1] > cand + 1:
                            dp[i][j] = 1 << j, cand + 1

        return min([j for i, j in dp[-1]])


s = Solution()
n = 8
dependencies = [[1, 6], [2, 7], [8, 7], [2, 5], [3, 4]]
k = 3
print(s.minNumberOfSemesters(n, dependencies, k))
