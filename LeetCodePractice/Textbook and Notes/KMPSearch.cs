using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.Textbook_and_Notes
{
    class KMPSearch
    {
        //Find if s contain pat in O(n) using KMP algorithm https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm        
        public static bool KMPSearchString(string s, string pat)
        {
            int j = 0, i = 0;
            int[] lps = new int[pat.Length];
            GetLPSArray(pat, lps);
            while (i < s.Length)
            {
                if (s[i] == pat[j])//there is a match
                {
                    ++i;
                    ++j;
                    if (j == pat.Length) return true; //answer found
                }
                else
                {
                    if (j != 0) j = lps[j = 1]; //dont match lps[j-1] since they already match
                    else ++i; //advance since nothing match
                }
            }
            return false;
        }


        //lps[i] = the longest proper prefix of pat[0..i] which is also a suffix of pat[0..i]         
        //proper prefix is a prefix of string s but not including s, E.g. proper subset
        public static void GetLPSArray(string pat, int[] lps)
        {
            int len = 0; //Previous lps;
            int i = 1; //start with 1 since lps[0] is always 0
            int m = pat.Length;
            lps[0] = 0;
            while (i < m)
            {
                if (pat[i] == pat[len])
                {
                    //match, set lps[i] 1 + len
                    lps[i++] = ++len;
                }
                //no match
                if (len != 0)
                {
                    //still have some match to check
                    len = pat[len - 1];
                }
                //len == 0
                lps[i++] = 0;
            }
        }
    }
}
