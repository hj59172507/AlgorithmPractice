using System;
using System.Collections.Generic;
/*
Given an array of integers nums and an integer limit, return the size of the longest continuous subarray such that the absolute difference between any two elements is less than or equal to limit.

In case there is no subarray satisfying the given condition return 0.

Example 1:

Input: nums = [8,2,4,7], limit = 4
Output: 2 
Explanation: All subarrays are: 
[8] with maximum absolute diff |8-8| = 0 <= 4.
[8,2] with maximum absolute diff |8-2| = 6 > 4. 
[8,2,4] with maximum absolute diff |8-2| = 6 > 4.
[8,2,4,7] with maximum absolute diff |8-2| = 6 > 4.
[2] with maximum absolute diff |2-2| = 0 <= 4.
[2,4] with maximum absolute diff |2-4| = 2 <= 4.
[2,4,7] with maximum absolute diff |2-7| = 5 > 4.
[4] with maximum absolute diff |4-4| = 0 <= 4.
[4,7] with maximum absolute diff |4-7| = 3 <= 4.
[7] with maximum absolute diff |7-7| = 0 <= 4. 
Therefore, the size of the longest subarray is 2.
Example 2:

Input: nums = [10,1,2,4,7,2], limit = 5
Output: 4 
Explanation: The subarray [2,4,7,2] is the longest since the maximum absolute diff is |2-7| = 5 <= 5.
Example 3:

Input: nums = [4,2,2,2,4,4,2,2], limit = 0
Output: 3

Constraints:

1 <= nums.length <= 10^5
1 <= nums[i] <= 10^9
0 <= limit <= 10^9

Sol Deque:
Time O(n)
Space O(n)
Maintain a max as decreasing and min deque as increasing
For each new value, pop the max tail until not less than new value and pop the min tial until not greater than new value.
If updated max - min > limit, then pop all value = num[left pointer]
And we update ans to be max of ans and new value index - left pointer + 1
*/
namespace LeetCodePractice.DataStructure.Sorted
{
    class LongestSubArrWithLimit
    {
        //static void Main()
        static void Main1438()
        {           
            int[] nums = new int[] { 4, 8, 5, 1, 7, 9 };
            int limit = 6;
            Console.Out.WriteLine(LongestSubarray(nums, limit));
            Console.In.ReadLine();
        }
        //public static int LongestSubarray(int[] nums, int limit)
        //{
        //    if (nums.Length == 1)
        //        return 1;
        //    int ans = 0, temp = 0, max = nums[0], min = max;

        //    for (int i = 1; i < nums.Length; i++)
        //    {
        //        int n = nums[i];

        //        if (Math.Abs(max - n) > limit || Math.Abs(min - n) > limit)
        //        {
        //            ans = Math.Max(ans, temp);
        //            int j = i - 1;
        //            while (true)
        //            {
        //                if (Math.Abs(nums[j] - n) > limit || Math.Abs(nums[j] - n) > limit)
        //                {
        //                    //found closest violation
        //                    j++;
        //                    temp = i - j;
        //                    max = min = nums[j];
        //                    for (; j <= i; j++)
        //                    {
        //                        if (nums[j] > max) max = nums[j];
        //                        if (nums[j] < min) min = nums[j];
        //                    }
        //                    break;
        //                }
        //                j--;
        //            }
        //        }
        //        else
        //        {
        //            temp++;
        //            if (nums[i] > max) max = nums[i];
        //            if (nums[i] < min) min = nums[i];
        //        }
        //    }
        //    ans = Math.Max(ans, temp);
        //    return ans == 0 ? 0 : ans + 1;
        //}
        
        public static int LongestSubarray(int[] nums, int limit)
        {
            int ans = 1, left = 0;
            LinkedList<int> max = new LinkedList<int>();
            LinkedList<int> min = new LinkedList<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int n = nums[i];
                while (max.Count != 0 && max.Last.Value < n)
                {
                    max.RemoveLast();
                }
                max.AddLast(n);
                while (min.Count != 0 && min.Last.Value > n)
                {
                    min.RemoveLast();
                }
                min.AddLast(n);
                while (max.First.Value - min.First.Value > limit)
                {
                    if (max.First.Value == nums[left]) max.RemoveFirst();
                    if (min.First.Value == nums[left]) min.RemoveFirst();
                    left++;
                }
                ans = Math.Max(ans, i - left + 1);
            }

            return ans;
        }
    }
}
