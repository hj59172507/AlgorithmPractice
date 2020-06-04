using System;
/*
1399. Count Largest Group

Given an integer n. Each number from 1 to n is grouped according to the sum of its digits. 

Return how many groups have the largest size.

Example 1:

Input: n = 13
Output: 4
Explanation: There are 9 groups in total, they are grouped according sum of its digits of numbers from 1 to 13:
[1,10], [2,11], [3,12], [4,13], [5], [6], [7], [8], [9]. There are 4 groups with largest size.
Example 2:

Input: n = 2
Output: 2
Explanation: There are 2 groups [1], [2] of size 1.
Example 3:

Input: n = 15
Output: 6
Example 4:

Input: n = 24
Output: 5
 
Constraints:

1 <= n <= 10^4

Sol
Time O(n)
Space O(1)
Count digit sum for each number in the range, and return largest group size
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class CountDigitSum
    {
        //static void Main()
        static void Main1399()
        {
            int n = 38;
            Console.Out.WriteLine(CountLargestGroup(n));
            Console.In.ReadLine();
        }
        public static int CountLargestGroup(int n)
        {
            int ans = 0, groupSize = 0;
            int[] count = new int[40];
            
            for(int i = 1; i <= n; ++i)
            {
                int digits = SumDigit(i);
                count[digits]++;
                if (count[digits] > groupSize) groupSize = count[digits];
            }
            foreach(int i in count)
            {
                if (i == groupSize) ++ans;
            }
            return ans;
        }

        static int SumDigit(int n)
        {
            int ans = 0;
            while(n > 0)
            {
                ans = ans + n % 10;
                n /= 10;
            }
            return ans;
        }
    }
}
