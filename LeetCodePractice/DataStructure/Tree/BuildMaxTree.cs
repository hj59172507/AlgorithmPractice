using System;

/*
Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

The root is the maximum number in the array.
The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
Construct the maximum tree by the given array and output the root node of this tree.

Example 1:
Input: [3,2,1,6,0,5]
Output: return the tree root node representing the following tree:

      6
    /   \
   3     5
    \    / 
     2  0   
       \
        1
Note:
The size of the given array will be in the range [1,1000].

Sol 1 Brute Force:
Space O(n)
Time O(n^2)
Find max on original array, and recursive build right and left tree. 
 */
namespace LeetCodePractice.DataStructure.Tree
{
    class BuildMaxTree
    {
        static void Main()
        //static void Main654()
        {
            int[] arr = new int[] { 3,2,1,6,0,5};
            Console.Out.WriteLine(ConstructMaximumBinaryTree(arr));
            Console.In.ReadLine();
        } 
        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            int maxIndex = MaxIndex(nums, 0, nums.Length-1);
            TreeNode root = new TreeNode(nums[maxIndex]);
            BuildTree(root, nums, 0, maxIndex-1, true);
            BuildTree(root, nums, maxIndex + 1, nums.Length - 1, false);
            return root;
        }

        public static void BuildTree(TreeNode root, int[] nums, int start, int end, bool buildLeft)
        {
            if (start > end)
                return;
            int maxIndex = MaxIndex(nums, start, end);
            if (buildLeft)
            {
                root.left = new TreeNode(nums[maxIndex]);
                root = root.left;
            }
            else
            {
                root.right = new TreeNode(nums[maxIndex]);
                root = root.right;
            }
            BuildTree(root, nums, start, maxIndex - 1, true);
            BuildTree(root, nums, maxIndex+1, end, false);

        }

        public static int MaxIndex(int[] arr, int start, int end)
        {
            int index = 0;
            int max = int.MinValue;
            for (int i = start; i <= end; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
