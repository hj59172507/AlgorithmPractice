using System.Collections.Generic;
/*
 Given an integer, write a function to determine if it is a power of two.

Example 1:

Input: 1
Output: true 
Explanation: 20 = 1
Example 2:

Input: 16
Output: true
Explanation: 24 = 16
Example 3:

Input: 218
Output: false

June 8, 2020
 */
namespace LeetCodePractice.DailyChallenge
{

    class IsPowerOfTwo
    {
        public bool IsPowerOfTwoForInt(int n)
        {            
            HashSet<int> p2 = new HashSet<int>();
            int c = 1;
            p2.Add(1);
            for (int i = 1; i < 31; ++i)
            {
                c *= 2;
                p2.Add(c);                
            }
            return p2.Contains(n);
        }
    }
}
