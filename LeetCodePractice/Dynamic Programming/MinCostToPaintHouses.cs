using System;
/*
There is a row of m houses in a small city, each house must be painted with one of the n colors (labeled from 1 to n), some houses that has been painted last summer should not be painted again.

A neighborhood is a maximal group of continuous houses that are painted with the same color. (For example: houses = [1,2,2,3,3,2,1,1] contains 5 neighborhoods  [{1}, {2,2}, {3,3}, {2}, {1,1}]).

Given an array houses, an m * n matrix cost and an integer target where:

houses[i]: is the color of the house i, 0 if the house is not painted yet.
cost[i][j]: is the cost of paint the house i with the color j+1.
Return the minimum cost of painting all the remaining houses in such a way that there are exactly target neighborhoods, if not possible return -1.

Example 1:

Input: houses = [0,0,0,0,0], cost = [[1,10],[10,1],[10,1],[1,10],[5,1]], m = 5, n = 2, target = 3
Output: 9
Explanation: Paint houses of this way [1,2,2,1,1]
This array contains target = 3 neighborhoods, [{1}, {2,2}, {1,1}].
Cost of paint all houses (1 + 1 + 1 + 1 + 5) = 9.
Example 2:

Input: houses = [0,2,1,2,0], cost = [[1,10],[10,1],[10,1],[1,10],[5,1]], m = 5, n = 2, target = 3
Output: 11
Explanation: Some houses are already painted, Paint the houses of this way [2,2,1,2,2]
This array contains target = 3 neighborhoods, [{2,2}, {1}, {2,2}]. 
Cost of paint the first and last house (10 + 1) = 11.
Example 3:

Input: houses = [0,0,0,0,0], cost = [[1,10],[10,1],[1,10],[10,1],[1,10]], m = 5, n = 2, target = 5
Output: 5
Example 4:

Input: houses = [3,1,2,3], cost = [[1,1,1],[1,1,1],[1,1,1],[1,1,1]], m = 4, n = 3, target = 3
Output: -1
Explanation: Houses are already painted with a total of 4 neighborhoods [{3},{1},{2},{3}] different of target = 3.

Constraints:

m == houses.length == cost.length
n == cost[i].length
1 <= m <= 100
1 <= n <= 20
1 <= target <= m
0 <= houses[i] <= n
1 <= cost[i][j] <= 10^4

Sol 
Time O(m*n^2*target)
Space O(m*n*target)
Let dp[i,j,k] be min cost to paint first i house with ith house of jth color, and there is k neihjbors
Each i,j,k, we can pick if new neighbor should be created.
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class MinCostToPaintHouses
    { 
        //static void Main()
        static void Main1473()
        {
            int[] houses = { 0, 0, 0, 0, 0 };
            int[][] cost = { new int[] { 1, 10 }, new int[] { 10, 1 }, new int[] { 10, 1 }, new int[] { 1, 10 }, new int[] { 5, 1 } };
            int m = 5, n = 2, target = 3;
            Console.Out.WriteLine(MinCost(houses, cost, m, n, target));
            Console.In.ReadLine();
        }

        public static int MinCost(int[] houses, int[][] cost, int m, int n, int target)
        {            
            int[,,] dp = new int[m, n, target + 1];
            for (int i = 0; i < m; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    for(int k = 0; k <= target; ++k)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }
            int ans = PaintDFS(houses, cost, m, n, target, 0, 0, -1, dp);
            if (ans == MAX) return -1;
            return ans;
        }
        static int MAX = 100000000;
        static int PaintDFS(int[] houses, int[][] cost, int m, int n, int target, int currentHouse, int currentTarget, int lastColor, int[,,] dp)
        {
            if(currentHouse == m)
            {
                if (currentTarget == target) return 0;
                return MAX;
            }
            if (currentTarget > target) return MAX;
            if (lastColor != -1 && dp[currentHouse, lastColor, currentTarget] != -1) return dp[currentHouse, lastColor, currentTarget];
            int minCost = MAX;
            for(int color = 0; color < n; ++color)
            {
                bool painted = false;
                if(houses[currentHouse] != 0)
                {
                    //house already painted
                    if (houses[currentHouse] != color+1) continue;//can't repaint, so only process given color
                    painted = true;
                }
                if(color != lastColor)
                {
                    //new neighbor since color is different
                    minCost = Math.Min(minCost, PaintDFS(houses, cost, m, n, target, currentHouse + 1, currentTarget + 1, color, dp) + (painted ? 0 : cost[currentHouse][color]) );
                }
                else
                {
                    //same neighbor
                    minCost = Math.Min(minCost, PaintDFS(houses, cost, m, n, target, currentHouse + 1, currentTarget, color, dp) + (painted ? 0 : cost[currentHouse][color]));
                }
            }
            if (lastColor != -1) dp[currentHouse, lastColor, currentTarget] = minCost;
            return minCost;
        }
    }
}
