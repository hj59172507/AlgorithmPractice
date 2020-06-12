"""
1349. Maximum Students Taking Exam

Given a m * n matrix seats  that represent seats distributions in a classroom. If a seat is broken, it is denoted by '#' character otherwise it is denoted by a '.' character.

Students can see the answers of those sitting next to the left, right, upper left and upper right, but he cannot see the answers of the student sitting directly in front or behind him. Return the maximum number of students that can take the exam together without any cheating being possible..

Students must be placed in seats in good condition.

Example 1:


Input: seats = [["#",".","#","#",".","#"],
                [".","#","#","#","#","."],
                ["#",".","#","#",".","#"]]
Output: 4
Explanation: Teacher can place 4 students in available seats so they don't cheat on the exam.
Example 2:

Input: seats = [[".","#"],
                ["#","#"],
                ["#","."],
                ["#","#"],
                [".","#"]]
Output: 3
Explanation: Place all students in available seats.

Example 3:

Input: seats = [["#",".",".",".","#"],
                [".","#",".","#","."],
                [".",".","#",".","."],
                [".","#",".","#","."],
                ["#",".",".",".","#"]]
Output: 10
Explanation: Place students in available seats in column 1, 3 and 5.

Constraints:

seats contains only characters '.' and'#'.
m == seats.length
n == seats[i].length
1 <= m <= 8
1 <= n <= 8

Sol
Time O
Space O

"""

from typing import List


class Solution:
    def maxStudents(self, seats: List[List[str]]) -> int:
        row, col = len(seats), len(seats[0])

        # dp[i][j] store the max student given first i row and seat bit mask j, -1 if j is invalid
        dp = [[-1 for x in range(1 << col)] for y in range(row + 1)]
        dp[0][0] = 0  # row with no student is valid

        # build a valid mask for row
        validList = []
        for i in range(row):
            mask = 0
            for j in range(col):
                mask = (mask << 1) + (seats[i][j] == '.')
            validList.append(mask)
        print(validList)
        # for each row
        for i in range(1, row+1):
            valid = validList[i-1]
            #  for each state in current row
            for j in range(1 << col):
                #  state is valid if not student sit in broken seat and no one is adjacent to another
                if ((j & valid) == j) and (j & (j >> 1) == 0):
                    # for each state in previous row
                    for k in range(1 << col):
                        # if previous state is valid, and have no student in left or right of student in current row
                        if dp[i-1][k] != -1 and ((k >> 1) & j == 0) and (k & (j >> 1) == 0):
                            dp[i][j] = max(dp[i][j], dp[i-1][k] + sum([int(i) for i in bin(j)[2:]]))
        return max([x for x in dp[row]])


seat = [["#", ".", ".", ".", "#"],
         [".", "#", ".", "#", "."],
         [".", ".", "#", ".", "."],
         [".", "#", ".", "#", "."],
         ["#", ".", ".", ".", "#"]]
s = Solution()
print(s.maxStudents(seat))
