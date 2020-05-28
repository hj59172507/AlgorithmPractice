using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given three integers n, m and k. Consider the following algorithm to find the maximum element of an array of positive integers:

You should build the array arr which has the following properties:

arr has exactly n integers.
1 <= arr[i] <= m where (0 <= i < n).
After applying the mentioned algorithm to arr, the value search_cost is equal to k.
Return the number of ways to build the array arr under the mentioned conditions. As the answer may grow large, the answer must be computed modulo 10^9 + 7.

Example 1:

Input: n = 2, m = 3, k = 1
Output: 6
Explanation: The possible arrays are [1, 1], [2, 1], [2, 2], [3, 1], [3, 2] [3, 3]
Example 2:

Input: n = 5, m = 2, k = 3
Output: 0
Explanation: There are no possible arrays that satisify the mentioned conditions.
Example 3:

Input: n = 9, m = 1, k = 1
Output: 1
Explanation: The only possible array is [1, 1, 1, 1, 1, 1, 1, 1, 1]
Example 4:

Input: n = 50, m = 100, k = 25
Output: 34549172
Explanation: Don't forget to compute the answer modulo 1000000007
Example 5:

Input: n = 37, m = 17, k = 7
Output: 418930126
 
Constraints:

1 <= n <= 50
1 <= m <= 100
0 <= k <= n

Sol DP
Time O(nmk)
Space O(nmk)
Let dp[n,m,k] store number of array with length n, max value m, and k greater than

 */
namespace LeetCodePractice.Geeky
{
    class NOWBuildingArr
    {
        //static void Main()
        static void Main1420()
        {
            int n = 2, m = 3, k = 1;
            //int n = 37, m = 17, k = 7;
            //int n = 50, m = 100, k = 25;
            Console.Out.WriteLine(NumOfArrays(n,m,k));
            Console.In.ReadLine();
        }
        public const int MOD = (int)1e9 + 7;
        public static int NumOfArrays(int n, int m, int k)
        {
            if (m < k || n < k) return 0;
            long ans = 0;
            long[,,] dp = new long[n + 1, m + 1, k+1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    //length = 1
                    if (j > 1) dp[1,i,j] = 0; //k > 1, no solution
                    else dp[1,i,j] = 1;//1 solution 
                }
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    //m or max value  = 1
                    if (j > 1) dp[i, 1, j] = 0; //k > 1, no solution
                    else dp[i, 1, j] = 1;//1 solution 
                }
            }
            for (int i = 2; i <= n; i++)
            {
                for (int j = 2; j <= m; j++)
                {
                    for (int z = 1; z <= k; z++)
                    {
                        dp[i, j, z] = (dp[i, j, z] + dp[i - 1, j, z] * j) % MOD;
                        for(int x = 1; x < j; x++)
                        {
                            dp[i, j, z] = (dp[i, j, z] + dp[i - 1, x, z - 1]) % MOD;
                        }
                    }
                }
            }
            for (int i = 1; i <= m; i++)
                ans += dp[n, i, k];

            return (int)(ans%MOD);
        }

        /*
         * Wrong answer, couldn't figure out why.
         * let dp[i,j] be number of way to construct array of length i using j values(int from 1 to j)
         * Then sum up for all possible position of k and all possible value of k at given postion, the number of way to construct array before k and after k
            if (m < k || n < k) return 0;
            long ans = 0;
            long[,] dp = new long[n+1, m+1];
            for(int i = 1; i <= m; i++)
            {
                dp[1, i] = i;                
            }
            for (int i = 1; i <= n; i++)
            {
                dp[i, 1] = 1;
            }
            for (int i = 2; i <= n; i++)
            {
                for(int j = 2; j <= m; j++)
                {
                    dp[i, j] = (dp[i - 1, j] + dp[i, j - 1])%MOD;
                }
            }            
            for(int pos = k; pos <= n; pos++)
            {
                for (int val = k; val <= m; val++)
                {          
                    ans = (ans + Math.Max(dp[pos - 1, val - 1],1)* Math.Max(dp[n - pos, val],1)) % MOD;
                }
                if (k == 1)
                    break;
            }
            return (int)ans;
         */
    }
}
