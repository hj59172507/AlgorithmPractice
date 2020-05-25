using System;
using System.Collections.Generic;

/*
Given a string s and an integer k.

Return the maximum number of vowel letters in any substring of s with length k.

Vowel letters in English are (a, e, i, o, u).

Example 1:

Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.
Example 2:

Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.
Example 3:

Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.
Example 4:

Input: s = "rhythms", k = 4
Output: 0
Explanation: We can see that s doesn't have any vowel letters.
Example 5:

Input: s = "tryhard", k = 4
Output: 1
 
Constraints:

1 <= s.length <= 10^5
s consists of lowercase English letters.
1 <= k <= s.length

Sol Slice Window:
Time O(n)
Space O(1)
Mainting a moving sum of vowel and max vowel count
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class MaxVowelsInSubString
    {
        //static void Main()
        static void Main1456()
        {
            string s = "leetcode";
            int k = 3;
            Console.Out.WriteLine(MaxVowels(s,k));
            Console.In.ReadLine();
        }
        public static int MaxVowels(string s, int k)
        {
            int ans = 0;
            HashSet<char> vowels = new HashSet<char>() {'a','e','i','o','u' };
            for(int i = 0; i < k; i++)
            {
                if (vowels.Contains(s[i]))
                    ans++;
            }

            int temp = ans;
            for (int i = k; i < s.Length; i++)
            {                
                if (vowels.Contains(s[i]))
                {
                    temp++;
                }
                if (vowels.Contains(s[i - k]))
                {
                    temp--;
                }
                ans = ans > temp ? ans : temp;  
            }

            return ans;
        }
    }
}
