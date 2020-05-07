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

//DP approach, time O(n^2), space O(n^2)
class Solution {
    public int maxSubArray(int[] nums) {
        
        int max = nums[0];
        int[][] sumArray = new int[nums.length][nums.length];
        for(int i=0;i<nums.length;i++){
            int end = i, start = 0;
            while(end < nums.length){
                if(start == end)
                    sumArray[start][end] = nums[start];
                else{
                    sumArray[start][end] = sumArray[start][end-1] + nums[end];
                }
                if(sumArray[start][end] > max)
                    max = sumArray[start][end];
                end++;
                start++;
            }
        }
        return max;
    }
}

//linear solution based on the fact that if consectiveSum is negative, always create new subarray, time O(n), space O(1)
class Solution {
    public int maxSubArray(int[] nums) {
        int max = nums[0], consectiveSum = nums[0];
        for(int i=1;i<nums.length;i++){
            if(consectiveSum < 0){
                consectiveSum = nums[i];
            }
            else
                consectiveSum += nums[i];
            if(consectiveSum > max)
                max = consectiveSum;
        }
        return max;
    }

}