using System;

namespace LeetCodePractice.DataStructure.Tree
{
    class SumOfEvenGrandParent
    {
        //static void Main()
        static void Main1315()
        {
            TreeNode root = new TreeNode(6, 
                            new TreeNode(7, new TreeNode(2, new TreeNode(9)),  new TreeNode(7, new TreeNode(1), new TreeNode(4))), 
                            new TreeNode(8, new TreeNode(1), new TreeNode(3, null, new TreeNode(5))));
            Console.Out.WriteLine(SumEvenGrandparent(root));
            Console.In.ReadLine();
        }
        public static int SumEvenGrandparent(TreeNode root)
        {
            return SumHelper(root, 0);
        }

        public static int SumHelper(TreeNode root, int sum)
        {
            if(root.val % 2 == 0)
            {
                if (root.right != null && root.right.right != null)
                {
                    sum += root.right.right.val;
                }
                if (root.right != null && root.right.left != null)
                {
                    sum += root.right.left.val;
                }
                if (root.left != null && root.left.left != null)
                {
                    sum += root.left.left.val;
                }
                if (root.left != null && root.left.right != null)
                {
                    sum += root.left.right.val;
                }
            }
            if(root.left != null)
            {
                sum += SumHelper(root.left, 0);
            }
            if (root.right != null)
            {
                sum += SumHelper(root.right, 0);
            }
            return sum;
        }
    }
}
