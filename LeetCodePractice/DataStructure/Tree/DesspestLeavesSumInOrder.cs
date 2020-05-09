using LeetCodePractice.DataStructure.Tree;
using System;
using System.Collections.Generic;

namespace LeetCodePractice.DataStructure
{
    /*
    Given a binary tree, return the sum of values of its deepest leaves.

    Example 1:

    Input: root = [1,2,3,4,5,null,6,7,null,null,null,null,8]
    Output: 15
 
    Constraints:

    The number of nodes in the tree is between 1 and 10^4.
    The value of nodes is between 1 and 100.
     */
    class DeepestLeavesSumInOrder
    {
        //static void Main()
        static void Main1302()
        {
            TreeNode left = new TreeNode(2, new TreeNode(4, new TreeNode(7)), new TreeNode(5));
            TreeNode right = new TreeNode(3, null, new TreeNode(6, null, new TreeNode(8)));
            TreeNode root = new TreeNode(1, left, right);
            Console.Out.WriteLine(DeepestLeavesSum(root));
            Console.In.ReadLine();
        }
        
        public static int DeepestLeavesSum(TreeNode root)
        {
            List<int> levelSum = new List<int> {0};
            DLSHelper(root, levelSum, 0);
            int deepestLevel = levelSum[0];
            int sum = 0;
            for(int i=0; i<= levelSum.Count/2-1; i++)
            {
                int levelIndex = i * 2 + 1;
                if(levelSum[levelIndex] == deepestLevel)
                {
                    sum += levelSum[i*2+2];
                }
            }
            return sum;
        }

        public static void DLSHelper(TreeNode root, List<int> levelSum, int currentLevel)
        {
     
            if (root.left != null)
            {
                DLSHelper(root.left, levelSum, currentLevel + 1);
            }
            if(root.right != null)
            {
                DLSHelper(root.right, levelSum, currentLevel + 1);
            }
            if(currentLevel > levelSum[0])
            {
                levelSum[0] = currentLevel;
            }
            levelSum.Add(currentLevel);
            levelSum.Add(root.val);
        }
    }


}
