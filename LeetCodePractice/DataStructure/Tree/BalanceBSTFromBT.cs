using System;
using System.Collections.Generic;
/*
1382. Balance a Binary Search Tree

Given a binary search tree, return a balanced binary search tree with the same node values.

A binary search tree is balanced if and only if the depth of the two subtrees of every node never differ by more than 1.

If there is more than one answer, return any of them.

Example 1:

Input: root = [1,null,2,null,3,null,4,null,null]
Output: [2,1,3,null,null,null,4]
Explanation: This is not the only correct answer, [3,1,4,null,2,null,null] is also correct.
 
Constraints:

The number of nodes in the tree is between 1 and 10^4.
The tree nodes will have distinct values between 1 and 10^5.

Sol
Time O(n)
Space O(1)
Get a sorted list of Node from original tree.
Then build a balance BST from the list by located the mid value recursively.
 */
namespace LeetCodePractice.DataStructure.Tree
{
    class BalanceBSTFromBT
    {
        //static void Main()
        static void Main1382()
        {
            TreeNode root = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4))));
            Console.Out.WriteLine(BalanceBST(root));
            Console.In.ReadLine();
        }
        public static TreeNode BalanceBST(TreeNode root)
        {
            List<TreeNode> sortedNodes = new List<TreeNode>();
            GetNodesSorted(root, sortedNodes);
            //convert sortedNodes into balanced tree
            int mid = sortedNodes.Count / 2;
            BuildTree(mid, 0, mid - 1, sortedNodes);
            BuildTree(mid, mid + 1, sortedNodes.Count - 1, sortedNodes);
            return sortedNodes[mid];
        }

        public static void BuildTree(int parentIndex, int start, int end, List<TreeNode> sortedNodes)
        {
            if (start > end) 
            {
                sortedNodes[parentIndex].left = null;
                sortedNodes[parentIndex].right= null;
                return; 
            }
            int mid = (start + end) / 2;
            if (mid < parentIndex)
            {
                sortedNodes[parentIndex].left = sortedNodes[mid];
                BuildTree(mid, start, mid - 1, sortedNodes);
                BuildTree(mid, mid + 1, end, sortedNodes);
            }
            else
            {
                sortedNodes[parentIndex].right = sortedNodes[mid];
                BuildTree(mid, start, mid - 1, sortedNodes);
                BuildTree(mid, mid + 1, end, sortedNodes);
            }            
        }

        //in-order traversal
        static void GetNodesSorted(TreeNode node, List<TreeNode> res)
        {
            if (node == null) return;
            GetNodesSorted(node.left, res);
            res.Add(node);
            GetNodesSorted(node.right, res);
        }
    }
}
