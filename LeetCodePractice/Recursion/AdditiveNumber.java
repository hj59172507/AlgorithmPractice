/*
Additive number is a string whose digits can form additive sequence.
A valid additive sequence should contain at least three numbers. Except for the first two numbers, each subsequent number in the sequence must be the sum of the preceding two.
Given a string containing only digits '0'-'9', write a function to determine if it's an additive number.
Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.
Example 1:
Input: "112358"
Output: true 
Explanation: The digits can form an additive sequence: 1, 1, 2, 3, 5, 8. 
             1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
Example 2:
Input: "199100199"
Output: true 
Explanation: The additive sequence is: 1, 99, 100, 199. 
             1 + 99 = 100, 99 + 100 = 199
*/

//using backtracking to check for all possible split of operators 
 class Solution {
    public boolean isAdditiveNumber(String num) {
        return isAdditiveHelper(num, 0, 1, "", "", 1);
    }
    
    public boolean isAdditiveHelper(String num, int left, int right, String op1, String op2, int processing){
        if(op1.length() > num.length() || op2.length() > num.length()) 
            return false;
        if(right == num.length())
            return isValid(op1, op2, num.substring(left, right));
        else{
            switch(processing){
                case 1: return isAdditiveHelper(num, left, right+1, op1, op2, 1) 
                    || isAdditiveHelper(num.substring(right, num.length()), 0, 1, num.substring(left, right), op2, 2);
                case 2: return isAdditiveHelper(num, left, right+1, op1, op2, 2) 
                    || isAdditiveHelper(num.substring(right, num.length()), 0, 1, op1, num.substring(left, right), 3);
                case 3: return isAdditiveHelper(num, left, right+1, op1, op2, 3) 
                    || ( isValid(op1, op2, num.substring(left, right)) &&
                    isAdditiveHelper(num.substring(right, num.length()), 0, 1, op2, num.substring(left, right), 3));
            }
            return false;
        }
    }
    
    public boolean isValid(String op1, String op2, String result){
        return isValidNumber(op1, op2, result) && (Long.valueOf(op1) + Long.valueOf(op2) == Long.valueOf(result));
    }
    
    public boolean isValidNumber(String op1, String op2, String result){
        return !(op1.length() > 1 && op1.charAt(0) == '0' || op1.length() == 0) &&
                !(op2.length() > 1 && op2.charAt(0) == '0' || op2.length() == 0) &&
                !(result.length() > 1 && result.charAt(0) == '0' || result.length() == 0);
    }
    
}