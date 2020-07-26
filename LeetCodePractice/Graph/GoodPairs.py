"""
Number of Good Leaf Nodes Pairs

Given the root of a binary tree and an integer distance. A pair of two different leaf nodes of a binary tree is said to be good if the length of the shortest path between them is less than or equal to distance.

Return the number of good leaf node pairs in the tree.

Example 1:

Input: root = [1,2,3,null,4], distance = 3
Output: 1
Explanation: The leaf nodes of the tree are 3 and 4 and the length of the shortest path between them is 3. This is the only good pair.
Example 2:


Input: root = [1,2,3,4,5,6,7], distance = 3
Output: 2
Explanation: The good pairs are [4,5] and [6,7] with shortest path = 2. The pair [4,6] is not good because the length of ther shortest path between them is 4.
Example 3:

Input: root = [7,1,4,6,null,5,3,null,null,null,null,null,2], distance = 3
Output: 1
Explanation: The only good pair is [2,5].
Example 4:

Input: root = [100], distance = 1
Output: 0
Example 5:

Input: root = [1,1,1], distance = 2
Output: 1

Constraints:

The number of nodes in the tree is in the range [1, 2^10].
Each node's value is between [1, 100].
1 <= distance <= 10

Sol
Time O(n^2logn)
Space O(nlogn)
Worst case is when we have n/2 leaves, each leaf will compare to all other leaves, hence in order of n^2 comparison.
Each comparision take at most log(n) operation since we assume n/2 leaves, height is log(n)
And we are store path to each leaves, thus nlogn space is needed
Note, path can also be store using bits since all we need is 0 and 1.
"""
from DataStructure.Tree import TreeNode


class Solution:
    def countPairs(self, root: TreeNode, distance: int) -> int:
        leafPath = set()

        def getPath(node: TreeNode, path: str):
            if not node.left and not node.right:
                leafPath.add(path)
                return
            if node.left:
                getPath(node.left, path+'l')
            if node.right:
                getPath(node.right, path+'r')

        getPath(root, "")
        res = 0
        while leafPath:
            path = leafPath.pop()
            for path2 in leafPath:
                i = 0
                while path[i] == path2[i]:
                    i += 1
                if (len(path) - i) + (len(path2) - i) <= distance:
                    res += 1
        return res


