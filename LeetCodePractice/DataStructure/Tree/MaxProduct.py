"""
1339. Maximum Product of Splitted Binary Tree

Given a binary tree root. Split the binary tree into two subtrees by removing 1 edge such that the product of the sums of the subtrees are maximized.

Since the answer may be too large, return it modulo 10^9 + 7.

Example 1:

Input: root = [1,2,3,4,5,6]
Output: 110
Explanation: Remove the red edge and get 2 binary trees with sum 11 and 10. Their product is 110 (11*10)
Example 2:

Input: root = [1,null,2,3,4,null,null,5,6]
Output: 90
Explanation:  Remove the red edge and get 2 binary trees with sum 15 and 6.Their product is 90 (15*6)
Example 3:

Input: root = [2,3,9,10,7,8,6,5,4,11,1]
Output: 1025
Example 4:

Input: root = [1,1]
Output: 1
Constraints:

Each tree has at most 50000 nodes and at least 2 nodes.
Each node's value is between [1, 10000].

Sol
Time O(n)
Space
Do a post order pass and get sum of the tree, while update tree value to be sum of itself and children
Do a second pass that find the max of product of two sub trees
"""
from DataStructure.Tree.TreeNode import TreeNode


class Solution:

    def maxProduct(self, root: TreeNode) -> int:
        self.res = total = 0

        def postOrder(root: TreeNode):
            if not root:
                return 0
            left, right = postOrder(root.left), postOrder(root.right)
            self.res = max(self.res, left * (total - left), right * (total - right))
            return root.val + left + right

        total = postOrder(root)
        postOrder(root)
        return self.res % (10 ** 9 + 7)


s = Solution()
root = TreeNode(1, None, TreeNode(2, TreeNode(3), TreeNode(4, TreeNode(5), TreeNode(6))))
print(s.maxProduct(root))
