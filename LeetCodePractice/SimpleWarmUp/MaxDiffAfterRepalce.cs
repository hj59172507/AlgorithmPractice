using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
You are given an integer num. You will apply the following steps exactly two times:

Pick a digit x (0 <= x <= 9).
Pick another digit y (0 <= y <= 9). The digit y can be equal to x.
Replace all the occurrences of x in the decimal representation of num by y.
The new integer cannot have any leading zeros, also the new integer cannot be 0.
Let a and b be the results of applying the operations to num the first and second times, respectively.

Return the max difference between a and b.

Example 1:

Input: num = 555
Output: 888
Explanation: The first time pick x = 5 and y = 9 and store the new integer in a.
The second time pick x = 5 and y = 1 and store the new integer in b.
We have now a = 999 and b = 111 and max difference = 888
Example 2:

Input: num = 9
Output: 8
Explanation: The first time pick x = 9 and y = 9 and store the new integer in a.
The second time pick x = 9 and y = 1 and store the new integer in b.
We have now a = 9 and b = 1 and max difference = 8
Example 3:

Input: num = 123456
Output: 820000
Example 4:

Input: num = 10000
Output: 80000
Example 5:

Input: num = 9288
Output: 8700

Constraints:

1 <= num <= 10^8

Sol String manipulation
Time O(n)
Space O(1)

Rule to find max: from greatest signification digit, find first not '9', replace that with 9
Rule to find min: If first digit is not '1', replace with 1. Else find first digit not 1 and 0 and replace that

 */
namespace LeetCodePractice.SimpleWarmUp
{
    class MaxDiffAfterRepalce
    {
        //static void Main()
        static void Main1432()
        {
            int a = 111;
            Console.Out.WriteLine(MaxDiff(a));
            Console.In.ReadLine();
        }
        public static int MaxDiff(int num)
        {
            if (num < 10)
                return 8;            
            string s = num.ToString(), max, min;
            int i = 0, j = 1;
            while (i < s.Length && s[i] == '9') i++;
            if(i < s.Length)            
                max = s.Replace(s[i], '9');         
            else
                max = s; 
            if(s[0] != '1')
            {
                min = s.Replace(s[0], '1');
            }
            else 
            {
                while (j < s.Length && (s[j] == '0' || s[j] == '1')) j++;
                if (j < s.Length)
                    min = s.Replace(s[j], '0');
                else
                    min = s;
            }
            return int.Parse(max)-int.Parse(min);
        }
    }
}
