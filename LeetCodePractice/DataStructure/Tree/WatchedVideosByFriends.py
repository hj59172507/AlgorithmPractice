"""
1311. Get Watched Videos by Your Friends

There are n people, each person has a unique id between 0 and n-1. Given the arrays watchedVideos and friends, where watchedVideos[i] and friends[i] contain the list of watched videos and the list of friends respectively for the person with id = i.

Level 1 of videos are all watched videos by your friends, level 2 of videos are all watched videos by the friends of your friends and so on. In general, the level k of videos are all watched videos by people with the shortest path exactly equal to k with you. Given your id and the level of videos, return the list of videos ordered by their frequencies (increasing). For videos with the same frequency order them alphabetically from least to greatest.

Example 1:

Input: watchedVideos = [["A","B"],["C"],["B","C"],["D"]], friends = [[1,2],[0,3],[0,3],[1,2]], id = 0, level = 1
Output: ["B","C"]
Explanation:
You have id = 0 (green color in the figure) and your friends are (yellow color in the figure):
Person with id = 1 -> watchedVideos = ["C"]
Person with id = 2 -> watchedVideos = ["B","C"]
The frequencies of watchedVideos by your friends are:
B -> 1
C -> 2
Example 2:

Input: watchedVideos = [["A","B"],["C"],["B","C"],["D"]], friends = [[1,2],[0,3],[0,3],[1,2]], id = 0, level = 2
Output: ["D"]
Explanation:
You have id = 0 (green color in the figure) and the only friend of your friends is the person with id = 3 (yellow color in the figure).

Constraints:

n == watchedVideos.length == friends.length
2 <= n <= 100
1 <= watchedVideos[i].length <= 100
1 <= watchedVideos[i][j].length <= 8
0 <= friends[i].length < n
0 <= friends[i][j] < n
0 <= id < n
1 <= level < n
if friends[i] contains j, then friends[j] contains i

Sol
Time O(n^2)
Space O(n)
Do a bfs until we reach final level, add all friend to a set so we don't repeat them.
When we reach final level, add friend at that level to a list, gather all movies, and sort them by frequency
"""
import collections
from typing import List


class Solution:
    def watchedVideosByFriends(self, watchedVideos: List[List[str]], friends: List[List[int]], id: int, level: int) -> List[str]:
        bfs, visited = {id}, {id}
        for _ in range(level):
            bfs = {j for i in bfs for j in friends[i] if j not in visited}
            visited |= bfs
        freq = collections.Counter([v for idx in bfs for v in watchedVideos[idx]])
        return sorted(freq.keys(), key=lambda x: (freq[x], x))


s = Solution()
watchedVideos = [["AA", "BA"], ["CA"], ["BA", "CA"], ["DA"]]
friends = [[1, 2], [0, 3], [0, 3], [1, 2]]
id = 0
level = 1
print(s.watchedVideosByFriends(watchedVideos, friends, id, level))
