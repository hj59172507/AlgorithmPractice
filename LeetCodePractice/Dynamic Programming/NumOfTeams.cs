using System;
using System.Linq;
/*
There are n soldiers standing in a line. Each soldier is assigned a unique rating value.

You have to form a team of 3 soldiers amongst them under the following rules:

Choose 3 soldiers with index (i, j, k) with rating (rating[i], rating[j], rating[k]).
A team is valid if:  (rating[i] < rating[j] < rating[k]) or (rating[i] > rating[j] > rating[k]) where (0 <= i < j < k < n).
Return the number of teams you can form given the conditions. (soldiers can be part of multiple teams).

Example 1:

Input: rating = [2,5,3,4,1]
Output: 3
Explanation: We can form three teams given the conditions. (2,3,4), (5,4,1), (5,3,1). 
Example 2:

Input: rating = [2,1,3]
Output: 0
Explanation: We can't form any team given the conditions.
Example 3:

Input: rating = [1,2,3,4]
Output: 4
 

Constraints:

n == rating.length
1 <= n <= 200
1 <= rating[i] <= 10^5

-------------------------------------------------------------------------------------

Solution 1 Brute force:
Time O(n^3)
Space O(1)
3 loops to search for all possible 3 number combination:

int result = 0;
int n = rating.Length;
for(int i=0; i<n; i++)
{
    for(int j=0; j<i; j++)
    {
        if(rating[i] < rating[j])
        {
            for(int k=0; k < j; k++)
            {
                if (rating[j] < rating[k])
                    result++;
            }
        }
        if (rating[i] > rating[j])
        {
            for (int k = 0; k < j; k++)
            {
                if (rating[j] > rating[k])
                    result++;
            }
        }
    }
}
return result;

Solution 2 DP: 
Time O(n^2)
Space O(n)

Compute array a such as a[i] stand for number of value smaller than ith rating.
When we find a rating[i] > rating[j], add 1 to a[i], and sum up a[j] as number of result.


*/

namespace LeetCodePractice.Dynamic_Programming
{
    class NumOfTeams
    {
        //static void Main()
        static void Main1395()
        {
            int[] rating = { 2, 5, 3, 4, 1 };
            Console.Out.WriteLine(NumTeams(rating));
            Console.In.ReadLine();
        }
        public static int NumTeams(int[] rating)
        {            
            int n = rating.Length;
            int[] reverseRating = rating.Reverse().ToArray();
            return NumTeamsOneWay(rating) + NumTeamsOneWay(reverseRating);
        }

        public static int NumTeamsOneWay(int[] rating)
        {
            int result = 0;
            int n = rating.Length;
            int[] gtCount = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (rating[i] > rating[j])
                    {
                        gtCount[i]++;
                        result += gtCount[j];
                    }
                }
            }
            return result;
        }
    }
}
