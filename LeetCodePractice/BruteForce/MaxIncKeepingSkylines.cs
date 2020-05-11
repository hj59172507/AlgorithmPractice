using LeetCodePractice.DataStructure.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.BruteForce
{
    class MaxIncKeepingSkylines
    {
        //static void Main()
        static void Main807()

        {           
            int[][] grid =  {new int [] {3, 0, 8, 4 },
                             new int [] {2, 4, 5, 7},
                             new int [] {9, 2, 6, 3},
                             new int [] {0, 3, 1, 0} };           
            Console.Out.WriteLine(MaxIncreaseKeepingSkyline(grid));
            Console.In.ReadLine();
        }

        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int sum = 0;
            int rowL = grid.Length;
            int colL = grid[0].Length;
            int[] rowMax = new int[rowL];
            int[] colMax = new int[colL];
            for(int i=0; i<rowL; i++)
            {
                rowMax[i] = grid[i].Max();
            }
            for (int j = 0; j < colL; j++)                
            {
                int curColMax = 0;
                for (int i = 0; i < rowL; i++)
                {
                    if (curColMax < grid[i][j])
                        curColMax = grid[i][j];
                }
                colMax[j] = curColMax;
            }
            for (int i = 0; i < rowL; i++)                
            {                
                for (int j = 0; j < colL; j++)
                {
                    sum += Math.Min(rowMax[i], colMax[j]) - grid[i][j]; 
                }             
            }
            return sum;
        }

    }
}
