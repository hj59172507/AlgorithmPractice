"""
1335. Minimum Difficulty of a Job Schedule

You want to schedule a list of jobs in d days. Jobs are dependent (i.e To work on the i-th job, you have to finish all the jobs j where 0 <= j < i).

You have to finish at least one task every day. The difficulty of a job schedule is the sum of difficulties of each day of the d days. The difficulty of a day is the maximum difficulty of a job done in that day.

Given an array of integers jobDifficulty and an integer d. The difficulty of the i-th job is jobDifficulty[i].

Return the minimum difficulty of a job schedule. If you cannot find a schedule for the jobs return -1.

Example 1:

Input: jobDifficulty = [6,5,4,3,2,1], d = 2
Output: 7
Explanation: First day you can finish the first 5 jobs, total difficulty = 6.
Second day you can finish the last job, total difficulty = 1.
The difficulty of the schedule = 6 + 1 = 7
Example 2:

Input: jobDifficulty = [9,9,9], d = 4
Output: -1
Explanation: If you finish a job per day you will still have a free day. you cannot find a schedule for the given jobs.
Example 3:

Input: jobDifficulty = [1,1,1], d = 3
Output: 3
Explanation: The schedule is one job per day. total difficulty will be 3.
Example 4:

Input: jobDifficulty = [7,1,7,1,7,1], d = 3
Output: 15
Example 5:

Input: jobDifficulty = [11,111,22,222,33,333,44,444], d = 6
Output: 843

Constraints:

1 <= jobDifficulty.length <= 300
0 <= jobDifficulty[i] <= 1000
1 <= d <= 10

Sol
Time O (n^2d)
Space O(nd), space can be further optimized to O(n) since we only care about previous day
Let dp[i][j] represent min difficulty for first i job and j days
Compute a mat[n][m] that store the max from n to m in jobDifficulty
for d = 1, fill dp[1][j] = mat[1][j]
for d = 2 to n
    dp[i][d] = min(dp[x from 1 to i][d-1] + mat[i - x][i])
"""
from typing import List


class Solution:
    def minDifficulty(self, jobDifficulty: List[int], d: int) -> int:
        if len(jobDifficulty) < d:
            return -1
        n = len(jobDifficulty)
        dp, mat = [[10000 for i in range(d)] for j in range(n)], [[0 for i in range(n)] for j in range(n)]
        for i in range(n):
            for j in range(n):
                if i == j:
                    mat[i][j] = jobDifficulty[i]
                elif i < j:
                    mat[i][j] = max(mat[i][j - 1], jobDifficulty[j])
            dp[i][0] = mat[0][i]

        # for each i jobs
        for i in range(1, n):
            # for each j day
            for j in range(1, d):
                # for each j up to i jobs that previous day had done
                for k in range(j - 1, i):
                    dp[i][j] = min(dp[i][j], dp[k][j - 1] + mat[k+1][i])

        return dp[n - 1][d - 1]


s = Solution()
# jobD = [6, 5, 4, 3, 2, 1]
# d = 2
jobD = [11, 111, 22, 222, 33, 333, 44, 444]
d = 6
print(s.minDifficulty(jobD, d))
