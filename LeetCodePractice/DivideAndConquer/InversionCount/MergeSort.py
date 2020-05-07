
#simple merge sort for numbers
def Merge(leftArr, rightArr):

	mergedArr = []
	leftIndex = 0
	rightIndex = 0
	totalLength = len(leftArr) + len(rightArr)

	for i in range(0,totalLength):
		if(leftArr[leftIndex] <= rightArr[rightIndex]):
			mergedArr.append(leftArr[leftIndex])
			leftIndex += 1
			if(leftIndex == len(leftArr)):
				[mergedArr.append(x) for x in rightArr[rightIndex:len(rightArr)]]
				return mergedArr
		else:
			mergedArr.append(rightArr[rightIndex])
			rightIndex += 1
			if(rightIndex == len(rightArr)):
				[mergedArr.append(x) for x in leftArr[leftIndex:len(leftArr)]]
				return mergedArr


def MergeSort(arr):

	length = len(arr)
	
	if(length == 1):
		return arr
	leftArr = MergeSort(arr[0:length//2])
	rightArr = MergeSort(arr[length//2:length])
	return Merge(leftArr, rightArr)
	

f = open("IntegerArray.txt","r")
a = [int(x) for x in f.read().splitlines()]
print(MergeSort(a))