using System;
using System.Collections.Generic;
using System.Linq;
/*
1386. Cinema Seat Allocation
A cinema has n rows of seats, numbered from 1 to n and there are ten seats in each row, labelled from 1 to 10 as shown in the figure above.

Given the array reservedSeats containing the numbers of seats already reserved, for example, reservedSeats[i] = [3,8] means the seat located in row 3 and labelled with 8 is already reserved.

Return the maximum number of four-person groups you can assign on the cinema seats. A four-person group occupies four adjacent seats in one single row.
Seats across an aisle (such as [3,3] and [3,4]) are not considered to be adjacent, but there is an exceptional case on which an aisle split a four-person group, 
in that case, the aisle split a four-person group in the middle, which means to have two people on each side.

Example 1:

Input: n = 3, reservedSeats = [[1,2],[1,3],[1,8],[2,6],[3,1],[3,10]]
Output: 4
Explanation: The figure above shows the optimal allocation for four groups, where seats mark with blue are already reserved and contiguous seats mark with orange are for one group.
Example 2:

Input: n = 2, reservedSeats = [[2,1],[1,8],[2,6]]
Output: 2
Example 3:

Input: n = 4, reservedSeats = [[4,3],[1,4],[4,6],[1,7]]
Output: 4
 
Constraints:

1 <= n <= 10^9
1 <= reservedSeats.length <= min(10*n, 10^4)
reservedSeats[i].length == 2
1 <= reservedSeats[i][0] <= n
1 <= reservedSeats[i][1] <= 10
All reservedSeats[i] are distinct.

Sol
Time O(n)
Space O(n)
Map row to list of int with 2 value, first is 0 if seat 2-5 is reserved, second value is 0 if 4-7 is reserved, and third value is 0 if 6-9 is reserved. Can also use bitmap since max seat is 10.
For each row, if row not in map, add 2. Else, or 3 values and add the result.

 */
namespace LeetCodePractice.Greedy
{
    class MaxFamilyInCinema
    {
        //static void Main()
        static void Main1386()
        {
            int n = 2;
            int[][] seats = { new int[] { 2, 1 }, new int[] { 1, 8 }, new int[] { 2, 6 }};
            Console.Out.WriteLine(MaxNumberOfFamilies(n, seats));
            Console.In.ReadLine();
        }
        public static int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            int ans = 0;
            Dictionary<int, int> rowToSeats = new Dictionary<int, int>();

            foreach(int[] i in reservedSeats)
            {
                if (!rowToSeats.ContainsKey(i[0]))
                {
                    if (i[1] < 2 || i[1] > 9) continue;
                    rowToSeats[i[0]] = 1 << i[1];
                }
                else
                {
                    rowToSeats[i[0]] = rowToSeats[i[0]] | 1 << i[1];
                }                    
            }
            ans += 2 * (n - rowToSeats.Count());
            foreach (int i in rowToSeats.Keys)
            {
                int cnt = 0;
                if ( (rowToSeats[i] & 60) == 0) cnt++;
                if ( (rowToSeats[i] & 960) == 0) cnt++;
                if ( (rowToSeats[i] & 240) == 0 && cnt == 0) cnt++;
                ans += cnt;
            }
            return ans;
        }
    }
}
