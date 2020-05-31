using System.Collections.Generic;

namespace LeetCodePractice
{
    public static class Utility
    {
        public static int Sum(IEnumerable<int> arr)
        {
            int sum = 0;
            foreach (int i in arr) sum += i;
            return sum;
        }

        public static double factorial(int i)
        {
            double ans = 1;
            while (i > 1)
            {
                ans *= i--;
            }
            return ans;
        }
    }
}
