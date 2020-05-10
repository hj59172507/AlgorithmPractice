using System;

namespace LeetCodePractice.SimpleWarmUp
{
    class SubtractProdcuAndSumOfInt
    {
        //static void Main()
        static void Main1281()
        {
            int n = 234;
            Console.Out.WriteLine(SubtractProductAndSum(n));
            Console.In.ReadLine();
        }
        public static int SubtractProductAndSum(int n)
        {
            int product = 1;
            int sum = 0;
            while(n != 0)
            {
                int rem = n % 10;
                product *= rem;
                sum += rem;
                n /= 10;
            }
            return product - sum;
        }
    }
}
