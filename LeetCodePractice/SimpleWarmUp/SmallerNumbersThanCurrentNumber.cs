using System;
using System.Collections;

namespace LeetCodePractice.SimpleWarmUp
{
    class SmallerNumbersThanCurrentNumber
    {
        //static void Main()
        static void Main1365()
        {
            int[] nums = new int[] { 8, 1, 2, 2, 3 };
            printArray(smallerNumbersThanCurrent(nums));
            Console.In.ReadLine();
        }
        public static int[] smallerNumbersThanCurrent(int[] nums)
        {
            int[] result = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {                
                for(int j = i+1; j < nums.Length; j++)
                {
                    if(nums[j] < nums[i])
                    {
                        result[i]++;
                    }
                    if (nums[j] > nums[i])
                    {
                        result[j]++;
                    }
                }
             
            }
            return result;
            /*
            Bucket solution base on restriction
            int[] bucket = new int[102];
            for(int i=0; i<nums.length; i++)
                bucket[nums[i]+1]++;

            for(int i=1; i<102; i++) 
                bucket[i] += bucket[i-1];
        
            for(int i=0; i<nums.length; i++)
                nums[i] = bucket[nums[i]];
        
            return nums;
             * */
        }

        public static void printArray(IEnumerable arr)
        {
            foreach(var a in arr)
            {
                Console.Out.WriteLine(a);
            }
        }
    }
}
