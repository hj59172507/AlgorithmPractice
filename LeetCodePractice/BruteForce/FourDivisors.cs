using System;

/*
1390. Four Divisors

Given an integer array nums, return the sum of divisors of the integers in that array that have exactly four divisors.

If there is no such integer in the array, return 0.

Example 1:

Input: nums = [21,4,7]
Output: 32
Explanation:
21 has 4 divisors: 1, 3, 7, 21
4 has 3 divisors: 1, 2, 4
7 has 2 divisors: 1, 7
The answer is the sum of divisors of 21 only.
 
Constraints:

1 <= nums.length <= 10^4
1 <= nums[i] <= 10^5

Sol 
Time O(N*n^0.5) N is the number of elements, and n is the actual value
Space O(1)
Loop from 2 to square root of num, break if divisor is more than 4
 */
namespace LeetCodePractice.BruteForce
{
    class FourDivisors
    {
        //static void Main()
        static void Main1390()
        {            
            int[] nums = { 7286, 18704, 70773, 8224, 91675 };
            Console.Out.WriteLine(SumFourDivisors(nums));
            Console.In.ReadLine();
        }
        public static int SumFourDivisors(int[] nums)
        {
            int sum = 0;
            foreach(int i in nums)
            {
                int temp = 0, count = 2, sq = (int)Math.Sqrt(i);
                for(int j = 2; j <= sq; ++j)
                {
                    if(i % j == 0)
                    {
                        if (i == sq * sq || count == 4) { ++count;  break; }
                        count += 2;
                        temp += j + i / j;
                    }
                }
                if (count == 4) sum += temp + i + 1;
            }
            return sum;
        }
    }
}
