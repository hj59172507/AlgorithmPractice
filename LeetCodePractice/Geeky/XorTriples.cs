using System;
using System.Collections.Generic;

/*
Given an array of integers arr.

We want to select three indices i, j and k where (0 <= i < j <= k < arr.length).

Let's define a and b as follows:

a = arr[i] ^ arr[i + 1] ^ ... ^ arr[j - 1]
b = arr[j] ^ arr[j + 1] ^ ... ^ arr[k]
Note that ^ denotes the bitwise-xor operation.

Return the number of triplets (i, j and k) Where a == b.

Example 1:

Input: arr = [2,3,1,6,7]
Output: 4
Explanation: The triplets are (0,1,2), (0,2,2), (2,3,4) and (2,4,4)
Example 2:

Input: arr = [1,1,1,1,1]
Output: 10
Example 3:

Input: arr = [2,3]
Output: 0
Example 4:

Input: arr = [1,3,5,7,9]
Output: 3
Example 5:

Input: arr = [7,11,12,9,5,2,7,17,22]
Output: 8
 
Constraints:

1 <= arr.length <= 300
1 <= arr[i] <= 10^8

Sol1 Prefix XOR:
Time O(n^2)
Space O(1)
Notice that if XOR(arr[i....k]) == 0, then there is k-1 solution since whatever j you pick between i and k, subarr i to j, and j to k will have same xor value
Hence if we accumulate XOR values keeping a starting point i, next time we hit a XOR sum of 0 at index k, we can add up the sum

Sol2 Prefix XOR with some math
Time O(n)
Space O(n)
Let P(i,k) = XOR(arr[i to k]
If P(i,k+1) == P(i,i+1), then will is k-i solutions. 
If there is f number of k, then we have fk - i1 - i2 ....if
Namely, we compute prefix XOR, and if we find some value appear before, we accumlate the sum(i1+i2....) as well as number of solutions
 */
namespace LeetCodePractice.Geeky
{
    class XorTriples
    {
        //static void Main()
        static void Main1442()
        {
            int[] arr = new int[] { 2, 3, 1, 6, 7 };
            Console.Out.WriteLine(CountTriplets(arr));
            Console.In.ReadLine();
        }
        public static int CountTriplets(int[] arr)
        {
            int ans = 0, p = 0;
            int cnt = 0, total = 0;
            Dictionary<int, int> pCtn = new Dictionary<int, int>();
            pCtn[0] = 1;
            Dictionary<int, int> sCtn = new Dictionary<int, int>();
            
            for (int i = 0; i < arr.Length; i++)
            {                
                p ^= arr[i];
                cnt = pCtn.ContainsKey(p) ? pCtn[p] : 0;
                total = sCtn.ContainsKey(p) ? sCtn[p] : 0;
                ans += cnt * i - total;
                pCtn[p] = cnt + 1;
                sCtn[p] = total + i + 1;                
            }
            return ans;
        }
    }
}
