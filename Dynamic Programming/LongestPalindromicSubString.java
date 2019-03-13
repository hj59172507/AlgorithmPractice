/*
Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

Example 1:

Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.
Example 2:

Input: "cbbd"
Output: "bb"
*/

//Dynamic programming approach: time O(n^2), space O(n^2)
class Solution {
    public String longestPalindrome(String s) {
        int length = s.length();
        if(length<2)
            return s;
            
        boolean[][] isPalindrome = new boolean[length][length];
        int max = 1;
        int left = 0;
        int right = 1;
        
        for(int i=0;i<length;i++){
            int end = i;
            int start = 0;
            while(end<length){
                if(start == end)
                    isPalindrome[start][end] = true;
                else if(end-1==start)
                    isPalindrome[start][end] = s.charAt(start) == s.charAt(end);
                else{
                    isPalindrome[start][end] = isPalindrome[start+1][end-1] && (s.charAt(start) == s.charAt(end));
                }
                if(isPalindrome[start][end] && end - start + 1 > max){
                    left = start;
                    right = end+1;
                    max = end-start+1;
                }
                start++;
                end++;
            }
        }   
        return s.substring(left, right);
       
    }
}

