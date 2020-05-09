using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
There are n people whose IDs go from 0 to n - 1 and each person belongs exactly to one group.Given the array groupSizes of length n telling the group size each person belongs to, return the groups there are and the people's IDs each group includes.

You can return any solution in any order and the same applies for IDs.Also, it is guaranteed that there exists at least one solution. 




Example 1:

Input: groupSizes = [3, 3, 3, 3, 3, 1, 3]
Output: [[5], [0,1,2], [3,4,6]]
Explanation: 
Other possible solutions are[[2,1,6],[5],[0,4,3]] and[[5],[0,6,2],[4,3,1]].
Example 2:

Input: groupSizes = [2,1,3,3,3,2]
Output: [[1],[0,5],[2,3,4]]
 

Constraints:

groupSizes.length == n
1 <= n <= 500
1 <= groupSizes[i] <= n
*/

namespace LeetCodePractice.DataStructure.HashMap
{
    class GroupPeopleBySize
    {

        //static void Main()
        static void Main1282()
        {
            int[] input =  new int[] { 3, 3, 3, 3, 3, 1, 3 };
            Console.Out.WriteLine(GroupThePeople(input));
            Console.In.ReadLine();
        }

        public static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            IList<IList<int>> res = new List<IList<int>> { };
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            for (int i = 0; i < groupSizes.Length; i++)
            {
                int groupSize = groupSizes[i];
                if (map.ContainsKey(groupSize))
                {
                    if(map[groupSize][0] == map[groupSize].Count)
                    {
                        map[groupSize][0] = i;
                        res.Add(map[groupSize]);
                        map.Remove(groupSize);
                    }
                    else
                    {
                        map[groupSize].Add(i);
                    }
                }
                else if(groupSize == 1)
                {
                    res.Add(new List<int> { i });
                }
                else
                {
                    map.Add(groupSize, new List<int> { groupSize, i });
                }
            }
            return res;
        }
    }

}
