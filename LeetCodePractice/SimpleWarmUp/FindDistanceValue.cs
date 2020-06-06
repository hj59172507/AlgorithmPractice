/*
Given two integer arrays arr1 and arr2, and the integer d, return the distance value between the two arrays.

The distance value is defined as the number of elements arr1[i] such that there is not any element arr2[j] where |arr1[i]-arr2[j]| <= d.

Example 1:

Input: arr1 = [4,5,8], arr2 = [10,9,1,8], d = 2
Output: 2
Explanation: 
For arr1[0]=4 we have: 
|4-10|=6 > d=2 
|4-9|=5 > d=2 
|4-1|=3 > d=2 
|4-8|=4 > d=2 
For arr1[1]=5 we have: 
|5-10|=5 > d=2 
|5-9|=4 > d=2 
|5-1|=4 > d=2 
|5-8|=3 > d=2
For arr1[2]=8 we have:
|8-10|=2 <= d=2
|8-9|=1 <= d=2
|8-1|=7 > d=2
|8-8|=0 <= d=2
Example 2:

Input: arr1 = [1,4,2,3], arr2 = [-4,-3,6,10,20,30], d = 3
Output: 2
Example 3:

Input: arr1 = [2,1,100,3], arr2 = [-5,-2,10,-3,7], d = 6
Output: 1
 
Constraints:

1 <= arr1.length, arr2.length <= 500
-10^3 <= arr1[i], arr2[j] <= 10^3
0 <= d <= 100

Sol Hack
O(md) m: length of arr2, d: distance
If we map each element in arr2 and both d more and d less value to true, we can query element in arr1 in O(1), only do able beacuse the constrains.

Sol Binary search
O(nlogm) + O(mlogm)
Sort arr2, and use a variant of binary search that return true if we can't find a value that is d distance away from all elements in m
 */
namespace LeetCodePractice.SimpleWarmUp
{
    class FindDistanceValue
    {
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            bool[] map = new bool[6200];
            foreach (int i in arr2)
            {
                map[i + 3000] = true;
                for (int up = 1, down = -1; up <= d; ++up, --down)
                {
                    map[i + 3000 + up] = true;
                    map[i + 3000 + down] = true;
                }
            }
            int ans = 0;
            foreach (int i in arr1)
            {
                if (!map[i + 3000]) ans++;
            }
            return ans;
        }
    }
}
