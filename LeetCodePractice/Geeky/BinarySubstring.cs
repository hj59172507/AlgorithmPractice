using System;
using System.Collections.Generic;
/*
1461. Check If a String Contains All Binary Codes of Size K

Given a binary string s and an integer k.

Return True if all binary codes of length k is a substring of s. Otherwise, return False.

Example 1:

Input: s = "00110110", k = 2
Output: true
Explanation: The binary codes of length 2 are "00", "01", "10" and "11". They can be all found as substrings at indicies 0, 1, 3 and 2 respectively.
Example 2:

Input: s = "00110", k = 2
Output: true
Example 3:

Input: s = "0110", k = 1
Output: true
Explanation: The binary codes of length 1 are "0" and "1", it is clear that both exist as a substring. 
Example 4:

Input: s = "0110", k = 2
Output: false
Explanation: The binary code "00" is of length 2 and doesn't exist in the array.
Example 5:

Input: s = "0000000001011100", k = 4
Output: false
 
Constraints:

1 <= s.length <= 5 * 10^5
s consists of 0's and 1's only.
1 <= k <= 20

Sol 
Time O(n)
Space O(2^k)
Check all substring of length k in s, we should find exactly 2^k answers, else it is false.
There is only s.Length - k such substring
 */
namespace LeetCodePractice.Geeky
{
    class BinarySubstring
    {
        //static void Main()
        static void Main1461()
        {
            string s = "00110";
            int k = 2;
            Console.Out.WriteLine(HasAllCodes(s,k));
            Console.In.ReadLine();
        }
        public static bool HasAllCodes(string s, int k)
        {
            if ((int)Math.Pow((double)2, (double)k) > s.Length - k + 1) return false;
            HashSet<string> allCodes = new HashSet<string>();
            int count = 0;
            for(int i = 0; i <= s.Length - k; i++)
            {
                string t = s.Substring(i, k);
                if (!allCodes.Contains(t))
                {
                    allCodes.Add(t);
                    count++;
                }
            }
            return count == (int)Math.Pow((double)2, (double)k);
        }
    }
}
