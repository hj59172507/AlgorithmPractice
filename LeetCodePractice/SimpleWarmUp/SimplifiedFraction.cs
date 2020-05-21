using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Given an integer n, return a list of all simplified fractions between 0 and 1 (exclusive) such that the denominator is less-than-or-equal-to n. The fractions can be in any order.

Example 1:

Input: n = 2
Output: ["1/2"]
Explanation: "1/2" is the only unique fraction with a denominator less-than-or-equal-to 2.
Example 2:

Input: n = 3
Output: ["1/2","1/3","2/3"]
Example 3:

Input: n = 4
Output: ["1/2","1/3","1/4","2/3","3/4"]
Explanation: "2/4" is not a simplified fraction because it can be simplified to "1/2".
Example 4:

Input: n = 1
Output: []
 

Constraints:

1 <= n <= 100

Sol1 Brute force:
Time O(n^2log(n) 
Space O(1)

Append anything that has GCD(a,b) == 1, each GCD take log(n) time, and total of n^2 iteration

Sol 2 HashMap
Time O(n^2)
Space O(n)

Since each not simplfied fraction must have appeared as simplied fraction before if we go from bottom up.
Hence if a value already in hashmap, then it is not simplified.
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class SimplifiedFraction
    {
        //static void Main()
        static void Main1447()
        {
            int n = 4;
            Console.Out.WriteLine(SimplifiedFractionsHashMap(n));
            Console.In.ReadLine();
        }

        public static IList<string> SimplifiedFractionsHashMap(int n)
        {
            List<string> ans = new List<string>();
            Dictionary<double, bool> dict = new Dictionary<double, bool>();
            if (n == 1)
                return ans;
            for (int i = 2; i <= n; i++)
            {                
                for (int j = 1; j <= i - 1; j++)
                {
                    double key = Math.Round((double)j / i, 15);
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, true);
                        ans.Add(j + "/" + i);
                    }
                }
            }
            return ans;
        }

        public static IList<string> SimplifiedFractions(int n)
        {
            List<string> ans = new List<string>();
            if (n == 1)
                return ans;
            for(int i = 2; i <= n; i++)
            {
                ans.Add(1 + "/" + i);
                for (int j = 2; j <= i - 1; j++)
                {                   
                    if (GCD(j, i) == 1)
                    {
                        ans.Add(j + "/" + i);
                    }
                }
            }
            return ans;
        }

        public static int GCD(int a, int b)
        {
            //assume a is the smaller value
            while (a > 0)
            {
                int temp = a;
                a = b % a;
                b = temp;
            }
            return b;
        }
    }
}
