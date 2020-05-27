using System;
using System.Collections.Generic;

/*
There are n people and 40 types of hats labeled from 1 to 40.

Given a list of list of integers hats, where hats[i] is a list of all hats preferred by the i-th person.

Return the number of ways that the n people wear different hats to each other.

Since the answer may be too large, return it modulo 10^9 + 7.

Example 1:

Input: hats = [[3,4],[4,5],[5]]
Output: 1
Explanation: There is only one way to choose hats given the conditions. 
First person choose hat 3, Second person choose hat 4 and last one hat 5.
Example 2:

Input: hats = [[3,5,1],[3,5]]
Output: 4
Explanation: There are 4 ways to choose hats
(3,5), (5,3), (1,3) and (1,5)
Example 3:

Input: hats = [[1,2,3,4],[1,2,3,4],[1,2,3,4],[1,2,3,4]]
Output: 24
Explanation: Each person can choose hats labeled from 1 to 4.
Number of Permutations of (1,2,3,4) = 24.
Example 4:

Input: hats = [[1,2,3],[2,3,5,6],[1,3,7,9],[1,8,9],[2,5,7]]
Output: 111
 

Constraints:

n == hats.length
1 <= n <= 10
1 <= hats[i].length <= 40
1 <= hats[i][j] <= 40
hats[i] contains a list of unique integers.

Sol DP with bit masking
n = number of hat, p = number of people
Time O(n*2^p*p)
Space O(n*2^p)
Let dp[i,j] store total way to assign i hats to j people
Loop from bottom up to find dp[n,p]
 */
namespace LeetCodePractice.Dynamic_Programming
{
    
    class WaysToAssignHats
    {
        //static void Main()
        static void Main1434()
        {
            List<IList<int>> hats = new List<IList<int>> { new List<int> { 1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,19,22,23,24,25,27,29,30,31,32,34,35,36,37,38,39,40 },
                                                           new List<int> { 3,4,6,8,9,10,12,15,16,17,20,21,22,23,24,27,28,29,30,31,32,33,34,36,37,38,39,40 },
                                                           new List<int>  { 3,7,9,11,12,13,14,16,18,19,20,21,22,23,29,30,31,32,35,36,39 },
                                                           new List<int>  { 2,5,6,7,8,9,10,12,15,36 },
                                                           new List<int>  { 2,3,5,6,8,9,12,13,17,26,27,28,32,33,39,40 },
                                                           new List<int>  {1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,37,38,39,40 },
                                                           new List<int>  {1,2,4,5,6,9,12,13,14,15,21,23,24,25,27,28,29,33,38 },
                                                           new List<int>  {4,11,13,14,15,19,20,22,24,31,38,39,40} };

            Console.Out.WriteLine(NumberWays(hats));           
            Console.In.ReadLine();                        
        }
        public const int MOD = ((int)1E9) + 7;
        public static int totalPeopleMask;
        public static List<int>[] availibleHats;
        public static int NumberWays(IList<IList<int>> hats)
        {
            int totalPeople = hats.Count;
            availibleHats = new List<int>[41];
            for (int i = 1; i <= 40; i++) availibleHats[i] = new List<int>();
            for (int i = 0; i < totalPeople; i++)
            {
                foreach(int hat in hats[i])
                {
                    availibleHats[hat].Add(i);
                }
            }
            
            totalPeopleMask = (1 << totalPeople) - 1;
            
            int?[,] dp = new int?[41, 1024];
            return recurAllPeople(1, 0, dp);
        }

        public static int recurAllPeople(int hat, int peopleMask, int?[,] dp)
        {
            if (peopleMask == totalPeopleMask)//everyone got a hat
                return 1;            
            if (hat > 40)//ran out of hats
                return 0;
            if (dp[hat, peopleMask] != null) return (int)dp[hat, peopleMask];
            int ans = recurAllPeople(hat + 1, peopleMask, dp);
            
            foreach (int p in availibleHats[hat])
            {
                if ((peopleMask & (1 << p)) == 0)//This person haven't got a hat
                {                    
                    ans += recurAllPeople(hat + 1, peopleMask | (1 << p), dp);
                    ans %= MOD;
                }
            }
            dp[hat, peopleMask] = ans % MOD;
            return (int)dp[hat, peopleMask];
        }
    }
}
