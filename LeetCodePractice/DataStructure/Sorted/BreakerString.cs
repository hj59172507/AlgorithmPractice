using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given two strings: s1 and s2 with the same size, check if some permutation of string s1 can break some permutation of string s2 or vice-versa (in other words s2 can break s1).

A string x can break string y (both of size n) if x[i] >= y[i] (in alphabetical order) for all i between 0 and n-1.

Example 1:

Input: s1 = "abc", s2 = "xya"
Output: true
Explanation: "ayx" is a permutation of s2="xya" which can break to string "abc" which is a permutation of s1="abc".
Example 2:

Input: s1 = "abe", s2 = "acd"
Output: false 
Explanation: All permutations for s1="abe" are: "abe", "aeb", "bae", "bea", "eab" and "eba" and all permutation for s2="acd" are: "acd", "adc", "cad", "cda", "dac" and "dca". However, there is not any permutation from s1 which can break some permutation from s2 and vice-versa.
Example 3:

Input: s1 = "leetcodee", s2 = "interview"
Output: true
 
Constraints:

s1.length == n
s2.length == n
1 <= n <= 10^5
All strings consist of lowercase English letters.

Sol 1 Sort Array
Time O(nlog(n))
Space O(n)
sort both string, compare each char, if s1 breaks s2, each char satisfy c1 >= c2

Sol 2 Sum of char value
Time O(n)
Space O(1)
Store each char in string to a array(automatically sorted), and compare running count of charater
 */
namespace LeetCodePractice.DataStructure.Sorted
{
    class BreakerString
    {
        //static void Main()
        static void Main1433()
        {
            string s1 = "abe", s2 = "acd";
            Console.Out.WriteLine(CheckIfCanBreak(s1,s2));
            Console.In.ReadLine();
        }

        //public static bool CheckIfCanBreak(string s1, string s2)
        //{
        //    char[] c1 = s1.ToArray();
        //    char[] c2 = s2.ToArray();
        //    Array.Sort(c1);
        //    Array.Sort(c2);
        //    bool breaker1 = true, breaker2 = true ;
        //    for(int i = 0; i < c1.Length; i++)
        //    {
        //        if (c1[i] < c2[i])
        //            breaker1 = false;
        //        if (c2[i] < c1[i])
        //            breaker2 = false;
        //    }
        //    return breaker1 || breaker2;            
        //}

        public static bool CheckIfCanBreak(string s1, string s2)
        {
            int[] i1 = new int[26], i2 = new int[26];
            for(int i = 0; i < s1.Length; i++)
            {
                i1[s1[i] - 97]++;
                i2[s2[i] - 97]++;
            }
            bool breaker1 = true, breaker2 = true ;
            int count1 = 0, count2 = 0;
            for (int i = 0; i < 26; i++)
            {
                count1 += i1[i];
                count2 += i2[i];
                if(count1 > count2)
                {
                    breaker1 = false;
                    if (!breaker2)
                        return false;
                }
                if (count2 > count1)
                {
                    breaker2 = false;
                    if (!breaker1)
                        return false;
                }
            }
            return true;

        }
    }
}
