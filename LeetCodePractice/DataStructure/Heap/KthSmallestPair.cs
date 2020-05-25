using System;
using System.Collections.Generic;

namespace LeetCodePractice.DataStructure.Heap
{
	/*
	You are given an m * n matrix, mat, and an integer k, which has its rows sorted in non-decreasing order.
	You are allowed to choose exactly 1 element from each row to form an array. Return the Kth smallest array sum among all possible arrays.

	Example 1:

	Input: mat = [[1,3,11],[2,4,6]], k = 5
	Output: 7
	Explanation: Choosing one element from each row, the first k smallest sum are:
	[1,2], [1,4], [3,2], [3,4], [1,6]. Where the 5th sum is 7.  
	Example 2:

	Input: mat = [[1,3,11],[2,4,6]], k = 9
	Output: 17
	Example 3:

	Input: mat = [[1,10,10],[1,4,5],[2,3,6]], k = 7
	Output: 9
	Explanation: Choosing one element from each row, the first k smallest sum are:
	[1,1,2], [1,1,3], [1,4,2], [1,4,3], [1,1,6], [1,5,2], [1,5,3]. Where the 7th sum is 9.  
	Example 4:

	Input: mat = [[1,1,10],[2,2,9]], k = 7
	Output: 12

	Constraints:

	m == mat.length
	n == mat.length[i]
	1 <= m, n <= 40
	1 <= k <= min(200, n ^ m)
	1 <= mat[i][j] <= 5000
	mat[i] is a non decreasing array.

	Sol Pruning
	Time O(n*m*k^2log(k))
	Space O(k)
	Merge all rows and only keep first k smallest pairs
	Sort after each merge
	*/
	class KthSmallestPair
    {
        //static void Main()
        static void Main1439()
        {			
            int[][] mat = { new int[] {1,1,10 },
                            new int[] {2,2,9 } };
            int k = 7;
            Console.Out.WriteLine(KthSmallest(mat, k));
            Console.In.ReadLine();
        }
        public static int KthSmallest(int[][] mat, int k)
        {
			List<int> currentSum = new List<int>();

			for (int i = 0; i < mat[0].Length; i++)
			{
				currentSum.Add(mat[0][i]);
			}

			RemoveExtra(currentSum, k);

			for (int i = 1; i < mat.Length; i++)
			{
				List<int> nextSum = new List<int>();

				for (int j = 0; j < mat[0].Length; j++)
				{
					foreach (var sum in currentSum)
					{
						nextSum.Add(sum + mat[i][j]);
					}
				}
				nextSum.Sort();
				RemoveExtra(nextSum, k);
				currentSum = nextSum;
			}
			
			return currentSum[k - 1];
		}

		public static void RemoveExtra(List<int> arr, int k)
		{
			while (arr.Count > k)
			{
				arr.RemoveAt(arr.Count - 1);
			}
		}
    }
}
