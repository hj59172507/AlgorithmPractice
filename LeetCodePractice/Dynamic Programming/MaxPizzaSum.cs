using System;
/*
1388. Pizza With 3n Slices

There is a pizza with 3n slices of varying size, you and your friends will take slices of pizza as follows:

You will pick any pizza slice.
Your friend Alice will pick next slice in anti clockwise direction of your pick. 
Your friend Bob will pick next slice in clockwise direction of your pick.
Repeat until there are no more slices of pizzas.
Sizes of Pizza slices is represented by circular array slices in clockwise direction.

Return the maximum possible sum of slice sizes which you can have.

Example 1:

Input: slices = [1,2,3,4,5,6]
Output: 10
Explanation: Pick pizza slice of size 4, Alice and Bob will pick slices with size 3 and 5 respectively. Then Pick slices with size 6, finally Alice and Bob will pick slice of size 2 and 1 respectively. Total = 4 + 6.
Example 2:

Input: slices = [8,9,8,6,1,1]
Output: 16
Output: Pick pizza slice of size 8 in each turn. If you pick slice with size 9 your partners will pick slices of size 8.
Example 3:

Input: slices = [4,1,2,5,8,3,1,9,7]
Output: 21
Example 4:

Input: slices = [3,1,2]
Output: 3
 
Constraints:

1 <= slices.length <= 500
slices.length % 3 == 0
1 <= slices[i] <= 1000

Sol
Time O(mn)
Space O(mn) Since each new element only depend on two previous value, we can reduce this to O(m)
We are to select n number from array of 3n numbers such that not number are next to each other.
We split the circle array into arr1 from 0 to n-1, and arr2 from 1 to n, then we only dealing with linear array.
Let dp[i,j] be max sum of picking j element from first i element, compute this for both arr1 and arr2. Return max between them as answer.
 */
namespace LeetCodePractice.Dynamic_Programming
{
    class MaxPizzaSum
    {   
        //static void Main()
        static void Main1388()
        {
            int[] slices = {1,2,3,4,5,6 };
            Console.Out.WriteLine(MaxSizeSlices(slices));
            Console.In.ReadLine();
        }
        public static int MaxSizeSlices(int[] slices)
        {
            int m = slices.Length;
            int[] arr1 = new int[m - 1], arr2 = new int[m - 1];
            Array.Copy(slices, 0, arr1, 0, m - 1);
            Array.Copy(slices, 1, arr2, 0, m - 1);            
            return Math.Max(DFS(arr1, m / 3), DFS(arr2, m / 3));
        }

        static int DFS(int[] slices, int n)
        {
            int m = slices.Length;
            int[,] dp = new int[m + 1, n + 1];
            for(int i = 1; i <= m; ++i)
            {
                for(int j = 1; j <= n; ++j)
                {
                    if (i == 1) dp[i, j] = slices[0];
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 2, j - 1] + slices[i-1]);
                    }
                }
            }
            return dp[m, n];
        }
    }
}
