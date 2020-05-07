/*
Given an array of integers A sorted in non-decreasing order, return an array of the squares of each number, also in sorted non-decreasing order.

 

Example 1:

Input: [-4,-1,0,3,10]
Output: [0,1,9,16,100]
Example 2:

Input: [-7,-3,2,3,11]
Output: [4,9,9,49,121]
 

Note:

1 <= A.length <= 10000
-10000 <= A[i] <= 10000
A is sorted in non-decreasing order
*/
//Linear solution
class Solution {
    public int[] sortedSquares(int[] A) {      
        //find index of last negative number
        int lastNegative = 0;
        for(int i : A){
            if(i <= 0)
                lastNegative++;
            else
                break;
        }
        int pos = lastNegative;
        int[] sortedPositive = new int[A.length];
            
        for(int i=0;i<A.length;i++){

            if(pos == A.length || (lastNegative != 0 && A[lastNegative-1]*A[lastNegative-1] <= A[pos]*A[pos])){
                sortedPositive[i] = A[lastNegative-1]*A[lastNegative-1];
                lastNegative--;
            }
            else if(lastNegative == 0 || A[lastNegative-1]*A[lastNegative-1] > A[pos]*A[pos]){
                sortedPositive[i] = A[pos]*A[pos];
                pos++;
            }
        }
        return sortedPositive;            
    }
}