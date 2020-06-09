using System;
/*
1372. Longest ZigZag Path in a Binary Tree

Given a binary tree root, a ZigZag path for a binary tree is defined as follow:

Choose any node in the binary tree and a direction (right or left).
If the current direction is right then move to the right child of the current node otherwise move to the left child.
Change the direction from right to left or right to left.
Repeat the second and third step until you can't move in the tree.
Zigzag length is defined as the number of nodes visited - 1. (A single node has a length of 0).

Return the longest ZigZag path contained in that tree.

Example 1:

Input: root = [1,null,1,1,1,null,null,1,1,null,1,null,null,null,1,null,1]
Output: 3
Explanation: Longest ZigZag path in blue nodes (right -> left -> right).
Example 2:

Input: root = [1,1,1,null,1,null,null,1,1,null,1]
Output: 4
Explanation: Longest ZigZag path in blue nodes (left -> right -> left -> right).
Example 3:

Input: root = [1]
Output: 0
 
Constraints:

Each tree has at most 50000 nodes..
Each node's value is between [1, 100].

Sol
Time O(n)
Space O(1)
DFS on each node, try following the direction, or start over with different direction
 */
namespace LeetCodePractice.DataStructure.Tree
{
    class LongestZigZagPath
    {
        //static void Main()
        static void Main1372()
        {
            TreeNode root = new TreeNode(4, new TreeNode(3, new TreeNode(1), new TreeNode(2)));
            Console.Out.WriteLine(LongestZigZag(root));
            Console.In.ReadLine();
        }
        public static int LongestZigZag(TreeNode root)
        {
            max = 0;
            DFS(root, true, 0);
            DFS(root, false, 0);
            return max;
        }

        static int max = 0;

        static void DFS(TreeNode root, bool right, int count)
        {           
            if (root == null) return;
            max = Math.Max(max, count);
            if (right)
            {
                DFS(root.right, false, count + 1);
                DFS(root.left, true, 1);
            }
            else
            {
                DFS(root.left, true, count + 1);
                DFS(root.right, false, 1);
            }
        }
    }
}
