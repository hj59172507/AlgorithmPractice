'''
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
'''

#return the median, given the firstMedian, and two possible candidate for second median
def getMedian(firstMedian, arr1, arr1Left, arr2, arr2Left):
	even = (len(arr1)+len(arr2))%2 == 0
	if(not even):
		return firstMedian
	distanceToFirstMedian1, distanceToFirstMedian2 = -1, -1
	if(arr1Left < len(arr1)):
		distanceToFirstMedian1 = arr1[arr1Left] - firstMedian
	if(arr2Left < len(arr2)):
		distanceToFirstMedian2 = arr2[arr2Left] - firstMedian
	if(distanceToFirstMedian1 < 0):
		return (firstMedian+arr2[arr2Left])/2
	elif(distanceToFirstMedian2 < 0 or distanceToFirstMedian1 < distanceToFirstMedian2):
		return (firstMedian+arr1[arr1Left])/2
	else:
		return (firstMedian+arr2[arr2Left])/2

#return the median by finding the first median and then calling getMedian(), where sva have already narrow down to one element
def getNthElement(sva, svaLeft, arr, left, right, nth):
	#if size of arr is less than our nth target, then first median must be between the only element in sva and last element in arr
	if(right-left < nth):
		if(sva[svaLeft] > arr[nth+left-2]):
			return getMedian(sva[svaLeft], sva, svaLeft+1, arr, nth+left-1)
		else:
			return getMedian(arr[nth+left-2], arr, nth+left-1, sva, svaLeft+1)
	#else the first median could be either before nth-1 element in arr, after nth element in arr, or between n-1 and n element
	else:
		if(sva[svaLeft] < arr[nth+left-2]):
			return getMedian(arr[nth+left-2], arr, nth+left-1, sva, svaLeft+1)
		elif(sva[svaLeft] > arr[nth+left-1]):
			return getMedian(arr[nth+left-1], arr, nth+left, sva, svaLeft)
		else:
			return getMedian(sva[svaLeft], sva, svaLeft+1, arr, nth+left-1)

#reduce the question to finding the nth element in two arrays
def findNthElementInTwoSortedArrays(arr1, arr2, arr1Left, arr1Right, arr2Left, arr2Right, nth):
	#return median if all we looking for is the first element
	if(nth == 1):
		if(arr1[arr1Left] > arr2[arr2Left]):
			return getMedian(arr2[arr2Left], arr2, arr2Left+1, arr1, arr1Left)
		else:
			return getMedian(arr1[arr1Left], arr1, arr1Left+1, arr2, arr2Left)
	#return median when there is only one element left in one of the array
	if(arr1Right-arr1Left==1):
		return getNthElement(arr1, arr1Left, arr2, arr2Left, arr2Right, nth)
	if(arr2Right-arr2Left==1):
		return getNthElement(arr2, arr2Left, arr1, arr1Left, arr1Right, nth)

	arr1MidIndex = (arr1Left+arr1Right)//2
	arr2MidIndex = (arr2Left+arr2Right)//2	

	#Depending on sizes of smaller half of arr1 and arr2, we can safely eliminate either larger half of larger array or smaller half of smaller array
	if(arr1[arr1MidIndex] >= arr2[arr2MidIndex]):
		if(arr1MidIndex + arr2MidIndex - arr1Left - arr2Left >= nth):
			return findNthElementInTwoSortedArrays(arr1, arr2, arr1Left, arr1MidIndex, arr2Left, arr2Right, nth)
		else:
			return findNthElementInTwoSortedArrays(arr1, arr2, arr1Left, arr1Right, arr2MidIndex, arr2Right, nth-arr2MidIndex+arr2Left)
	else:
		if(arr1MidIndex + arr2MidIndex - arr1Left -arr2Left >= nth):
			return findNthElementInTwoSortedArrays(arr1, arr2, arr1Left, arr1Right, arr2Left, arr2MidIndex, nth)
		else:
			return findNthElementInTwoSortedArrays(arr1, arr2, arr1MidIndex, arr1Right, arr2Left, arr2Right, nth-arr1MidIndex+arr1Left)

def findMedianSortedArrays(arr1, arr2):
	#basic check
	if(len(arr1)==0):
		if(len(arr2) % 2 != 0):
			return arr2[len(arr2)//2]
		else:
			return (arr2[len(arr2)//2] + arr2[len(arr2)//2-1])/2
	if(len(arr2)==0):
		if(len(arr1) % 2 != 0):
			return arr1[len(arr1)//2]
		else:
			return (arr1[len(arr1)//2] + arr1[len(arr1)//2-1])/2

	#find nth element in the two array
	return findNthElementInTwoSortedArrays(arr1, arr2, 0, len(arr1), 0, len(arr2), (len(arr1)+len(arr2)+1)//2)

arr1 = [1,2,5]
arr2 = [3,4,6,7,8,9,10]
#expect (5+6)/2 = 5.5
print(findMedianSortedArrays(arr1, arr2))