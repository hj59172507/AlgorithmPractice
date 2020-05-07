'''
Find inversion count in an unsorted array:
An inversion happen when there is a number at index i greater than another number at index j where i < j

input will be a list of unsorted int array

Algorithm runs in nlog(n)
We can break the problem into three parts
An inversion can happen on the left side, right side, or one element in left side and another in right side
So we can recursively solve left, right, and split and return their sum
'''

#implement merge sort
def SplitInversionCount(leftArr, rightArr):

	mergedArr = []
	leftIndex = 0
	rightIndex = 0
	totalLength = len(leftArr) + len(rightArr)
	invCount = 0

	for i in range(0,totalLength):
		if(leftArr[leftIndex] <= rightArr[rightIndex]):
			mergedArr.append(leftArr[leftIndex])
			leftIndex += 1
			if(leftIndex == len(leftArr)):
				[mergedArr.append(x) for x in rightArr[rightIndex:len(rightArr)]]
				mergedArr.append(invCount)
				return mergedArr
		else:
			mergedArr.append(rightArr[rightIndex])
			invCount += len(leftArr) - leftIndex
			rightIndex += 1
			if(rightIndex == len(rightArr)):
				[mergedArr.append(x) for x in leftArr[leftIndex:len(leftArr)]]
				mergedArr.append(invCount)
				return mergedArr

def InversionCount(arr):

	length = len(arr)
	
	if(length == 1):
		arr.append(0)
		return arr

	leftArr = InversionCount(arr[0:length//2])
	rightArr = InversionCount(arr[length//2:length])
	leftInvCount = leftArr[len(leftArr)-1]
	del leftArr[len(leftArr)-1]
	rightInvCount = rightArr[len(rightArr)-1]
	del rightArr[len(rightArr)-1]

	resultArr = SplitInversionCount(leftArr, rightArr)
	resultArr[len(resultArr) - 1] += (leftInvCount + rightInvCount)
	
	return resultArr

	

inputF = open("IntegerArray.txt","r")
sArr = inputF.read().splitlines()
intArr = [int(x) for x in sArr]

print(InversionCount(intArr)[len(intArr)])