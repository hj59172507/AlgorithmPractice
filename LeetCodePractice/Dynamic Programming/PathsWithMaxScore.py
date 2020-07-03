"""
1301. Number of Paths with Max Score

You are given a square board of characters. You can move on the board starting at the bottom right square marked with the character 'S'.

You need to reach the top left square marked with the character 'E'. The rest of the squares are labeled either with a numeric character 1, 2, ..., 9 or with an obstacle 'X'. In one move you can go up, left or up-left (diagonally) only if there is no obstacle there.

Return a list of two integers: the first integer is the maximum sum of numeric characters you can collect, and the second is the number of such paths that you can take to get that maximum sum, taken modulo 10^9 + 7.

In case there is no path, return [0, 0].

Example 1:

Input: board = ["E23","2X2","12S"]
Output: [7,1]
Example 2:

Input: board = ["E12","1X1","21S"]
Output: [4,2]
Example 3:

Input: board = ["E11","XXX","11S"]
Output: [0,0]

Constraints:

2 <= board.length == board[i].length <= 100

Sol
Time O(n^2)
Space O(n^2)
Let dp[i][j][0] be max score we can get at i, j
dp[i][j][0] = max(dp[i-1][j][0], dp[i-1][j-1][0], dp[i][j-1][0])
Let dp[i][j][1] be the number of ways
dp[i][j][1] = sum(dp[i-1][j][1], dp[i-1][j-1][1], dp[i][j-1][1])) if dp[i-1][j][0], dp[i-1][j-1][0], dp[i][j-1][0] is max among three
"""
from typing import List


class Solution:
    def pathsWithMaxScore(self, board: List[str]) -> List[int]:
        n = len(board)
        dp = [[[-10 ** 9, 0] for i in range(n + 1)] for j in range(n + 1)]

        # initialize starting position
        dp[n - 1][n - 1] = [0, 1]

        # start from bottom right
        for i in range(n - 1, -1, -1):
            for j in range(n - 1, -1, -1):
                if not board[i][j] in 'XS':
                    for x, y in [[0, 1], [1, 0], [1, 1]]:
                        # previous sum
                        pSum = dp[i + x][j + y][0]
                        if dp[i][j][0] < pSum:
                            dp[i][j] = [pSum, 0]
                        if dp[i][j][0] == pSum:
                            dp[i][j][1] += dp[i + x][j + y][1]
                    dp[i][j][0] += board[i][j] if x or y else 0

        return [dp[0][0][0] if dp[0][0][1] else 0, dp[0][0][1] % (10 ** 9 + 7)]
