using System;

/*
 * Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

Note:

s could be empty and contains only lowercase letters a-z.
p could be empty and contains only lowercase letters a-z, and characters like . or *.
Example 1:

Input:
s = "aa"
p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input:
s = "aa"
p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input:
s = "ab"
p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".
Example 4:

Input:
s = "aab"
p = "c*a*b"
Output: true
Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore, it matches "aab".
Example 5:

Input:
s = "mississippi"
p = "mis*is*p*."
Output: false

Sol1 DP:
Time O(n*m)
Space O(n*m)

Build a boolean matrix M[i][j] so that M[i][j] represent if up to ith character in s matches up to jth character in p
1. If p.charAt(j) == s.charAt(i), then M[i][j] = M[i-1][j-1] 
2. If P.charAt(j) == '.' then M[i][j] = M[i-1][j-1] 
3. If P.chatAt(j) == "*" then:
    If P.charAt(j-1) != '.' && != s.chatAt(i-1), then M[i][j] = M[i][j-2]
    Else M[i][j] = M[i-1][j] //a* counts as multiple
        or M[i][j] = M[i][j-1] //a* counts as one
        or M[i][j] = M[i][j-2] //a* counts as empty

 */
namespace LeetCodePractice.Dynamic_Programming
{
    class RegularExpressionMatching
    {
        //static void Main()
        static void Main10()
        {
            string s = s = "mississippi";
            string p = "mis*is*p*.";
            Console.Out.WriteLine(IsMatch(s, p));
            Console.In.ReadLine();
        }
        public static bool IsMatch(string s, string p)
        {
            if( s == null && p != null || p == null && s != null)
            {
                return false;
            }
            bool[,] M = new bool[s.Length+1,p.Length+1];
            M[0,0] = true; //empty pattern can match empty string
            for(int i=0; i < p.Length; i++)
            {
                if (p[i] == '*' && M[0, i - 1])
                    M[0, i+1] = true;
            }
            
            for(int i=1; i < s.Length+1; i++)
            {
                for(int j=1; j<p.Length+1; j++)
                {
                    char curS = s[i - 1];
                    char curP = p[j - 1];
                    if (curP == '.' || curP == curS)
                        M[i, j] = M[i-1, j-1];
                    else if(curP == '*')
                    {
                        char preCurP = p[j - 2];
                        if (preCurP != '.' && preCurP != curS)
                            M[i, j] = M[i, j - 2];
                        else
                        {
                            M[i, j] = M[i, j - 2] || M[i - 1, j - 2] || M[i - 1, j];
                        }
                    }
                }
            }
            return M[s.Length, p.Length];
        }
    }
}
