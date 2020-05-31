using System;
using System.Collections.Generic;

namespace LeetCodePractice.SimpleWarmUp
{
    class EqualArray
    {
        static void Main()
        //static void Main1460()
        {
            int[] nums = { 1, 4, 3, 2 };
            int[] nums2 = { 1, 2, 3, 4 };
            Console.Out.WriteLine(CanBeEqual(nums, nums2));
            Console.In.ReadLine();
        }
        public static bool CanBeEqual(int[] target, int[] arr)
        {
            bool finished = true;
            Dictionary<int, int> d1 = new Dictionary<int, int>();
            Dictionary<int, int> d2 = new Dictionary<int, int>();
            for(int i = 0; i < target.Length; i++)
            {
                if (d1.ContainsKey(target[i]))
                    d1[target[i]]++;
                else d1[target[i]] = 1;
                if (d2.ContainsKey(arr[i]))
                    d2[arr[i]]++;
                else d2[arr[i]] = 1;
            }
            foreach(int i in d1.Keys)
            {
                if (!d2.ContainsKey(i) || d1[i] != d2[i])
                {
                    finished = false;
                    break;
                }                
            }
            return finished;
        }
    }
}
