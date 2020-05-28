using System;
using System.Collections.Generic;

/*
Given an integer array nums and an integer k, return the maximum sum of a non-empty subsequence of that array such that for every two consecutive integers in the subsequence, nums[i] and nums[j], where i < j, the condition j - i <= k is satisfied.

A subsequence of an array is obtained by deleting some number of elements (can be zero) from the array, leaving the remaining elements in their original order.

Example 1:

Input: nums = [10,2,-10,5,20], k = 2
Output: 37
Explanation: The subsequence is [10, 2, 5, 20].
Example 2:

Input: nums = [-1,-2,-3], k = 1
Output: -1
Explanation: The subsequence must be non-empty, so we choose the largest number.
Example 3:

Input: nums = [10,-2,-10,-5,20], k = 2
Output: 23
Explanation: The subsequence is [10, -2, -5, 20].
 

Constraints:

1 <= k <= nums.length <= 10^5
-10^4 <= nums[i] <= 10^4

Sol DP with decreasing deque
Time O(n) 
Space O(n/k)
Modify in place, so nums[i] = max sum using first i element
A decreaing deque will store the previous max maintain by 
Removing 
1.element more than k place apart 
2.element less than new max
Adding
1. new max if greater than zero
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class ConstrainedSubsequenceSum
    {
        //static void Main()
        static void Main1425()
        {
            int[] nums = new int[] { 10, 2, -10, 5, 20 };
            int k = 2;
            Console.Out.WriteLine(ConstrainedSubsetSum(nums, k));
            Console.In.ReadLine();
        }
        public static int ConstrainedSubsetSum(int[] nums, int k)
        {
            LinkedList<int> deque = new LinkedList<int>();
            int ans = nums[0];
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] += deque.Count > 0 ? deque.First.Value : 0;
                ans = Math.Max(ans, nums[i]);
                while (deque.Count > 0 && deque.Last.Value < nums[i]) deque.RemoveLast();
                if (nums[i] > 0) deque.AddLast(nums[i]);
                if (deque.Count > 0 && i >= k && deque.First.Value == nums[i - k]) deque.RemoveFirst();                    
            }
            return ans;
        }
    }
}
