using System;

/*
Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
Return the number of good nodes in the binary tree.

Example 1:

Input: root = [3,1,4,3,null,1,5]
Output: 4
Explanation: Nodes in blue are good.
Root Node (3) is always a good node.
Node 4 -> (3,4) is the maximum value in the path starting from the root.
Node 5 -> (3,4,5) is the maximum value in the path
Node 3 -> (3,1,3) is the maximum value in the path.

Example 2:

Input: root = [3,3,null,4,2]
Output: 3
Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than it.
Example 3:

Input: root = [1]
Output: 1
Explanation: Root is considered as good.
 

Constraints:

The number of nodes in the binary tree is in the range [1, 10^5].
Each node's value is between [-10^4, 10^4].

Sol Preorder traversal:
Time O(n)
Space O(1)

Use preorder traversal to visit root, then child, passing along the max value in the path
 */
namespace LeetCodePractice.DataStructure.Tree
{
    class CountMaxNode
    {
        //static void Main()
        static void Main1448()
        {
            TreeNode root = new TreeNode(3, new TreeNode(1, new TreeNode(3)), new TreeNode(4, new TreeNode(1), new TreeNode(5)));
            Console.Out.WriteLine(GoodNodes(root));
            Console.In.ReadLine();
        }
        public static int GoodNodes(TreeNode root)
        {
            int ans = 1;
            GoodNodeHelper(root, root.val, ref ans);
            return ans;
        }

        public static void GoodNodeHelper(TreeNode root, int max, ref int ans)
        {
            if(root.right != null)
            {
                if(root.right.val >= max)
                {
                    ans++;
                    GoodNodeHelper(root.right, root.right.val, ref ans);
                }
                else
                {
                    GoodNodeHelper(root.right, max, ref ans);
                }
            }
            if (root.left != null)
            {
                if (root.left.val >= max)
                {
                    ans++;
                    GoodNodeHelper(root.left, root.left.val, ref ans);
                }
                else
                {
                    GoodNodeHelper(root.left, max, ref ans);
                }
            }
        }
    }
}
