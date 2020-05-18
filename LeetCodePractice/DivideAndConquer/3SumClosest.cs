using System;

/*
 Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

Example:

Given array nums = [-1, 2, 1, -4], and target = 1.

The sum that is closest to the target is 2. (-1 + 2 + 1 = 2)

Sol 1:
Time O(n)
Space O(1)

1.Sort the array O(nlog(n))
2.Fix the first value and iterate all possible first value
3.Have two pointer low and high, compute a new sum with fixed value, low, high. 
    if new diff from new sum is < than original diff, accept the new diff.
    if new sum is > target, decrease the high pointer(so we have less sum). else increase the low pointer
 */
namespace LeetCodePractice.DivideAndConquer
{
    class _3SumClosest
    {
        static void Main()
        //static void Main16()
        {           
            int[] nums = new int[]{1, 2, 4, 8, 16, 32, 64, 128};
            int target = 82;
            Console.Out.WriteLine(ThreeSumClosest(nums, target));
            Console.In.ReadLine();
        }
        public static int ThreeSumClosest(int[] nums, int target)
        {
            int sum = int.MaxValue;
            int diff = int.MaxValue;
            Array.Sort(nums);
            for (int i=0; i < nums.Length-2; i++)
            {
                int lowIndex = i + 1, highIndex = nums.Length - 1;               
                while(lowIndex < highIndex)
                {
                    int low = nums[lowIndex], high = nums[highIndex];
                    int newSum = (low + high + nums[i]);
                    int newDiff = Math.Abs(target - newSum);

                    if (newSum == target)
                        return newSum;
                    if (diff > newDiff)
                    {                       
                        diff = newDiff;
                        sum = newSum;
                    }

                    if(newSum > target)
                    {
                        highIndex--;
                    }
                    else
                    {
                        lowIndex++;
                    }
                }
                    
            }
            return sum;
        }
    }
}
