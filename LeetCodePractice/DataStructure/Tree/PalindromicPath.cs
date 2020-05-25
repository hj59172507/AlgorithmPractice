using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given a binary tree where node values are digits from 1 to 9. A path in the binary tree is said to be pseudo-palindromic if at least one permutation of the node values in the path is a palindrome.

Return the number of pseudo-palindromic paths going from the root node to leaf nodes.

Example 1:

Input: root = [2,3,1,3,1,null,1]
Output: 2 
Explanation: The figure above represents the given binary tree. There are three paths going from the root node to leaf nodes: the red path [2,3,3], the green path [2,1,1], and the path [2,3,1]. Among these paths only red path and green path are pseudo-palindromic paths since the red path [2,3,3] can be rearranged in [3,2,3] (palindrome) and the green path [2,1,1] can be rearranged in [1,2,1] (palindrome).
Example 2:

Input: root = [2,1,1,1,3,null,null,null,null,null,1]
Output: 1 
Explanation: The figure above represents the given binary tree. There are three paths going from the root node to leaf nodes: the green path [2,1,1], the path [2,1,3,1], and the path [2,1]. Among these paths only the green path is pseudo-palindromic since [2,1,1] can be rearranged in [1,2,1] (palindrome).
Example 3:

Input: root = [9]
Output: 1
 
Constraints:

The given binary tree will have between 1 and 10^5 nodes.
Node values are digits from 1 to 9.

Sol
Time O(n) 
Space O(n)
Since Palindromic string must have at most 1 odd number of digit, we will visit all path to a leave and keep a count of odd number of digit.
If there is less than 2, then there exist some permutation so that vals along this path can form a palindromic string.

 */
namespace LeetCodePractice.DataStructure.Tree
{
    class PalindromicPath
    {
        //static void Main()
        static void Main1457()
        {
            TreeNode root = new TreeNode(2,
                                        new TreeNode(1, new TreeNode(1), new TreeNode(3, null, new TreeNode(1))),
                                        new TreeNode(1));
            Console.Out.WriteLine(PseudoPalindromicPaths(root));
            Console.In.ReadLine();
        }        
        public static int PseudoPalindromicPaths(TreeNode root)
        {            
            int count = 0;
            PseudoPalindromicPathsHelper(root, "", ref count);            
            return count;
        }
        public static void PseudoPalindromicPathsHelper(TreeNode root, string s, ref int count)
        {
            string val = root.val.ToString();
            int index = s.IndexOf(val);
            if (index == -1)
            {
                s += val;
            }
            else
            {
                s = s.Remove(index, 1);
            }

            if (root.right == null && root.left == null)
            {
                if (s.Length <= 1)
                    count++;
                return;
            }

            if(root.right != null)
                PseudoPalindromicPathsHelper(root.right, s, ref count);
            if(root.left != null)
                PseudoPalindromicPathsHelper(root.left, s, ref count);
        }
    }
}
