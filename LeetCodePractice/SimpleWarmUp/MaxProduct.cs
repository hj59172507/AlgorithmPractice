using System;

namespace LeetCodePractice.SimpleWarmUp
{
    class MaxProduct
    {
        static void Main()
        //static void Main1464()
        {
            int[] nums = {3, 4, 5, 2};
            Console.Out.WriteLine(MaxProduct1(nums));
            Console.In.ReadLine();
        }
        public static int MaxProduct1(int[] nums)
        {
            int max = 0, secondMax = 0;
            if (nums[0] > nums[1])
            { 
                max = nums[0];
                secondMax = nums[1];
            }
            else
            {
                max = nums[1];
                secondMax = nums[0];
            }
              
            for(int i=2;i<nums.Length;i++)
            {
                if (nums[i] > max)
                {
                    secondMax = max;
                    max = nums[i];                   
                }else if(nums[i] == max)
                {
                    secondMax = max;
                }else if(nums[i] > secondMax)
                {
                    secondMax = nums[i];
                }                    
            }
            return (max - 1) * (secondMax - 1);
        }
    }
}
