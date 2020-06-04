using System;

/*
1397. Find All Good Strings

Given the strings s1 and s2 of size n, and the string evil. Return the number of good strings.

A good string has size n, it is alphabetically greater than or equal to s1, it is alphabetically smaller than or equal to s2, and it does not contain the string evil as a substring. Since the answer can be a huge number, return this modulo 10^9 + 7.

Example 1:

Input: n = 2, s1 = "aa", s2 = "da", evil = "b"
Output: 51 
Explanation: There are 25 good strings starting with 'a': "aa","ac","ad",...,"az". Then there are 25 good strings starting with 'c': "ca","cc","cd",...,"cz" and finally there is one good string starting with 'd': "da". 
Example 2:

Input: n = 8, s1 = "leetcode", s2 = "leetgoes", evil = "leet"
Output: 0 
Explanation: All strings greater than or equal to s1 and smaller than or equal to s2 start with the prefix "leet", therefore, there is not any good string.
Example 3:

Input: n = 2, s1 = "gx", s2 = "gz", evil = "x"
Output: 2
 
Constraints:

s1.length == n
s2.length == n
s1 <= s2
1 <= n <= 500
1 <= evil.length <= 50
All strings consist of lowercase English letters.

Sol
Time O(nm) n = length of s, m = length of evil
Space O(nm)

Use dp[i, e, left, right] that store the number of valid solution for i character string, e number of matching to evil string, and left and right bound.
Using KMP to keep track of number of matching evil string, cost is only O(m)
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class FindAllGoodString
    {        
        //static void Main()
        static void Main1397()
        {
            string s1 = "kazxkmmctdgtrplfggliycskmbfzjkrsthahcrxaaylpdykqfyejwteexytvxgjrbviconioomfpznawsseisfcpfkuvx";
            string s2 = "lajtokckoizywvirjhccouuhjkkshdtzchzmiccujzpeqzcvfekdqjgrbkzrwfnfwhyvzrrrakiausbleeimmthaqqouh";
            string e = "kpvphwnkrtxuiuhb";            
            Console.Out.WriteLine(FindGoodStrings(s1, s2, e));
            Console.In.ReadLine();
        }
        public static int FindGoodStrings(string s1, string s2, string evil)
        {            
            int[] dp = new int[1<<17];                                
            return dfs(0, 0, true, true, s1, s2, evil, GetLPSArray(evil), dp);
        }

        public static int dfs(int i, int evilMatched, bool leftBound, bool rightBound, 
                              string s1, string s2, string evil, int[] lps, int[] dp)
        {
            if (evilMatched == evil.Length) return 0; //not a valid string
            if (i == s1.Length) return 1; //valid string
            int key = getKey(i, evilMatched, leftBound, rightBound);
            if (dp[key] != 0) return dp[key];//already found this answer
            char from = leftBound ? s1[i] : 'a';//define range
            char to= rightBound ? s2[i] : 'z';
            int ans = 0;
            for(char c = from; c <= to; ++c)
            {
                int j = evilMatched;//Using KMP algorithm, j will tell us how many character match given c in o(n)
                while (j > 0 && evil[j] != c) j = lps[j - 1];
                if (c == evil[j]) ++j;
                ans = (ans + dfs(i + 1, j, leftBound && (from == c), rightBound && (to == c), s1, s2, evil, lps, dp)) % 1000000007;                
            }
            dp[key] = ans;
            return ans;
        }

        static int getKey(int n, int m, bool b1, bool b2)
        {
            // Need 9 bits store n (2^9=512), 6 bits store m (2^6=64), 1 bit store b1, 1 bit store b2
            return (n << 8) | (m << 2) | ((b1 ? 1 : 0) << 1) | (b2 ? 1 : 0);
        }
        
         //lps[i] = the longest proper prefix of pat[0..i] which is also a suffix of pat[0..i]         
         //proper prefix is a prefix of string s but not including s, E.g. proper subset
        public static int[] GetLPSArray(string str)
        {
            int n = str.Length;
            int[] lps = new int[n];
            for (int i = 1, j = 0; i < n; i++)
            {
                while (j > 0 && str[i] != str[j]) j = lps[j - 1];
                if (str[i] == str[j]) lps[i] = ++j;
            }
            return lps;
        }
        
    }
}
