using System;

/*
1411. Number of Ways to Paint N × 3 Grid
You have a grid of size n x 3 and you want to paint each cell of the grid with exactly one of the three colours: Red, Yellow or Green while making sure that no two adjacent cells have the same colour (i.e no two cells that share vertical or horizontal sides have the same colour).

You are given n the number of rows of the grid.

Return the number of ways you can paint this grid. As the answer may grow large, the answer must be computed modulo 10^9 + 7.

Example 1:

Input: n = 1
Output: 12
Explanation: There are 12 possible way to paint the grid as shown:

Example 2:

Input: n = 2
Output: 54
Example 3:

Input: n = 3
Output: 246
Example 4:

Input: n = 7
Output: 106494
Example 5:

Input: n = 5000
Output: 30228214
 
Constraints:

n == grid.length
grid[i].length == 3
1 <= n <= 5000

Sol 
Time O(n)
Space O(1)
1. There are 12 ways to paint n=1, where 6 of them have 2 color, and 6 of them have 3 color.
2. For 2 color configuration, the next layer can only have 5 ways to paint, and 3 of them have 2 colors, 2 of them have 3 colors.
3. For 3 color configuration, the next layer can only have 4 ways to paint, and 2 of them have 2 colors, 2 of them have 3 colors.
Use this rule to calculate final result.
 */
namespace LeetCodePractice.Greedy
{
    class NumberOfWaysToPaintGrid
    {
        //static void Main()
        static void Main1411()
        {
            int n = 5000;
            Console.Out.WriteLine(NumOfWays(n));
            Console.In.ReadLine();
        }
        public static int NumOfWays(int n)
        {
            long color2 = 6, color3 = 6;
            int ans = 12, MOD = (int)1e9+7;            
            while(n > 1)
            {
                long temp2 = 3 * color2 % MOD + 2 * color3 % MOD;
                long temp3 = 2 * color2 % MOD + 2 * color3 % MOD;
                color2 = temp2; 
                color3 = temp3;
                ans = (int)((color2 + color3) % MOD);
                n--;
            }
            return ans;
        }
    }
}
