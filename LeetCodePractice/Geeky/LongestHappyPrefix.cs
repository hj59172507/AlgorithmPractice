using System;
/*
1392. Longest Happy Prefix

A string is called a happy prefix if is a non-empty prefix which is also a suffix (excluding itself).

Given a string s. Return the longest happy prefix of s .

Return an empty string if no such prefix exists.

Example 1:

Input: s = "level"
Output: "l"
Explanation: s contains 4 prefix excluding itself ("l", "le", "lev", "leve"), and suffix ("l", "el", "vel", "evel"). The largest prefix which is also suffix is given by "l".
Example 2:

Input: s = "ababab"
Output: "abab"
Explanation: "abab" is the largest prefix which is also suffix. They can overlap in the original string.
Example 3:

Input: s = "leetcodeleet"
Output: "leet"
Example 4:

Input: s = "a"
Output: ""
 
Constraints:

1 <= s.length <= 10^5
s contains only lowercase English letters.

Sol KMP
Time O(n)
Space O(n)
Well, this is just KMP part of build LPS

Sol2 Hashing
Time O(n)
Space O(1)
No collison detection
 */
namespace LeetCodePractice.Geeky
{
    class LongestHappyPrefix
    {
        //static void Main()
        static void Main1392()
        {
            Console.Out.WriteLine(LongestPrefix("ababab"));
            Console.In.ReadLine();
        }
        //Hashing
        public static string LongestPrefix(string str)
        {
            long h1 = 0, h2 = 0, mul = 1, len = 0, mod = 1000000007;
            for (int i = 0, j = str.Length - 1; j > 0; ++i, --j)
            {
                int first = str[i] - 'a', last = str[j] - 'a';
                h1 = (h1 * 26 + first) % mod;
                h2 = (h2 + mul * last) % mod;
                mul = mul * 26 % mod;
                if (h1 == h2)
                    len = i + 1;
            }
            return str.Substring(0, (int)len);
        }

        //KMP
        //public static string LongestPrefix(string str)
        //{
        //    int n = str.Length;
        //    int[] lps = new int[n];            
        //    for (int i = 1, j = 0; i < n; i++)
        //    {
        //        while (j > 0 && str[i] != str[j]) j = lps[j - 1];
        //        if (str[i] == str[j]) lps[i] = ++j;                
        //    }            
        //    return str.Substring(0, lps[str.Length-1]);
        //}
    }
}
