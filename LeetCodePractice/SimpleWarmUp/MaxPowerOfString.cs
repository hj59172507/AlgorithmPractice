using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Given a string s, the power of the string is the maximum length of a non-empty substring that contains only one unique character.

Return the power of the string.

Example 1:

Input: s = "leetcode"
Output: 2
Explanation: The substring "ee" is of length 2 with the character 'e' only.
Example 2:

Input: s = "abbcccddddeeeeedcba"
Output: 5
Explanation: The substring "eeeee" is of length 5 with the character 'e' only.
Example 3:

Input: s = "triplepillooooow"
Output: 5
Example 4:

Input: s = "hooraaaaaaaaaaay"
Output: 11
Example 5:

Input: s = "tourist"
Output: 1
 
Constraints:

1 <= s.length <= 500
s contains only lowercase English letters.

Sol Brute Force:
Time O(n)
Space O(1)

Linear scan of string
 */

namespace LeetCodePractice.SimpleWarmUp
{
    class MaxPowerOfString
    {
        //static void Main()
        static void Main1446()
        {
            string s = "abbcccddddeeeeedcba";
            Console.Out.WriteLine(MaxPower(s));
            Console.In.ReadLine();
        }

        public static int MaxPower(string s)
        {
            int power = 1;
            int tempCount = 1;
            char temp = s.First();
            for(int i = 1; i<s.Length; i++)
            {
                char c = s[i];
                if(temp == c)
                {
                    tempCount++;
                }
                else
                {
                    temp = c;
                    power = Math.Max(tempCount, power);
                    tempCount = 1;
                }
                
            }
            return Math.Max(tempCount, power); 
        }
    }
}
