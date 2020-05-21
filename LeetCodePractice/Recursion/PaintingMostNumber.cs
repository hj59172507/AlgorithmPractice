using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/*
Given an array of integers cost and an integer target. Return the maximum integer you can paint under the following rules:

The cost of painting a digit (i+1) is given by cost[i] (0 indexed).
The total cost used must be equal to target.
Integer does not have digits 0.
Since the answer may be too large, return it as string.

If there is no way to paint any integer given the condition, return "0".

Example 1:

Input: cost = [4,3,2,5,6,7,2,5,5], target = 9
Output: "7772"
Explanation:  The cost to paint the digit '7' is 2, and the digit '2' is 3. Then cost("7772") = 2*3+ 3*1 = 9. You could also paint "997", but "7772" is the largest number.
Digit    cost
  1  ->   4
  2  ->   3
  3  ->   2
  4  ->   5
  5  ->   6
  6  ->   7
  7  ->   2
  8  ->   5
  9  ->   5
Example 2:

Input: cost = [7,6,5,5,5,6,8,7,8], target = 12
Output: "85"
Explanation: The cost to paint the digit '8' is 7, and the digit '5' is 5. Then cost("85") = 7 + 5 = 12.
Example 3:

Input: cost = [2,4,6,2,4,6,4,4,4], target = 5
Output: "0"
Explanation: It's not possible to paint any integer with total cost equal to target.
Example 4:

Input: cost = [6,10,15,40,40,40,40,40,40], target = 47
Output: "32211"
 

Constraints:

cost.length == 9
1 <= cost[i] <= 5000
1 <= target <= 5000

Sol DP:
Time O(T)
Space O(T)

Let arr[i] represent the maximum length of cost i could have. 
Then we only need to find from largest digit, such that its maximum length is always one less.

 */
namespace LeetCodePractice.Recursion
{
    class PaintingMostNumber
    {
        //static void Main()
        static void Main1449()
        {
            int target = 9;
            int[] cost = new int[] {4, 3, 2, 5, 6, 7, 2, 5, 5};
            Console.Out.WriteLine(LargestNumber(cost, target));
            Console.In.ReadLine();
        }
        public static string LargestNumber(int[] cost, int target)
        {
            int[] dp = new int[target+1];            
            for(int i = 1; i <= target; ++i)
            {
                dp[i] = -50001;
                for (int j = 0; j < cost.Length; ++j)
                {
                    if(cost[j] <= i)
                    {
                        dp[i] = Math.Max(dp[i], 1+dp[i - cost[j]]);
                    }
                }
            }
            if(dp[target] < 0)
                return "0";

            StringBuilder s = new StringBuilder();

            for(int j = 8; j >= 0; j--)
            {
                while(target >= cost[j] && dp[target] == dp[target-cost[j]]+1)
                {
                    s.Append(j+1);
                    target -= cost[j];
                }
            }
            return s.ToString();            
        }       
    }
}
