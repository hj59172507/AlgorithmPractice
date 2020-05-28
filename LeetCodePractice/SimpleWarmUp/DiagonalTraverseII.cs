using System;
using System.Collections.Generic;

/*
Given a list of lists of integers, nums, return all elements of nums in diagonal order as shown in the below images.

Example 1:
Input: nums = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,4,2,7,5,3,8,6,9]
Example 2:

Input: nums = [[1,2,3,4,5],[6,7],[8],[9,10,11],[12,13,14,15,16]]
Output: [1,6,2,8,7,3,9,4,12,10,5,13,11,14,15,16]
Example 3:

Input: nums = [[1,2,3],[4],[5,6,7],[8],[9,10,11]]
Output: [1,4,2,5,3,8,6,9,7,10,11]
Example 4:

Input: nums = [[1,2,3,4,5,6]]
Output: [1,2,3,4,5,6]
 
Constraints:

1 <= nums.length <= 10^5
1 <= nums[i].length <= 10^5
1 <= nums[i][j] <= 10^9
There at most 10^5 elements in nums.

Sol Use sorted dictionary to put every entry in place
Time O(nlog(n)
Space O(n)
From last row to first, each entry is order by their col + row
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class DiagonalTraverseII
    {
        //static void Main()
        static void Main1424()
        {
            List<IList<int>> nums = new List<IList<int>>() { new List<int>() { 1,2,3,4,5},
                                                            new List<int>() { 6,7},
                                                            new List<int>() { 8},
                                                            new List<int>() { 9,10,11},
                                                            new List<int>() { 12,13,14,15,16}};
            Console.Out.WriteLine(FindDiagonalOrder(nums));
            Console.In.ReadLine();
        }
        public static int[] FindDiagonalOrder(IList<IList<int>> nums)
        {
            List<int> ans = new List<int>();
            SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();
            for(int i = nums.Count-1; i >=0; i--)
            {
                for(int j = 0; j < nums[i].Count; j++)
                {
                    if (dict.ContainsKey(i + j))
                    {
                        dict[i + j].Add(nums[i][j]);
                    }
                    else
                    {
                        dict[i + j] = new List<int>() { nums[i][j]};
                    }
                }
            }

            foreach(int k in dict.Keys)
            {
                ans.AddRange(dict[k]);
            }
            return ans.ToArray();
        }
    }
}
