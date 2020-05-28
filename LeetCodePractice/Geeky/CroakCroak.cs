using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given the string croakOfFrogs, which represents a combination of the string "croak" from different frogs, that is, multiple frogs can croak at the same time, so multiple “croak” are mixed. Return the minimum number of different frogs to finish all the croak in the given string.

A valid "croak" means a frog is printing 5 letters ‘c’, ’r’, ’o’, ’a’, ’k’ sequentially. The frogs have to print all five letters to finish a croak. If the given string is not a combination of valid "croak" return -1.

Example 1:

Input: croakOfFrogs = "croakcroak"
Output: 1 
Explanation: One frog yelling "croak" twice.
Example 2:

Input: croakOfFrogs = "crcoakroak"
Output: 2 
Explanation: The minimum number of frogs is two. 
The first frog could yell "crcoakroak".
The second frog could yell later "crcoakroak".
Example 3:

Input: croakOfFrogs = "croakcrook"
Output: -1
Explanation: The given string is an invalid combination of "croak" from different frogs.
Example 4:

Input: croakOfFrogs = "croakcroa"
Output: -1
 

Constraints:

1 <= croakOfFrogs.length <= 10^5
All characters in the string are: 'c', 'r', 'o', 'a' or 'k'.

Sol 
Time O(n)
Space O(1)
keep count of all letter, track if there is violation of letter order(if r > c)
Don't count isolated croak since we want minimum
 */
namespace LeetCodePractice.Geeky
{
    class CroakCroak
    {
        //static void Main()
        static void Main1419()
        {
            string s = "croakcroak";
            Console.Out.WriteLine(MinNumberOfFrogs(s));
            Console.In.ReadLine();
        }
        public static int MinNumberOfFrogs(string croakOfFrogs)
        {            
            int ans = 0, c = 0, r = 0, o = 0, a = 0, k = 0, concurrent = 0;
            foreach(char ch in croakOfFrogs)
            {
                if(ch == 'c')
                {
                    c++;
                    concurrent++;
                }
                else if (ch == 'r')
                {
                    r++;
                }
                else if (ch == 'o')
                {
                    o++;
                }
                else if (ch == 'a')
                {
                    a++;
                }
                else if (ch == 'k')
                {
                    k++;
                    concurrent--;
                }
                if (r > c || o > r || a > o || k > a)
                    return -1;
                ans = Math.Max(ans, concurrent);
            }
            if(concurrent == 0 && c == r && r== o && o == a && a == k)
                return ans;
            return -1;

        }
    }
}
