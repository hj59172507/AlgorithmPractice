using System;

/*
Given a string s of zeros and ones, return the maximum score after splitting the string into two non-empty substrings (i.e. left substring and right substring).

The score after splitting a string is the number of zeros in the left substring plus the number of ones in the right substring.

Example 1:

Input: s = "011101"
Output: 5 
Explanation: 
All possible ways of splitting s into two non-empty substrings are:
left = "0" and right = "11101", score = 1 + 4 = 5 
left = "01" and right = "1101", score = 1 + 3 = 4 
left = "011" and right = "101", score = 1 + 2 = 3 
left = "0111" and right = "01", score = 1 + 1 = 2 
left = "01110" and right = "1", score = 2 + 1 = 3
Example 2:

Input: s = "00111"
Output: 5
Explanation: When left = "00" and right = "111", we get the maximum score = 2 + 3 = 5
Example 3:

Input: s = "1111"
Output: 3
 

Constraints:

2 <= s.length <= 500
The string s consists of characters '0' and '1' only.

Sol 
Time O(n)
Space O(1)
Since we can't have empty substring, remove last letter after counting number of ones and zeros.
For each c, keep count of ones and zeros for score, assumn when we reach that c, we make a cut there.
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class MaxScoreOfZeroAndOne
    {
        //static void Main()
        static void Main1422()
        {
            string s = "011101";
            Console.Out.WriteLine(MaxScore(s));
            Console.In.ReadLine();
        }
        public static int MaxScore(string s)
        {
            int ans = 0;
            int zeros = 0;
            foreach(char c in s)
            {
                if (c == '0') zeros++;
            }
            int ones = s.Length - zeros;
            int zeroC = 0, oneC = 0;
            s = s.Remove(s.Length-1, 1);
            foreach(char c in s)
            {
                if(c == '0') zeroC++;               
                else oneC++;                                    
                ans = Math.Max(ans, zeroC + ones - oneC);
            }
            return ans;
        }
    }
}
