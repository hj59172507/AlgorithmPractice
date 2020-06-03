using System;
using System.Collections.Generic;

/*
1400. Construct K Palindrome Strings

Given a string s and an integer k. You should construct k non-empty palindrome strings using all the characters in s.

Return True if you can use all the characters in s to construct k palindrome strings or False otherwise.

Example 1:

Input: s = "annabelle", k = 2
Output: true
Explanation: You can construct two palindromes using all characters in s.
Some possible constructions "anna" + "elble", "anbna" + "elle", "anellena" + "b"
Example 2:

Input: s = "leetcode", k = 3
Output: false
Explanation: It is impossible to construct 3 palindromes using all the characters of s.
Example 3:

Input: s = "true", k = 4
Output: true
Explanation: The only possible solution is to put each character in a separate string.
Example 4:

Input: s = "yzyzyzyzyzyzyzy", k = 2
Output: true
Explanation: Simply you can put all z's in one string and all y's in the other string. Both strings will be palindrome.
Example 5:

Input: s = "cr", k = 7
Output: false
Explanation: We don't have enough characters in s to construct 7 palindromes.
 
Constraints:

1 <= s.length <= 10^5
All characters in s are lower-case English letters.
1 <= k <= 10^5

Sol 
Time O(n)
Space O(1)
1. If s.length < k, it is impossible to construct k palindrome since each need at lesat character, return false.
2. If number of odd count > k, then we at least have odd count of palindrome, hence also false.
3. All cases are true, since s.length > k and all odd count is < k. 
If s.length = k, each char will be a parlindrome.
If s.length > k, we can combine even length letter or separate them to make 1 to count of even length letter palindromes, and from above we just prove that in most extreme case s.length = k
 */
namespace LeetCodePractice.Geeky
{
    class CanBuildKPalindromeString
    {
        //static void Main()
        static void Main1400()
        {
            string s = "leetcode";
            int k = 3;
            Console.Out.WriteLine(CanConstruct(s, k));
            Console.In.ReadLine();
        }
        public static bool CanConstruct(string s, int k)
        {
            if (s.Length < k) return false;
            int odd = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if (dict.ContainsKey(c)) dict[c]++;
                else dict[c] = 1;
            }
            foreach(char c in dict.Keys)
            {
                if (dict[c] % 2 != 0) ++odd;
            }
            if (odd > k)
                return false;
            return true;
        }
    }
}
