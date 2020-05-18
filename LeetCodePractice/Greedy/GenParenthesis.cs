using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]

Sol1:

Recursivly solve the problem by check following condition:
1. Stop and add result if number of ) == n
2. Add ) only if number of ( == n
3. Add ( only if number of ( == number of )
4. Add either ( or ) if non of above condition is met

Sol2 DP:
To generate all n-pair parentheses, we can do the following:

Generate one pair: ()

Generate 0 pair inside, n - 1 afterward: () (...)...

Generate 1 pair inside, n - 2 afterward: (()) (...)...

...

Generate n - 1 pair inside, 0 afterward: ((...))
*/
namespace LeetCodePractice.Greedy
{
    class GenParenthesis
    {
        //static void Main()
        static void Main22()
        {
            int n = 3;
            Console.Out.WriteLine(GenerateParenthesis(n).Count());
            Console.In.ReadLine();
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            List<String> res = new List<string>();
            GenerateParenthesisHelper(n, 0, 0, res, "");
            return res;
        }

        public static void GenerateParenthesisHelper(int n, int openP, int closeP, List<string> res, string s)
        {
            if(closeP == n)
            {
                res.Add(s);
                return;
            }
            if(openP == closeP)
            {
                s += "(";                
                GenerateParenthesisHelper(n, openP+1, closeP, res, s);
            }
            else
            {
                if (openP == n)
                {
                    s += ")";
                    GenerateParenthesisHelper(n, openP, closeP+1, res, s);
                }
                else
                {
                    GenerateParenthesisHelper(n, openP+1, closeP, res, s+"(");
                    GenerateParenthesisHelper(n, openP, closeP+1, res, s+")");
                }
            }

        }
    }
}
