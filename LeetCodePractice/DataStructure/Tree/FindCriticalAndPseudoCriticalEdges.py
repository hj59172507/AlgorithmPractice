"""
1489. Find Critical and Pseudo-Critical Edges in Minimum Spanning Tree

Given a weighted undirected connected graph with n vertices numbered from 0 to n-1, and an array edges where edges[i] = [fromi, toi, weighti] represents a bidirectional and weighted edge between nodes fromi and toi. A minimum spanning tree (MST) is a subset of the edges of the graph that connects all vertices without cycles and with the minimum possible total edge weight.

Find all the critical and pseudo-critical edges in the minimum spanning tree (MST) of the given graph. An MST edge whose deletion from the graph would cause the MST weight to increase is called a critical edge. A pseudo-critical edge, on the other hand, is that which can appear in some MSTs but not all.

Note that you can return the indices of the edges in any order.

Example 1:

Input: n = 5, edges = [[0,1,1],[1,2,1],[2,3,2],[0,3,2],[0,4,3],[3,4,3],[1,4,6]]
Output: [[0,1],[2,3,4,5]]
Explanation: The figure above describes the graph.
The following figure shows all the possible MSTs:

Notice that the two edges 0 and 1 appear in all MSTs, therefore they are critical edges, so we return them in the first list of the output.
The edges 2, 3, 4, and 5 are only part of some MSTs, therefore they are considered pseudo-critical edges. We add them to the second list of the output.
Example 2:

Input: n = 4, edges = [[0,1,1],[1,2,1],[2,3,1],[0,3,1]]
Output: [[],[0,1,2,3]]
Explanation: We can observe that since all 4 edges have equal weight, choosing any 3 edges from the given 4 will yield an MST. Therefore all 4 edges are pseudo-critical.

Constraints:

2 <= n <= 100
1 <= edges.length <= min(200, n * (n - 1) / 2)
edges[i].length == 3
0 <= fromi < toi < n
1 <= weighti <= 1000
All pairs (fromi, toi) are distinct.

Sol
Time O(nlogn)
Space O(n)
Use Kruskal algorithm: https://en.wikipedia.org/wiki/Kruskal%27s_algorithm
Or Prim's algorithm: https://en.wikipedia.org/wiki/Prim%27s_algorithm
"""
from heapq import heappush, heappop
from math import inf
from typing import List


class Solution:
    def findCriticalAndPseudoCriticalEdges(self, n: int, edges: List[List[int]]) -> List[List[int]]:
        graph = dict()
        for u, v, w in edges:
            graph.setdefault(u, []).append((v, w))
            graph.setdefault(v, []).append((u, w))

        ref = self.mst(n, graph)
        critical, pseudo = [], []
        for i in range(len(edges)):
            if self.mst(n, graph, exclude=edges[i][:2]) > ref:
                critical.append(i)
            elif self.mst(n, graph, init=edges[i]) == ref:
                pseudo.append(i)
        return [critical, pseudo]

    def mst(self, n, graph, init=None, exclude=None):
        """Return weight of MST of given graph using Prim's algo"""

        def visit(u):
            """Mark node and put its edges to priority queue"""
            marked[u] = True
            for v, w in graph.get(u, []):
                if exclude and u in exclude and v in exclude: continue
                if not marked[v]: heappush(pq, (w, u, v))

        ans = 0
        marked = [False] * n
        pq = []  # min prioirty queue

        if init:
            u, v, w = init
            ans += w
            marked[u] = marked[v] = True
            visit(u) or visit(v)
        else:
            visit(0)

        while pq:
            w, u, v = heappop(pq)
            if marked[u] and marked[v]: continue
            ans += w
            if not marked[u]: visit(u)
            if not marked[v]: visit(v)

        return ans if all(marked) else inf