using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given two strings A and B of lowercase letters, return true if and only if we can swap two letters in A so that the result equals B.

Example 1:

Input: A = "ab", B = "ba"
Output: true
Example 2:

Input: A = "ab", B = "ab"
Output: false
Example 3:

Input: A = "aa", B = "aa"
Output: true
Example 4:

Input: A = "aaaaaaabc", B = "aaaaaaacb"
Output: true
Example 5:

Input: A = "", B = "aa"
Output: false
 

Note:

0 <= A.length <= 20000
0 <= B.length <= 20000
A and B consist only of lowercase letters.

Sol Case by case analysis

1. If A.length != B.length, false;
2. If A == B, true if there is duplicate letter
3. true if there is only two difference between a, b
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class CanSwapTwoLetter
    {
        //static void Main()
        static void Main859()
        {
            string A = "abcaa", B = "abcbb";
            Console.Out.WriteLine(BuddyStrings(A,B));
            Console.In.ReadLine();
        }
        public static bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length) return false;
            if (A.Equals(B))
            {
                HashSet<char> s = new HashSet<char>();
                foreach(char c in A)
                {
                    if (!s.Contains(c)) s.Add(c);                    
                }
                return s.Count < A.Length;
            }
            List<int> diff = new List<int>();
            for(int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    diff.Add(i);
                }
            }
            return diff.Count == 2 && (A[diff[0]] == B[diff[1]] && A[diff[1]] == B[diff[0]]);
        }
    }
}
