using System;

/*
Invert left and right of a tree
Time O(n)
Space O(1)
*/
namespace LeetCodePractice.DataStructure.Tree
{
    class InvertBinaryTree
    {
        static void Main()
        //static void MainJuly1st2020()
        {
            TreeNode root = new TreeNode(4,
                                         new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                                         new TreeNode(7, new TreeNode(6), new TreeNode(9)));
            Console.Out.WriteLine(InvertTree(root));
            Console.In.ReadLine();
        }
        public static TreeNode InvertTree(TreeNode root)
        {
            InvertChild(root);
            return root;
        }
        
        public static void InvertChild(TreeNode root)
        {
            if (root == null)
                return;
            TreeNode temp = root.right;
            root.right = root.left;
            root.left = temp;
            InvertChild(root.right);
            InvertChild(root.left);
        }
    }
}
