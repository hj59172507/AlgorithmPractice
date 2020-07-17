"""
1293. Shortest Path in a Grid with Obstacles Elimination

Given a m * n grid, where each cell is either 0 (empty) or 1 (obstacle). In one step, you can move up, down, left or right from and to an empty cell.

Return the minimum number of steps to walk from the upper left corner (0, 0) to the lower right corner (m-1, n-1) given that you can eliminate at most k obstacles. If it is not possible to find such walk return -1.

Example 1:

Input:
grid =
[[0,0,0],
 [1,1,0],
 [0,0,0],
 [0,1,1],
 [0,0,0]],
k = 1
Output: 6
Explanation:
The shortest path without eliminating any obstacle is 10.
The shortest path with one obstacle elimination at position (3,2) is 6. Such path is (0,0) -> (0,1) -> (0,2) -> (1,2) -> (2,2) -> (3,2) -> (4,2).

Example 2:

Input:
grid =
[[0,1,1],
 [1,1,1],
 [1,0,0]],
k = 1
Output: -1
Explanation:
We need to eliminate at least two obstacles to find such a walk.

Constraints:

grid.length == m
grid[0].length == n
1 <= m, n <= 40
1 <= k <= m*n
grid[i][j] == 0 or 1
grid[0][0] == grid[m-1][n-1] == 0

Sol
Time (r*c*k)
Space (r*c*k)
Let seem store all visited combination of position i, j, and k
Use bfs to explore path on each iteration and first time reaching bottom right grid is the answer

Sol2
Time ((r*c-k^2)*k*log((r*c-k^2)*k))
Space ((r*c-k^2)*k)
Let seem store all visited combination of position i, j, and k
Use bfs to explore path on each iteration and first time reaching bottom right grid is the answer
We also store the steps left, and if k > steps left, we can return directly.
When k^2 > rc, this is faster and use less memory
"""
import heapq
from typing import List


class Solution:
    def shortestPath(self, grid: List[List[int]], k: int) -> int:
        r, c = len(grid), len(grid[0])
        moves = [[1, 0], [-1, 0], [0, 1], [0, -1]]
        # 0 = row, 1 = col, 2 = k left, 3 = steps
        start = (r-1, c-1, k)
        states = [(start, 0)]
        seen = {start}
        for (i, j, K), steps in states:
            if i == j == 0:
                return steps
            # process this step
            for m in moves:
                nr, nc = i + m[0], j + m[1]
                # check bound
                if 0 <= nr < r and 0 <= nc < c:
                    # obstacle
                    state = (nr, nc, K - grid[nr][nc])
                    if state[2] >= 0 and state not in seen:
                        states.append((state, steps + 1))
                        seen.add(state)
        return -1

class Solution2:
    def shortestPath(self, grid: List[List[int]], k: int) -> int:
        m, n = len(grid), len(grid[0])
        start = m-1, n-1, k
        queue = [(-1, 0, start)]
        seen = {start}
        while queue:
            priority, steps, (i, j, k) = heapq.heappop(queue)
            if k >= i + j - 1:
                return steps + i + j
            for i, j in (i+1, j), (i-1, j), (i, j+1), (i, j-1):
                if m > i >= 0 <= j < n:
                    state = i, j, k - grid[i][j]
                    if state not in seen and state[2] >= 0:
                        heapq.heappush(queue, (i + j + steps, steps + 1, state))
                        seen.add(state)
        return -1


S = Solution()
arr = [[0, 0], [1, 0], [1, 0], [1, 0], [1, 0], [1, 0], [0, 0], [0, 1], [0, 1], [0, 1], [0, 0], [1, 0], [1, 0], [0, 0]]
k = 4
print(S.shortestPath(arr, k))
