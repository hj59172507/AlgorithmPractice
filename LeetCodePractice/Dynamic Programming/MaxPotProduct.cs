using System;
/*
Given two arrays nums1 and nums2.

Return the maximum dot product between non-empty subsequences of nums1 and nums2 with the same length.

A subsequence of a array is a new array which is formed from the original array by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, [2,3,5] is a subsequence of [1,2,3,4,5] while [1,5,3] is not).

Example 1:

Input: nums1 = [2,1,-2,5], nums2 = [3,0,-6]
Output: 18
Explanation: Take subsequence [2,-2] from nums1 and subsequence [3,-6] from nums2.
Their dot product is (2*3 + (-2)*(-6)) = 18.
Example 2:

Input: nums1 = [3,-2], nums2 = [2,-6,7]
Output: 21
Explanation: Take subsequence [3] from nums1 and subsequence [7] from nums2.
Their dot product is (3*7) = 21.
Example 3:

Input: nums1 = [-1,-1], nums2 = [1,1]
Output: -1
Explanation: Take subsequence [-1] from nums1 and subsequence [1] from nums2.
Their dot product is -1.
 
Constraints:

1 <= nums1.length, nums2.length <= 500
-1000 <= nums1[i], nums2[i] <= 1000

Sol DP
Time O(mn) n size of arr1 and m size of arr2
Space O(mn)

Let mat[i,j] be max dot product using 0 to i elements from arr1 and 0 to j elements from arr2
Then mat[i,j] = max{
                     arr[i]*arr[j], //This single product is greater than all previous
                     mat[i-1, j], //Don't use ith element from arr1
                     mat[i, j-1], //Don't use jth element from arr2
                     mat[i-1, j-1] + arr[i]*arr[j] /Use both i and j element from arr1 and arr2 respectively
                        }
According to definition of this function, mat[i-1,j], mat[i,j-1], mat[i-1,j-1] already include all possible combination with lower i, j values.
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class MaxPotProduct
    {
        static void Main()
        //static void Main1458()
        {
            int[] nums1 = new int[] { 1,1 }, nums2 = new int[] { -1,-1};
            Console.Out.WriteLine(MaxDotProduct(nums1, nums2));
            Console.In.ReadLine();
        }
        public static int MaxDotProduct(int[] nums1, int[] nums2)
        {
            const int smallNum = (int)-10e7;
            int n = nums1.Length, m = nums2.Length;
            int[,] mat = new int[n + 1, m + 1];
            for(int i = 0; i <= n; i++) { mat[i,0] = smallNum; }
            for(int j = 0; j <= m; j++) { mat[0, j] = smallNum; }

            for (int i = 1; i <= n; i++) 
            {
                for (int j = 1; j <= m; j++) 
                {
                    mat[i, j] = Math.Max(Math.Max(Math.Max(nums1[i - 1] * nums2[j - 1], mat[i - 1, j]), mat[i, j - 1]), mat[i - 1, j - 1] + nums1[i - 1] * nums2[j - 1]);
                }
            }
            return mat[n, m];
        }
    }
}
