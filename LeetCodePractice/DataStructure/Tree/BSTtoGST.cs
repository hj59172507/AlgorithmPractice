using System;
using System.Collections.Generic;
using System.Linq;

/*
Given the root of a binary search tree with distinct values, modify it so that every node has a new value equal to the sum of the values of the original tree that are greater than or equal to node.val.

As a reminder, a binary search tree is a tree that satisfies these constraints:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:

Input: [4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]
Output: [30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]
 

Constraints:

The number of nodes in the tree is between 1 and 100.
Each node will have value between 0 and 100.
The given tree is a binary search tree.

Sol 1:
Time O(n)
Space O(1)

Use post order to visit the tree, sum up the value in order of right, itself, and left.
 */
namespace LeetCodePractice.DataStructure.Tree
{
    class BSTtoGST
    {
        //static void Main()
        static void Main1038()
        {
            TreeNode root = new TreeNode(4, 
                            new TreeNode(1, new TreeNode(0), new TreeNode(2, null, new TreeNode(3))),
                            new TreeNode(6, new TreeNode(5), new TreeNode(7, null, new TreeNode(8))));
            Console.Out.WriteLine(BstToGst(root).val);
            Console.In.ReadLine();
        }
        public static TreeNode BstToGst(TreeNode root)
        {
            postOrdSum(root, 0);
            return root;
        }

        public static int postOrdSum(TreeNode node, int sum)
        {            
            if(node.right != null)
            {
                sum = postOrdSum(node.right, sum);
            }
            
            node.val += sum;

            if(node.left != null)
            {                 
                return postOrdSum(node.left, node.val);                
            }

            return node.val;
        }
    }
}
