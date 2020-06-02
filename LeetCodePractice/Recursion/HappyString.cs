using System;
using System.Text;
/*
1415. The k-th Lexicographical String of All Happy Strings of Length n
A happy string is a string that:

consists only of letters of the set ['a', 'b', 'c'].
s[i] != s[i + 1] for all values of i from 1 to s.length - 1 (string is 1-indexed).
For example, strings "abc", "ac", "b" and "abcbabcbcb" are all happy strings and strings "aa", "baa" and "ababbc" are not happy strings.

Given two integers n and k, consider a list of all happy strings of length n sorted in lexicographical order.

Return the kth string of this list or return an empty string if there are less than k happy strings of length n.

Example 1:

Input: n = 1, k = 3
Output: "c"
Explanation: The list ["a", "b", "c"] contains all happy strings of length 1. The third string is "c".
Example 2:

Input: n = 1, k = 4
Output: ""
Explanation: There are only 3 happy strings of length 1.
Example 3:

Input: n = 3, k = 9
Output: "cab"
Explanation: There are 12 different happy string of length 3 ["aba", "abc", "aca", "acb", "bab", "bac", "bca", "bcb", "cab", "cac", "cba", "cbc"]. You will find the 9th string = "cab"
Example 4:

Input: n = 2, k = 7
Output: ""
Example 5:

Input: n = 10, k = 100
Output: "abacbabacb"
 
Constraints:

1 <= n <= 10
1 <= k <= 100

Sol
O(k)
Space O(k)
Total happy string is 3*(2^n) when n != 1, hence return if k is greater than this.
Else find the first K solutions resursively, appending a, b, c in that order without appending same letter as previous one
 */
namespace LeetCodePractice.Recursion
{
    class HappyString
    {
        //static void Main()
        static void Main1415()
        {
            int n = 10, k = 100;
            Console.Out.WriteLine(GetHappyString(n,k));
            Console.In.ReadLine();
        }
        public static string GetHappyString(int n, int k)
        {
            if (n != 1 && 3 * (int)Math.Pow(2, n - 1) < k) return "";
            StringBuilder ans = new StringBuilder();
            int count = 0;
            recurHelper("", n, k, ref count, ans);
            return ans.ToString();
        }

        public static void recurHelper(string s, int n, int k, ref int count, StringBuilder sb)
        {
            if(s.Length == n || sb.ToString() != "")
            {
                count++;
                if (count == k) sb.Append(s);               
                return;
            }
            if (s == "" || s[s.Length - 1] != 'a') recurHelper(s + "a", n, k, ref count, sb);
            if (s == "" || s[s.Length - 1] != 'b') recurHelper(s + "b", n, k, ref count, sb);
            if (s == "" || s[s.Length - 1] != 'c') recurHelper(s + "c", n, k, ref count, sb);
        }
    }
}
