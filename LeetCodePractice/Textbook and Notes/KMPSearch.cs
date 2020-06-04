namespace LeetCodePractice.Textbook_and_Notes
{
    class KMPSearch
    {
        //Find if s contain pat in O(n) using KMP algorithm https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm        
        public static bool KMPSearchString(string s, string pat)
        {
            int j = 0, i = 0;
            int[] lps = GetLPSArray(pat);

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
        public static int[] GetLPSArray(string str)
        {
            int n = str.Length;
            int[] lps = new int[n];
            for (int i = 1, j = 0; i < n; i++)
            {
                while (j > 0 && str[i] != str[j]) j = lps[j - 1];
                if (str[i] == str[j]) lps[i] = ++j;
            }
            return lps;
        }
    }
}
