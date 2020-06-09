using System.Text;
/*
1363. Largest Multiple of Three

Given an integer array of digits, return the largest multiple of three that can be formed by concatenating some of the given digits in any order.

Since the answer may not fit in an integer data type, return the answer as a string.

If there is no answer return an empty string.

Example 1:

Input: digits = [8,1,9]
Output: "981"
Example 2:

Input: digits = [8,6,7,1,0]
Output: "8760"
Example 3:

Input: digits = [1]
Output: ""
Example 4:

Input: digits = [0,0,0,0,0,0]
Output: "0"
 
Constraints:

1 <= digits.length <= 10^4
0 <= digits[i] <= 9
The returning answer must not contain unnecessary leading zeros.

Sol
Time O(n)
Space O(1)
let c[i] store the count of digit i
If sum of all digits is multiple of 3, then we simply build the string from 9 to 0
If sum % 3 == 1, then we must have 1 of {1, 4, 7} or 2 of {2, 5, 8}
If sum % 3 == 2, then we must have 1 of {2, 5, 8} or 2 of {1, 4, 7}
 */
namespace LeetCodePractice.Geeky
{
    class LargestMultipleOfThree
    {
        public string LargestMultipleOfThrees(int[] digits)
        {
            int[] count = new int[10], remove = {2, 5, 8, 1, 4, 7 };
            int sum = 0;
            foreach (int i in digits)
            {
                count[i]++;
                sum += i;
            }
            if (sum % 3 == 1 && count[1] > 0) { sum -= 1; --count[1]; }
            if (sum % 3 == 1 && count[4] > 0) { sum -= 4; --count[4]; }
            if (sum % 3 == 1 && count[7] > 0) { sum -= 7; --count[7]; }
            int j = 0;
            while(sum % 3 != 0)
            {
                if (count[remove[j]] > 0)
                {
                    sum -= remove[j];
                    count[remove[j]]--;
                }
                else ++j;
            }

            if(sum == 0)
            {
                if (count[0] > 0) return "0";
                else return "";
            }

            StringBuilder s = new StringBuilder();
            for (int k = 9; k >= 0; --k)
            {
                for(int z = 0; z < count[k]; ++z)
                {
                    s.Append(k);
                }
            }
            return s.ToString();
        }
    }
}
