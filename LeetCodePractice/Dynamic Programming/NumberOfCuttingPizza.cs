using System;
/*
Given a rectangular pizza represented as a rows x cols matrix containing the following characters: 'A' (an apple) and '.' (empty cell) and given the integer k. You have to cut the pizza into k pieces using k-1 cuts. 

For each cut you choose the direction: vertical or horizontal, then you choose a cut position at the cell boundary and cut the pizza into two pieces. If you cut the pizza vertically, give the left part of the pizza to a person. If you cut the pizza horizontally, give the upper part of the pizza to a person. Give the last piece of pizza to the last person.

Return the number of ways of cutting the pizza such that each piece contains at least one apple. Since the answer can be a huge number, return this modulo 10^9 + 7.

Example 1:

Input: pizza = ["A..","AAA","..."], k = 3
Output: 3 
Explanation: The figure above shows the three ways to cut the pizza. Note that pieces must contain at least one apple.
Example 2:

Input: pizza = ["A..","AA.","..."], k = 3
Output: 1
Example 3:

Input: pizza = ["A..","A..","..."], k = 1
Output: 1
 
Constraints:

1 <= rows, cols <= 50
rows == pizza.length
cols == pizza[i].length
1 <= k <= 10
pizza consists of characters 'A' and '.' only.

Sol DP:
Time O(r^2*c^2*k)
Space O(r*c*k)

Let sum[i][j] be the number of apples from i to r rows and j to c columns
Let dp[r][c][k] be the number of way to cut pizza with r rows, c columns, and into k pieces with each pices have at least one apple
Return dp[0][0][k]
*/
namespace LeetCodePractice.Dynamic_Programming
{
    class NumberOfCuttingPizza
    {
        //static void Main()
        static void Main1444()
        {
            string[] pizza = new string[] { "A..", "AAA", "..." };
            int k = 3;
            Console.Out.WriteLine(Ways(pizza,k));
            Console.In.ReadLine();
        }
        public static int Ways(string[] pizza, int k)
        {
            const int mod = (int)1e9 + 7;
            int row = pizza.Length, col = pizza[0].Length;
            int[,] sum = new int[row+1, col+1];
            int[,,] dp = new int[row+1, col+1, k+1];

            //calculate sum of apples
            for (int i = row - 1; i >= 0; --i)
            {
                int s = 0;
                for(int j = col - 1; j >= 0; --j)
                {
                    s += pizza[i][j] == 'A' ? 1 : 0;
                    sum[i, j] = sum[i + 1, j] + s;
                }
            }

            for (int i = row - 1; i >= 0; --i)
            {
                for (int j = col - 1; j >= 0; --j)
                {
                    dp[i, j, 1] = 1;
                    for(int x = 2; x <= k; ++x)
                    {
                        for(int t = i+1; t<row; ++t) 
                        {
                            if (sum[t, j] == 0)
                                break;
                            if (sum[i, j] > sum[t, j])
                            {
                                dp[i, j, x] = (dp[i, j, x] + dp[t, j, x - 1]) % mod;
                            }                                                                                    
                        }
                        for (int t = j+1; t < col; t++)
                        {
                            if (sum[i, t] == 0)
                                break;
                            if (sum[i, j] > sum[i, t])
                            {
                                dp[i, j, x] = (dp[i, j, x] + dp[i, t, x - 1]) % mod;
                            }
                        }
                    }
                }
            }
            return dp[0, 0, k];
        }
    }
}
