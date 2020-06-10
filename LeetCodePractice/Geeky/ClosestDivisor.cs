using System;

/*
1362. Closest Divisors

Given an integer num, find the closest two integers in absolute difference whose product equals num + 1 or num + 2.

Return the two integers in any order.

Example 1:

Input: num = 8
Output: [3,3]
Explanation: For num + 1 = 9, the closest divisors are 3 & 3, for num + 2 = 10, the closest divisors are 2 & 5, hence 3 & 3 is chosen.
Example 2:

Input: num = 123
Output: [5,25]
Example 3:

Input: num = 999
Output: [40,25]
 
Constraints:

1 <= num <= 10^9

Sol
Time O(log(n))
Space O(log(n))
Find all pair of int divisor for n+1 and n+2.
Compare the distance to n, pick the min distance.
 */
namespace LeetCodePractice.Geeky
{
    class ClosestDivisor
    {
        public int[] ClosestDivisors(int x)
        {
            for (int a = (int)Math.Sqrt(x + 2); a > 0; --a)
            {
                if ((x + 1) % a == 0)
                    return new int[] { a, (x + 1) / a };
                if ((x + 2) % a == 0)
                    return new int[] { a, (x + 2) / a };
            }
            return new int[] { };
        }

    }
}
