using System;
using System.Collections.Generic;
using System.Linq;




/*
You have a very large square wall and a circular dartboard placed on the wall. You have been challenged to throw darts into the board blindfolded. Darts thrown at the wall are represented as an array of points on a 2D plane. 

Return the maximum number of points that are within or lie on any circular dartboard of radius r.

Example 1:

Input: points = [[-2,0],[2,0],[0,2],[0,-2]], r = 2
Output: 4
Explanation: Circle dartboard with center in (0,0) and radius = 2 contain all points.
Example 2:



Input: points = [[-3,0],[3,0],[2,6],[5,4],[0,9],[7,8]], r = 5
Output: 5
Explanation: Circle dartboard with center in (0,4) and radius = 5 contain all points except the point (7,8).
Example 3:

Input: points = [[-2,0],[2,0],[0,2],[0,-2]], r = 1
Output: 1
Example 4:

Input: points = [[1,2],[3,5],[1,-1],[2,3],[4,1],[1,3]], r = 2
Output: 4
 

Constraints:

1 <= points.length <= 100
points[i].length == 2
-10^4 <= points[i][0], points[i][1] <= 10^4
1 <= r <= 5000

Sol1 Brute Force:
Time O(n^3)
Space O(1)

Intuition: for a potential solution circle, it could have point on the circumference. 
We can define two circle that pass through two points if two points are distinct. 
Note: Discard pair of points if their distance is > 2r, for pair of point with exactly 2r distance, only one circle is formed
1. For a given point, pair it with all other points
2. Find the distance between point pair, define no circle(d > 2r), 1 circle(d == 2r) or 2 circles(d < 2r)
3. For any circle defined, count all the points within

Sol2 Angular Sweep:
Time O(n^2log(n))
Space O(n)

1. For each point p, and another point q from the list with distance d,
   find the angle between line pq and x axis using arctan2(qx-px, qy-py), and delta(span of angle form by q entry and exit point in the circle) using acos(d/2r) 
2. q's entry and exit angle in p's circle is define by angle - delta and angle + delta, store all entry and exit points for all possible q(if d > 2r, no entry possible)
3. Sort all angles and count entry as 1, exit as -1, find the maximum point given p on the circle, update the global answer when necessary
 
 */
namespace LeetCodePractice.Unclassified
{
    class MaximumNumberOfPointInCircle
    {
        //static void Main()
        static void Main1453()
        {                     
            int[][] points =  { new int [] {0,-2},
                                new int [] {2,0},
                                new int [] {-2,0},
                                new int [] {0,2},
                                   };
            int r = 2;
            Console.Out.WriteLine(NumPoints(points, r));
            Console.In.ReadLine();
        }


        public static int NumPoints(int[][] points, int r)
        {
            int ans = 1;
            foreach(int[] p in points)
            {
                SortedDictionary<double, int[]> angles = new SortedDictionary<double, int[]>();
                foreach(int[] q in points)
                {
                    double d = Distance(p, q);
                    if(p != q && d <= 2*r)
                    {
                        double angle = Math.Atan2(q[1] - p[1], q[0] - p[0]);
                        double delta = Math.Acos(d / (2 * r));
                        double entry = angle - delta;
                        double exit = angle + delta;
                        if (angles.ContainsKey(entry))
                        {
                            angles[entry][0]++;
                        }
                        else
                        {
                            angles.Add(entry, new int[] { 1,0});
                        }
                        if (angles.ContainsKey(exit))
                        {
                            angles[exit][1]--;
                        }
                        else
                        {
                            angles.Add(exit, new int[] { 0,-1});
                        }                        
                    }
                }
                int count = 1;
                foreach(double key in angles.Keys)
                {
                    count += angles[key][0];
                    ans = Math.Max(ans, count);
                    count += angles[key][1];
                }
            }
            return ans;
        }

        public static double Distance(int[] a, int[] b)
        {
            int x = a[0] - b[0];
            int y = a[1] - b[1];
            return Math.Sqrt(x*x + y*y);
        }
    }
}
