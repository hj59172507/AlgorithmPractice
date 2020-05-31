using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
A program was supposed to print an array of integers. The program forgot to print whitespaces and the array is printed as a string of digits and all we know is that all integers in the array were in the range [1, k] and there are no leading zeros in the array.

Given the string s and the integer k. There can be multiple ways to restore the array.

Return the number of possible array that can be printed as a string s using the mentioned program.

The number of ways could be very large so return it modulo 10^9 + 7

Example 1:

Input: s = "1000", k = 10000
Output: 1
Explanation: The only possible array is [1000]
Example 2:

Input: s = "1000", k = 10
Output: 0
Explanation: There cannot be an array that was printed this way and has all integer >= 1 and <= 10.
Example 3:

Input: s = "1317", k = 2000
Output: 8
Explanation: Possible arrays are [1317],[131,7],[13,17],[1,317],[13,1,7],[1,31,7],[1,3,17],[1,3,1,7]
Example 4:

Input: s = "2020", k = 30
Output: 1
Explanation: The only possible array is [20,20]. [2020] is invalid because 2020 > 30. [2,020] is ivalid because 020 contains leading zeros.
Example 5:

Input: s = "1234567890", k = 90
Output: 34
 

Constraints:

1 <= s.length <= 10^5.
s consists of only digits and doesn't contain leading zeros.
1 <= k <= 10^9.

Sol DP
Time O(slog(k)) For each digit, there is at most digits(k) iteration, then log k
Space O(s)
Let dp[i] = number of possible array using i letter from back 
dp[i] = sum(dp(i+j) where i+j <= s.length)
If digit we see is 0, skip it.
If digits > k, skip rest of the sum loop
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class RestoreTheArray
    {
        //static void Main()
        static void Main1416()
        {
            string s = "1234567890"; int k = 90;
            Console.Out.WriteLine(NumberOfArrays(s, k));
            Console.In.ReadLine();
        }
        public static int NumberOfArrays(string s, int k)
        {
            const int MOD = (int)1e9 + 7;
            int[] dp = new int[s.Length+1];
            dp[s.Length] = 1;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0') continue;
                long n = 0;
                for(int j = 1; j+i <= s.Length; j++)
                {
                    n = 10 * n + s[j + i - 1] - '0';
                    if (n > k)
                        break;
                    dp[i] = (dp[i] + dp[j + i]) % MOD;
                }
            }
            return dp[0];
        }
    }
}
    