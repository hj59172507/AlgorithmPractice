"""
1510. Stone Game IV

Alice and Bob take turns playing a game, with Alice starting first.

Initially, there are n stones in a pile.  On each player's turn, that player makes a move consisting of removing any non-zero square number of stones in the pile.

Also, if a player cannot make a move, he/she loses the game.

Given a positive integer n. Return True if and only if Alice wins the game otherwise return False, assuming both players play optimally.

Example 1:

Input: n = 1
Output: true
Explanation: Alice can remove 1 stone winning the game because Bob doesn't have any moves.
Example 2:

Input: n = 2
Output: false
Explanation: Alice can only remove 1 stone, after that Bob removes the last one winning the game (2 -> 1 -> 0).
Example 3:

Input: n = 4
Output: true
Explanation: n is already a perfect square, Alice can win with one move, removing 4 stones (4 -> 0).
Example 4:

Input: n = 7
Output: false
Explanation: Alice can't win the game if Bob plays optimally.
If Alice starts removing 4 stones, Bob will remove 1 stone then Alice should remove only 1 stone and finally Bob removes the last one (7 -> 3 -> 2 -> 1 -> 0).
If Alice starts removing 1 stone, Bob will remove 4 stones then Alice only can remove 1 stone and finally Bob removes the last one (7 -> 6 -> 2 -> 1 -> 0).
Example 5:

Input: n = 17
Output: false
Explanation: Alice can't win the game if Bob plays optimally.

Constraints:

1 <= n <= 10^5

Sol
Time O(n^1.5) n iteration, each iteration have up to square root n of checking
Space O(n)
Let res[i] be the result of game if Alice start with i number of stones
"""
import math


class Solution:
    def winnerSquareGame(self, n: int) -> bool:
        sq_num = [i*i for i in range(1, int(math.sqrt(n))+2)]
        res = [False]
        for i in range(1, n+1):
            if i in sq_num:
                res.append(True)
                continue
            sq_index = 0
            while i - sq_num[sq_index] >= 0:
                if not res[i -sq_num[sq_index]]:
                    res.append(True)
                    sq_index += 1
                    break
                sq_index += 1
            if len(res) < i + 1:
                res.append(False)
        return res[n]


s = Solution()
n = 7
print(s.winnerSquareGame(n))