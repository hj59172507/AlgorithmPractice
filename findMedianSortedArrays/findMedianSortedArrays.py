'''
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

You may assume nums1 and nums2 cannot be both empty.
'''

nums1 = [1,2]
nums2 = [3,4]
#expect (2+3)/2 = 2.5

#Assume arr already sorted, hence using binary search
#return the index of element imediately less than target
def findIndexOfElementLessThan(arr, tar, l, r):
	if(l == r):
		return r
	mid = (l + r) // 2
	if(arr[mid] <= tar):
		if(r > mid):
			if(arr[mid+1] > tar):
				return mid
			else:
				return findIndexOfElementLessThan(arr, tar, mid+1, r)
		else:
			return r
	return findIndexOfElementLessThan(arr, tar, l, mid)

#reduce the question to finding the nth element in two arrays
def findNthElementInTwoSortedArrays(arr1, arr2, nth, evenLength):
    return 0
    

def findMedianSortedArrays(nums1, nums2):
    totalLength = len(nums1)+len(nums2)
    return findNthElementInTwoSortedArrays(nums1, nums2, totalLength//2, evenLength = totalLength % 2 == 0)
