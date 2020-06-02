using System;
using System.Collections.Generic;

/*
1414. Find the Minimum Number of Fibonacci Numbers Whose Sum Is K

Given the number k, return the minimum number of Fibonacci numbers whose sum is equal to k, whether a Fibonacci number could be used multiple times.

The Fibonacci numbers are defined as:

F1 = 1
F2 = 1
Fn = Fn-1 + Fn-2 , for n > 2.
It is guaranteed that for the given constraints we can always find such fibonacci numbers that sum k.
 
Example 1:

Input: k = 7
Output: 2 
Explanation: The Fibonacci numbers are: 1, 1, 2, 3, 5, 8, 13, ... 
For k = 7 we can use 2 + 5 = 7.
Example 2:

Input: k = 10
Output: 2 
Explanation: For k = 10 we can use 2 + 8 = 10.
Example 3:

Input: k = 19
Output: 3 
Explanation: For k = 19 we can use 1 + 5 + 13 = 19.
 
Constraints:

1 <= k <= 10^9

Sol
Time O(n) where fib(n) > k
Space O(n)
Compute the fib until n where fib(n) > k.
Since we have 1 and 2 in fib, and each fib(n) builds from them, fib(n-1) must be in the sum of k.
Search start from n-1 will guarantee the result be minimum.
 */
namespace LeetCodePractice.Greedy
{
    class FibonacciSumToK
    {
        //static void Main()
        static void Main1414()
        {
            int k = 7;
            Console.Out.WriteLine(FindMinFibonacciNumbers(k));
            Console.In.ReadLine();
        }
        public static int FindMinFibonacciNumbers(int k)
        {
            List<int> fib = new List<int>() { 1, 1, 2};
            for(int i=3; ; i++)
            {
                int next = fib[i - 1] + fib[i - 2];
                if (next > k)
                    break;
                fib.Add(next);
            }
            int ans = 0, pos = fib.Count-1;
            while(k != 0)
            {
                if(fib[pos] <= k)
                {
                    k -= fib[pos];
                    ans++;
                }
                pos--;
            }
            return ans;
        }
    }
}
