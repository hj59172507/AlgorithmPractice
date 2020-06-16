"""
1483. Kth Ancestor of a Tree Node

You are given a tree with n nodes numbered from 0 to n-1 in the form of a parent array where parent[i] is the parent of node i. The root of the tree is node 0.

Implement the function getKthAncestor(int node, int k) to return the k-th ancestor of the given node. If there is no such ancestor, return -1.

The k-th ancestor of a tree node is the k-th node in the path from that node to the root.

Example:

Input:
["TreeAncestor","getKthAncestor","getKthAncestor","getKthAncestor"]
[[7,[-1,0,0,1,1,2,2]],[3,1],[5,2],[6,3]]

Output:
[null,1,0,-1]

Explanation:
TreeAncestor treeAncestor = new TreeAncestor(7, [-1, 0, 0, 1, 1, 2, 2]);

treeAncestor.getKthAncestor(3, 1);  // returns 1 which is the parent of 3
treeAncestor.getKthAncestor(5, 2);  // returns 0 which is the grandparent of 5
treeAncestor.getKthAncestor(6, 3);  // returns -1 because there is no such ancestor

Constraints:

1 <= k <= n <= 5*10^4
parent[0] == -1 indicating that 0 is the root node.
0 <= parent[i] < n for all 0 < i < n
0 <= node < n
There will be at most 5*10^4 queries.

Sol
Time O(nlog(n)) to build dp, log(n) for each query
Space O(nlog(n))
Let dp[i][j] be the 2^j parent of node i
dp[i][j] = dp[i][j-1][j-1]

"""
import math
from typing import List


class TreeAncestor:

    def __init__(self, n: int, parent: List[int]):
        height = int(math.log2(n)) + 1
        self.dp = [[-1 for i in range(height)] for j in range(n)]
        for j in range(height):
            for i in range(n):
                if j == 0:
                    self.dp[i][j] = parent[i]
                elif self.dp[i][j-1] != -1:
                    self.dp[i][j] = self.dp[self.dp[i][j-1]][j-1]

    def getKthAncestor(self, node: int, k: int) -> int:
        while k > 0 and node != -1:
            j = int(math.log2(k))
            node = self.dp[node][j]
            k -= (1 << j)
        return node
