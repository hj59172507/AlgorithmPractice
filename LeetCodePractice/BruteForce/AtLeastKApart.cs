using System;

/*
Given an array nums of 0s and 1s and an integer k, return True if all 1's are at least k places away from each other, otherwise return False.

Example 1:

Input: nums = [1,0,0,0,1,0,0,1], k = 2
Output: true
Explanation: Each of the 1s are at least 2 places away from each other.
Example 2:

Input: nums = [1,0,0,1,0,1], k = 2
Output: false
Explanation: The second 1 and third 1 are only one apart from each other.
Example 3:

Input: nums = [1,1,1,1,1], k = 0
Output: true
Example 4:

Input: nums = [0,1,0,1], k = 1
Output: true
 

Constraints:

1 <= nums.length <= 10^5
0 <= k <= nums.length
nums[i] is 0 or 1

Sol Brute force:
Time O(n)
Space O(1)
Simple loop the array and keep count of number of zero between 1's, if less than k, return false. 
If reach end of loop, return true
 */
namespace LeetCodePractice.BruteForce
{
    class AtLeastKApart
    {
        //static void Main()
        static void Main1437()
        {
            int[] nums = new int[] { 1, 0, 0, 1, 0, 1 };
            int k = 2;
            Console.Out.WriteLine(KLengthApart(nums, k));
            Console.In.ReadLine();
        }
        public static bool KLengthApart(int[] nums, int k)
        {
            int index = Array.IndexOf(nums, 1);
            int temp = 0;
            for(int i = index+1;i<nums.Length;i++)
            {
                if(nums[i] != 1)
                {
                    temp++;
                }
                else
                {
                    if (temp < k)
                        return false;
                    temp = 0;
                }
            }
            return true;
        }
    }
}
