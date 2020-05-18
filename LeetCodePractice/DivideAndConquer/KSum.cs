using System;
using System.Collections.Generic;

/*
Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.

Note:

The solution set must not contain duplicate quadruplets.

Example:

Given array nums = [1, 0, -1, 0, -2, 2], and target = 0.

A solution set is:
[
  [-1,  0, 0, 1],
  [-2, -1, 1, 2],
  [-2,  0, 0, 2]
]

Sol1:
Generalized to k-sum problem
Time O(n^(k-1)
Space O(1)

1. Sort the array
2. Recursively reduce the problem until we are finding 2 number with a sum
3. Since array is sorted, we can easily find target if exist in one loop using low and high pointer
 */
namespace LeetCodePractice.DivideAndConquer
{
	class KSum
    {
		//static void Main()
		static void Main18()
		{
			int[] nums = new int[] { 1, 2, 4, 8, 16, 32, 64, 128 };
			int target = 82;
			Console.Out.WriteLine(FourSum(nums, target));
			Console.In.ReadLine();
		
		}
		public static IList<IList<int>> FourSum(int[] nums, int target)
		{
			Array.Sort(nums);
			return kSum(nums, 0, 4, target);
		}

		public static IList<IList<int>> kSum(int[] nums, int start, int k, int target)
		{
			int len = nums.Length;
			IList<IList<int>> res = new List<IList<int>>();
			if (k == 2)
			{
				int left = start, right = len - 1;
				while (left < right)
				{
					int sum = nums[left] + nums[right];
					if (sum == target)
					{
						res.Add((new List<int> { nums[left], nums[right] }));
						while (left < right && nums[left] == nums[left + 1]) left++;
						while (left < right && nums[right] == nums[right - 1]) right--;
						left++;
						right--;
					}
					else if (sum < target) left++;
					else right--;
				}
			}
			else
			{
				for (int i = start; i < len - k + 1; i++)
				{
					while (i > start && i < len - 1 && nums[i] == nums[i - 1]) { i++; };
					var temp = kSum(nums, i + 1, k - 1, target - nums[i]);
					foreach (var element in temp)
					{
						element.Add(nums[i]);
					}
					foreach (var val in temp)
					{
						res.Add(val);
					}
				}
			}

			return res;
		}
	}
}
