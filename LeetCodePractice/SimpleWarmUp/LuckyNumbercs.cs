using System.Collections.Generic;

/*
1380. Lucky Numbers in a Matrix

Given a m * n matrix of distinct numbers, return all lucky numbers in the matrix in any order.

A lucky number is an element of the matrix such that it is the minimum element in its row and maximum in its column.

Example 1:

Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
Output: [15]
Explanation: 15 is the only lucky number since it is the minimum in its row and the maximum in its column
Example 2:

Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
Output: [12]
Explanation: 12 is the only lucky number since it is the minimum in its row and the maximum in its column.
Example 3:

Input: matrix = [[7,8],[1,2]]
Output: [7]
 

Constraints:

m == mat.length
n == mat[i].length
1 <= n, m <= 50
1 <= matrix[i][j] <= 10^5.
All elements in the matrix are distinct.

Sol
Time O(n)
Space O(1)
Notice that since all element is unique, there can only be one answer if there is any

 */
namespace LeetCodePractice.SimpleWarmUp
{
    class LuckyNumbercs
    {
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            int liRow = -1;
            int liCol = -1;

            for (int i = 0; i < matrix.Length; ++i)
            {
                int col = 0;
                for (int j = 1; j < matrix[i].Length; ++j)
                {
                    if (matrix[i][j] < matrix[i][col])
                        col = j;
                }

                if (liRow == -1 || matrix[liRow][liCol] < matrix[i][col])
                {
                    liRow = i;
                    liCol = col;
                }
            }

            for (int i = 0; i < matrix.Length; ++i)
            {
                if (matrix[i][liCol] > matrix[liRow][liCol])
                    return new List<int>();
            }

            return new List<int>() { matrix[liRow][liCol] };
        }
    }
}
