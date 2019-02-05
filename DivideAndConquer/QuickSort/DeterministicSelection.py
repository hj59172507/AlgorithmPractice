import random

def QuickSort(arr, startIndex, endIndex):
	
	#base case, return if there is only one element
	if(startIndex == endIndex - 1 or startIndex == endIndex):
		return

	#get a random pivot
	rStartIndex =  random.randint(startIndex, endIndex - 1)
	swap(arr, rStartIndex, startIndex)

	#sort base on pivot
	pivot = arr[startIndex]
	correctStartIndex = startIndex
	for i in range(correctStartIndex, endIndex):
		if(arr[i] < pivot):
			correctStartIndex += 1
			swap(arr, correctStartIndex, i)
			
	swap(arr, startIndex, correctStartIndex)

	#sort left and right of pivot
	QuickSort(arr, startIndex, correctStartIndex)
	QuickSort(arr, correctStartIndex + 1, endIndex)

def GetMedian(arr, start, end):
	temp = arr[start:end]
	QuickSort(temp, 0,len(temp))
	median = temp[len(temp)//2]
	for i in range(start,end):
		if(arr[i] == median):
			return i

def DSelect(arr, startIndex, targetIndex):
	
	#base case, return if there is only one element
	if(len(arr) == 1):
		return arr[0]

	#for size of 50 or greater, get a median of median as pivot, else get a random pivot
	if(len(arr) >= 50):
		medianIndexs = [GetMedian(arr, start, start+5) for start in range(startIndex, len(arr)-1, 5)]
		medianIndex = DSelect(medianIndexs, 0, len(arr)//10)
		swap(arr, medianIndex, startIndex)
	else:
		rStartIndex =  random.randint(startIndex, len(arr)-1)
		swap(arr, rStartIndex, startIndex)

	#sort base on pivot
	pivot = arr[startIndex]
	correctStartIndex = startIndex
	for i in range(startIndex, len(arr)):
		if(arr[i] < pivot):
			correctStartIndex += 1
			swap(arr, correctStartIndex, i)
	swap(arr, startIndex, correctStartIndex)

	#base on correctStartIndex, detemine if we should return or recurse left or right
	if(targetIndex == correctStartIndex):
		return arr[targetIndex]
	elif(targetIndex < correctStartIndex):
		return DSelect(arr[startIndex:correctStartIndex], startIndex, targetIndex)
	else:
		return DSelect(arr[correctStartIndex + 1:], 0, targetIndex - correctStartIndex - 1)

def swap(arr,i,j):
	if(i != j):
		arr[i] += arr[j]
		arr[j] = arr[i] - arr[j]
		arr[i] -= arr[j]
	

f = open("input.txt","r")
a = [int(x) for x in f.read().splitlines()]
startIndex = 0
targetIndex = 1342

print(DSelect(a, startIndex, targetIndex))


