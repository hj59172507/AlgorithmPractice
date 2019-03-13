/*
Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
Example:
Input: [-2,1,-3,4,-1,2,1,-5,4],
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
*/
//brute force approach, time O(n^3), space O(1)
class Solution {
    public int maxSubArray(int[] nums) {
        
        int max = nums[0];
        for(int i=0;i<nums.length;i++){
            for(int j=i;j<nums.length;j++){
                int sum = getSum(nums, i, j);
                if(sum > max)
                    max = sum;
            }
        }
        return max;
    }
    
    public int getSum(int[] nums, int start, int end){
        int result = 0;
        for(int i = start; i <= end; i++){
            result += nums[i];
        }
        return result;
    }
}