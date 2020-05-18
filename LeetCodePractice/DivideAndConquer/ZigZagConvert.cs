using System;
using System.Collections.Generic;
using System.Text;

/*
 * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:

P     I    N
A   L S  I G
Y A   H R
P     I

Sol1:
Time O(n)
Space O(n)

Find line number associated with each letter, for row number nRow, we can group first 2*nRow - 2 letter with following rule:
1. First nRow letter will have line number 1 ..... to n respectively
2. Next nRow - 2 letter will have line number n-1 ..... to 2 repsectively
Store them in two-d array, where arr[i] is the array for letter appeared in line i

Sol2:
Time O(n)
Space O(n)

Similar to above, except we dont bother building array for each line.
Since each column letter and each diagonal letter is exactly 2*n - 2 letter apart, we can calcuated line of each letter in s by simply adding to first pattern. 

*/
namespace LeetCodePractice.DivideAndConquer
{
    class ZigZagConvert
    {
        static void Main()
        //static void Main6()
        {
            string s = "PAYPALISHIRING";
            int nRow = 4;
            Console.Out.WriteLine(Convert(s, nRow));
            Console.In.ReadLine();

        }
        public static string Convert(string s, int numRows)
        {
            if (numRows <= 1 || numRows >= s.Length)
                return s;
            var ans = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                int curPos = i;
                int diaPos = 2 * numRows - 2 - i;
                while (curPos < s.Length)
                {
                    if (i == 0 || i == numRows - 1)
                    {
                        ans.Append(s[curPos]);
                    }
                    else
                    {
                        //need to deal to diagonal letters
                        ans.Append(s[curPos]);
                        if (diaPos < s.Length)
                        {
                            ans.Append(s[diaPos]);
                            diaPos += 2 * numRows - 2;
                        }
                    }
                    curPos += 2 * numRows - 2;
                }
            }
            return ans.ToString();
        }
    }
}
