using System;
using System.Collections.Generic;
using System.Linq;
/*
There are 2N people a company is planning to interview. The cost of flying the i-th person to city A is costs[i][0], and the cost of flying the i-th person to city B is costs[i][1].

Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.

Example 1:

Input: [[10,20],[30,200],[400,50],[30,20]]
Output: 110
Explanation: 
The first person goes to city A for a cost of 10.
The second person goes to city A for a cost of 30.
The third person goes to city B for a cost of 50.
The fourth person goes to city B for a cost of 20.

The total minimum cost is 10 + 30 + 50 + 20 = 110 to have half the people interviewing in each city.
 
Note:

1 <= costs.length <= 100
It is guaranteed that costs.length is even.
1 <= costs[i][0], costs[i][1] <= 1000

Sol 
Time O(n)
Space O(n)
Sort all the difference is price, greatest difference get priority to chooes which city
 */
namespace LeetCodePractice.DataStructure.Sorted
{
    class CitySchedule
    {
        public int TwoCitySchedCost(int[][] costs)
        {
            SortedDictionary<int, List<int>> diff = new SortedDictionary<int, List<int>>();
            for(int i =0;i < costs.Length;i++)
            {
                int t = Math.Abs(costs[i][0] - costs[i][1]);
                if (diff.ContainsKey(t)) diff[t].Add(i);
                else diff[t] = new List<int>() { i };
            }
            int sum = 0, n = costs.Length/2, cityA = 0, cityB = 0;
            foreach(int key in diff.Keys.Reverse())
            {
                foreach(int i in diff[key])
                {
                    if (cityA == n)
                    {
                        sum += costs[i][1];
                        continue;
                    }
                    if (cityB == n)
                    {
                        sum += costs[i][0];
                        continue;

                    }
                    if (costs[i][0] > costs[i][1])
                    {
                        sum += costs[i][1];
                        cityB++;
                    }
                    else
                    {
                        sum += costs[i][0];
                        cityA++;
                    }
                }
            }
            return sum;
        }
    }
}
