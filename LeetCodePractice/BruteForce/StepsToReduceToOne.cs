using System;

/*
1404. Number of Steps to Reduce a Number in Binary Representation to One

Given a number s in their binary representation. Return the number of steps to reduce it to 1 under the following rules:

If the current number is even, you have to divide it by 2.

If the current number is odd, you have to add 1 to it.

It's guaranteed that you can always reach to one for all testcases.

Example 1:

Input: s = "1101"
Output: 6
Explanation: "1101" corressponds to number 13 in their decimal representation.
Step 1) 13 is odd, add 1 and obtain 14. 
Step 2) 14 is even, divide by 2 and obtain 7.
Step 3) 7 is odd, add 1 and obtain 8.
Step 4) 8 is even, divide by 2 and obtain 4.  
Step 5) 4 is even, divide by 2 and obtain 2. 
Step 6) 2 is even, divide by 2 and obtain 1.  
Example 2:

Input: s = "10"
Output: 1
Explanation: "10" corressponds to number 2 in their decimal representation.
Step 1) 2 is even, divide by 2 and obtain 1.  
Example 3:

Input: s = "1"
Output: 0
 
Constraints:

1 <= s.length <= 500
s consists of characters '0' or '1'
s[0] == '1'

Sol
Time O(n)
Space O(1)
Since we s start with 1, we don't care about the first digit.
We alway add one operation if all we see is zero, it is just right shift of 1.
If we see a 1, set the carry to one. So in the next iteration, if it is a 1, it will be consider as zero, if zero, consider a one.
 */
namespace LeetCodePractice.BruteForce
{
    class StepsToReduceToOne
    {
        //static void Main()
        static void Main1404()
        {
            string s = "1101";
            Console.Out.WriteLine(NumSteps(s));
            Console.In.ReadLine();
        }
        public static int NumSteps(string s)
        {
            int ans = 0, carry = 0;
            for (int i = s.Length - 1; i > 0; --i)
            {
                ++ans;
                if(s[i] - '0' + carry == 1)
                {
                    carry = 1;
                    ++ans;
                }
            }
            return ans+carry;
        }
    }
}
