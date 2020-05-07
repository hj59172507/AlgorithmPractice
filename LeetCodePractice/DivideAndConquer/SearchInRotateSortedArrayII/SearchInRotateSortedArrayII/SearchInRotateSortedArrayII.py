#81. Search in Rotated Sorted Array II

#Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

#(i.e., [0,0,1,2,2,5,6] might become [2,5,6,0,0,1,2]).

#You are given a target value to search. If found in the array return true, otherwise return false.
class Solution:
    def search(self, nums: List[int], target: int) -> bool:
        if(len(nums)==0):
            return False
        right=len(nums)-1
        left=0
        while left<=right:
            mid = (left+right)//2
            if nums[mid]==target:
                return True
            if nums[mid]>target:
                if nums[mid]>=nums[left]>target:
                    left = mid+1
                else:
                    right = mid-1
            else:
                if nums[mid]<=nums[right]<target:
                    right = right-1
                else:
                    left = mid+1
        return False


        
