using System;
using System.Collections.Generic;
/*
1371. Find the Longest Substring Containing Vowels in Even Counts

Given the string s, return the size of the longest substring containing each vowel an even number of times. That is, 'a', 'e', 'i', 'o', and 'u' must appear an even number of times.

Example 1:

Input: s = "eleetminicoworoep"
Output: 13
Explanation: The longest substring is "leetminicowor" which contains two each of the vowels: e, i and o and zero of the vowels: a and u.
Example 2:

Input: s = "leetcodeisgreat"
Output: 5
Explanation: The longest substring is "leetc" which contains two e's.
Example 3:

Input: s = "bcbcbc"
Output: 6
Explanation: In this case, the given string "bcbcbc" is the longest because all vowels: a, e, i, o and u appear zero times.
 
Constraints:

1 <= s.length <= 5 x 10^5
s contains only lowercase English letters.

Sol
Time O(n)
Space O(1)

Keep a bit mask that represent if each vowel is even or odd.
Also store the first occurance of each bit mask state.
If a mask at state i == 0, it must have even count of all vowels
If bit mask at index i == bit mask at index j, then we know state of string(i to j) == 0, or it must have even count of all vowels. 
 */
namespace LeetCodePractice.Geeky
{
    class LongestSubStringOfEvenVowels
    {
        //static void Main()
        static void Main1372()
        {
            string s = "eleetminicoworoep";
            Console.Out.WriteLine(FindTheLongestSubstring(s));
            Console.In.ReadLine();
        }
        public static int FindTheLongestSubstring(string s)
        {
            int res = 0, mask = 0, n = s.Length;
            Dictionary<int, int> seen = new Dictionary<int, int>();
            seen[0] = -1;
            for(int i = 0; i < n; ++i)
            {
                mask ^= 1 << ("aeiou".IndexOf(s[i]) + 1) >> 1;
                if (!seen.ContainsKey(mask)) seen[mask] = i;
                res = Math.Max(res, i - seen[mask]);
            }
            return res;
        }
    }
}
