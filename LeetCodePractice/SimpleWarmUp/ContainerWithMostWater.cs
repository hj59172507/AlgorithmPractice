using System;

/*
 * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.

The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.

Example:

Input: [1,8,6,2,5,4,8,3,7]
Output: 49

Sol1:
Time O(n)
Space O(1)

We start with edge sides, left and right since it has most width. 
To increase amount of water, we discard the smaller side and move inward, each time calculating new water volumn. Thus total O(n) iteration.
Note that even if left height == right height, it doesn't matter which side we pick to move on. 
Since we need two side larger than original left and right, and another higher side will always be picked in future iteration.
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class ContainerWithMostWater
    {
        static void Main()
        //static void Main11()
        {
            int[] arr = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.Out.WriteLine(MaxArea(arr));
            Console.In.ReadLine();
        }
        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length-1, ans = 0;
            while(left < right)
            {
                ans = Math.Max(ans, (right - left) * Math.Min(left, right));
                if (height[left] > height[right])
                    right--;
                else
                    left++;                
            }
            return ans;
        }
    }
}
