﻿using System;
using System.Collections.Generic;
/*
1405. Longest Happy String
A string is called happy if it does not have any of the strings 'aaa', 'bbb' or 'ccc' as a substring.

Given three integers a, b and c, return any string s, which satisfies following conditions:

s is happy and longest possible.
s contains at most a occurrences of the letter 'a', at most b occurrences of the letter 'b' and at most c occurrences of the letter 'c'.
s will only contain 'a', 'b' and 'c' letters.
If there is no such string s return the empty string "".

Example 1:

Input: a = 1, b = 1, c = 7
Output: "ccaccbcc"
Explanation: "ccbccacc" would also be a correct answer.
Example 2:

Input: a = 2, b = 2, c = 1
Output: "aabbc"
Example 3:

Input: a = 7, b = 1, c = 0
Output: "aabaa"
Explanation: It's the only correct answer in this case.
 
Constraints:

0 <= a, b, c <= 100
a + b + c > 0

Sol
Time O(n)
Space O(1)
Determine the order of a, b, and c. Map each letter with their value.
For each iteration, we will add one letter from letter with most count, update the order afterward.
 */
namespace LeetCodePractice.Greedy
{
    class LongestHappystring
    {        
        //static void Main()
        static void Main1405()
        {
            int a = 7, b = 2, c = 0;
            Console.Out.WriteLine(LongestDiverseString(a, b, c));
            Console.In.ReadLine();
        }
        public static string LongestDiverseString(int a, int b, int c)
        {
            string ans = "";
            char min = 'a', mid = 'a', max = 'a';
            if (a >= b)
            {
                if (a >= c)
                {
                    if(b >= c)
                    {
                        max = 'a';
                        mid = 'b';
                        min = 'c';
                    }
                    else
                    {
                        max = 'a';
                        mid = 'c';
                        min = 'b';
                    }
                }
                else
                {
                    if(c >= b)
                    {
                        max = 'c';
                        mid = 'a';
                        min = 'b';
                    }
                }

            }
            else
            {
                if(b >= c)
                {
                    if(c >= a)
                    {
                        max = 'b';
                        mid = 'c';
                        min = 'a';
                    }
                    else
                    {
                        max = 'b';
                        mid = 'a';
                        min = 'c';
                    }
                }
                else
                {
                    max = 'c';
                    mid = 'b';
                    min = 'a';
                }
            }
            Dictionary<char, int> letter = new Dictionary<char, int>();
            letter['c'] = c;
            letter['b'] = b;
            letter['a'] = a;
            while (true)
            {
                if (letter[max] == 0) break;
                string before = ans.Length >= 2 ? ans.Substring(ans.Length - 2, 2) : "00";
                if(before != max.ToString() + max.ToString())
                {
                    ans += max;
                    letter[max]--;
                    if (letter[max] <= letter[mid])
                    {
                        char t = max;
                        max = mid;
                        mid = t;
                        if(letter[mid] <= letter[min])
                        {
                            t = mid;
                            mid = min;
                            min = t;
                        }
                    }
                    continue;
                }
                if(letter[mid] > 0)
                {
                    ans += mid;
                    letter[mid]--;
                    if(letter[mid] <= letter[min])
                    {
                        char t = mid;
                        mid = min;
                        min = t;
                    }
                    continue;
                }
                break;
            }
            return ans;
        }
    }
}
