using System;
/*
1465. Maximum Area of a Piece of Cake After Horizontal and Vertical Cuts

Given a rectangular cake with height h and width w, and two arrays of integers horizontalCuts and verticalCuts where horizontalCuts[i] is the distance from the top of the rectangular cake to the ith horizontal cut and similarly, verticalCuts[j] is the distance from the left of the rectangular cake to the jth vertical cut.

Return the maximum area of a piece of cake after you cut at each horizontal and vertical position provided in the arrays horizontalCuts and verticalCuts. Since the answer can be a huge number, return this modulo 10^9 + 7.

Example 1:

Input: h = 5, w = 4, horizontalCuts = [1,2,4], verticalCuts = [1,3]
Output: 4 
Explanation: The figure above represents the given rectangular cake. Red lines are the horizontal and vertical cuts. After you cut the cake, the green piece of cake has the maximum area.
Example 2:

Input: h = 5, w = 4, horizontalCuts = [3,1], verticalCuts = [1]
Output: 6
Explanation: The figure above represents the given rectangular cake. Red lines are the horizontal and vertical cuts. After you cut the cake, the green and yellow pieces of cake have the maximum area.
Example 3:

Input: h = 5, w = 4, horizontalCuts = [3], verticalCuts = [3]
Output: 9
 
Constraints:

2 <= h, w <= 10^9
1 <= horizontalCuts.length < min(h, 10^5)
1 <= verticalCuts.length < min(w, 10^5)
1 <= horizontalCuts[i] < h
1 <= verticalCuts[i] < w
It is guaranteed that all elements in horizontalCuts are distinct.
It is guaranteed that all elements in verticalCuts are distinct.

Sol Sort
Time O(nlog(n))
Space O(1)
Sort each each, find maximum gap, return product of max gaps mod 10^9+7
 */
namespace LeetCodePractice.Geeky
{
    class LargestCake
    {
        //static void Main()
        static void Main1465()
        {
            int h = 5, w = 4;
            int[] hCuts = { 3,1};
            int[] vCuts = { 3 };            
            Console.Out.WriteLine(MaxArea(h, w, hCuts, vCuts));
            Console.In.ReadLine();
        }
        public static int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {            
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            int max_h = Math.Max(horizontalCuts[0], h - horizontalCuts[horizontalCuts.Length - 1]);
            int max_v = Math.Max(verticalCuts[0], w - verticalCuts[verticalCuts.Length - 1]);
            for (int i = 0; i < horizontalCuts.Length - 1; ++i)
                max_h = Math.Max(max_h, horizontalCuts[i + 1] - horizontalCuts[i]);
            for (int i = 0; i < verticalCuts.Length - 1; ++i)
                max_v = Math.Max(max_v, verticalCuts[i + 1] - verticalCuts[i]);
            return (int)((long)max_h * max_v % 1000000007);
        }
    }
}
