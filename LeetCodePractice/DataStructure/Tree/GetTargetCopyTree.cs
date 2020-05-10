using System;

namespace LeetCodePractice.DataStructure.Tree
{
    /*
    Given two binary trees original and cloned and given a reference to a node target in the original tree.

    The cloned tree is a copy of the original tree.

    Return a reference to the same node in the cloned tree.

    Note that you are not allowed to change any of the two trees or the target node and the answer must be a reference to a node in the cloned tree.

    Follow up: Solve the problem if repeated values on the tree are allowed.(Find target using address for comparison rather than value)

    Example 1:

    Input: tree = [7,4,3,null,null,6,19], target = 3
    Output: 3
    Explanation: In all examples the original and cloned trees are shown. The target node is a green node from the original tree. The answer is the yellow node from the cloned tree.
     */
    class GetTargetCopyTree
    {
        //static void Main()
        static void Main1379()
        {
            TreeNode target = new TreeNode(3, new TreeNode(6), new TreeNode(19));
            TreeNode original = new TreeNode(7, new TreeNode(4), target);
            TreeNode target2 = new TreeNode(3, new TreeNode(6), new TreeNode(19));
            TreeNode cloned = new TreeNode(7, new TreeNode(4), target2);
            Console.Out.WriteLine(GetTargetCopy(original, cloned, target));
            Console.In.ReadLine();
        }
        public static TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            string path = FindNodePath(original, target, "");
            return FollowPath(cloned, path);
        }

        public static string FindNodePath(TreeNode tree, TreeNode target, string path)
        {
            if(tree == target)
            {
                return path;
            }
            if(tree.left != null)
            {
                string result = FindNodePath(tree.left, target, path+"L");
                if (result != null) {
                    return result;
                }                
            }
            if(tree.right != null)
            {
                string result = FindNodePath(tree.right, target, path+"R");
                if(result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public static TreeNode FollowPath(TreeNode tree, string path)
        {
            foreach(char c in path)
            {
                if (c == 'R')
                    tree = tree.right;
                else
                    tree = tree.left;
            }
            return tree;
        }
    }
}
