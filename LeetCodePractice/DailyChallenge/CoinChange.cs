using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
You are given coins of different denominations and a total amount of money. Write a function to compute the number of combinations that make up that amount. You may assume that you have infinite number of each kind of coin.

Example 1:

Input: amount = 5, coins = [1, 2, 5]
Output: 4
Explanation: there are four ways to make up the amount:
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1
Example 2:

Input: amount = 3, coins = [2]
Output: 0
Explanation: the amount of 3 cannot be made up just with coins of 2.
Example 3:

Input: amount = 10, coins = [10] 
Output: 1
 

Note:

You can assume that

0 <= amount <= 5000
1 <= coin <= 5000
the number of coins is less than 500
the answer is guaranteed to fit into signed 32-bit integer

Sol BFS (time out)
if (sum == amount) return 1;
int ans = 0;
for(int j=i; j < coins.Length; ++j)
{
    if (sum + coins[j] <= amount) ans += BFS(amount, sum + coins[j], j, coins);
}
return ans;

Sol DP
Time O(amount*coins.len)
Space O(amount*coins.len)
Let dp[i,j] be the # of way to build amount i using first j coins.
If current coin c <= amount i, dp[i,j] = dp[i,j-1] //not using jth coin
                                        + dp[i-c,j] //use jth coin, and reduce the amount by value of jth coin
else dp[i,j] = dp[i,j-1]//can't use jth coin, so just using first j-1 coins
This is a bottom up solution, a top down solution might be faster since not all values are needed in the table.
 */
namespace LeetCodePractice.DailyChallenge
{
    class CoinChange
    {
        //static void Main()
        static void MainJune72020()
        {
            int amount = 10;
            int[] coins = {10};
            Console.Out.WriteLine(Change(amount, coins));
            Console.In.ReadLine();
        }
        public static int Change(int amount, int[] coins)
        {
            if (amount == 0) return 1;
            if (coins.Length == 0) return 0;
            Array.Sort(coins);
            int[,] dp = new int[amount + 1, coins.Length+1];            
            for (int i = 0; i < coins.Length + 1; ++i) dp[0, i] = 1;
            for (int i = 1; i < amount + 1; ++i) dp[i, 1] = i % coins[0] == 0 ? 1 : 0;
            for (int i = 1; i < amount + 1; ++i)
            {
                for (int j = 1; j < coins.Length + 1; ++j)
                {
                    if (coins[j-1] <= i) dp[i, j] = dp[i, j - 1] + dp[i - coins[j-1], j];
                    else dp[i, j] = dp[i, j - 1];
                }
            }
            return dp[amount, coins.Length];
        }
    }
}
