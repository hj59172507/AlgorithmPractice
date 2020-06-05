using System;
using System.Collections.Generic;
/*
Given an array w of positive integers, where w[i] describes the weight of index i, write a function pickIndex which randomly picks an index in proportion to its weight.

1 <= w.length <= 10000
1 <= w[i] <= 10^5
pickIndex will be called at most 10000 times.
Example 1:

Input: 
["Solution","pickIndex"]
[[[1]],[]]
Output: [null,0]
Example 2:

Input: 
["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
[[[1,3]],[],[],[],[],[]]
Output: [null,0,1,1,1,0]
Explanation of Input Syntax:

The input is two lists: the subroutines called and their arguments. Solution's constructor has one argument, the array w. pickIndex has no arguments. Arguments are always wrapped with a list, even if there aren't any.

Sol
Let wi[i] store the prefix sum of w[i]
Use binary search to find which index should we return in log(n) time
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class RandomPickWithWeight
    {
        static void Main()
        //static void Main2020June5()
        {
            RandomPickWithWeight r = new RandomPickWithWeight(new int[]{ 1,2,3,4,5 });
            for(int i = 0; i < 15; ++i)
            {
                Console.Out.WriteLine(r.PickIndex());
            }
            Console.In.ReadLine();
        }
        int sum = 0;
        Random r;
        List<int> weightedIndex;
        public RandomPickWithWeight(int[] w)
        {
            weightedIndex = new List<int>();
            for(int i=0;i<w.Length;i++)
            {
                sum += w[i];
                weightedIndex.Add(sum - 1);
            }
            r = new Random();
        }

        public int PickIndex()
        {
            int target = r.Next(sum), left = 0, right = weightedIndex.Count - 1, mid = 0;
            while(left <= right)
            {
                mid = (left + right + 1) / 2;
                if (mid == 0 || (target > weightedIndex[mid-1] && target <= weightedIndex[mid])) return mid;
                if (target > weightedIndex[mid]) left = mid + 1;
                else right = mid - 1;                
            }
            return mid;
        }
    }
}
