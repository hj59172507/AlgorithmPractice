"""
1305. All Elements in Two Binary Search Trees

Given two binary search trees root1 and root2.

Return a list containing all the integers from both trees sorted in ascending order.

Example 1:

Input: root1 = [2,1,4], root2 = [1,0,3]
Output: [0,1,1,2,3,4]
Example 2:

Input: root1 = [0,-10,10], root2 = [5,1,7,0,2]
Output: [-10,0,0,1,2,5,7,10]
Example 3:

Input: root1 = [], root2 = [5,1,7,0,2]
Output: [0,1,2,5,7]
Example 4:

Input: root1 = [0,-10,10], root2 = []
Output: [-10,0,10]
Example 5:


Input: root1 = [1,null,8], root2 = [8,1]
Output: [1,1,8,8]

Constraints:

Each tree has at most 5000 nodes.
Each node's value is between [-10^5, 10^5].

Sol
Time O(n)
Space O(n)
Since both trees are bst, we can do inorder traversal which construct sorted array in O(n), and another O(n) to merge them
"""
from typing import List

from DataStructure.Tree import TreeNode


class Solution:
    def getAllElements(self, root1: TreeNode, root2: TreeNode) -> List[int]:
        res, left, right = [], [], []
        self.inOrder(root1, left)
        self.inOrder(root2, right)
        l = r = 0
        ls = len(left)
        rs = len(right)
        while True:
            if l == ls:
                res.extend(right[r:])
                break
            if r == rs:
                res.extend(left[l:])
                break
            if left[l] <= right[r]:
                res.append(left[l])
                l += 1
            else:
                res.append(right[r])
                r += 1
        return res

    def inOrder(self, root: TreeNode, res: List[int]):
        if root:
            self.inOrder(root.left, res)
            res.append(root.val)
            self.inOrder(root.right, res)

    # but wait, python use Timsort: https://en.wikipedia.org/wiki/Timsort
    # which search for already sorted sub list in array and simply merge them so follow also works and run time is O(n) even we sort it
    # res = []
    # self.inOrder(root1, res)
    # self.inOrder(root2, res)
    # res.sort()
    # return res
