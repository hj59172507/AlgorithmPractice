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


def swap(arr,i,j):
	if(i != j):
		arr[i] += arr[j]
		arr[j] = arr[i] - arr[j]
		arr[i] -= arr[j]
	

f = open("input.txt","r")
a = [int(x) for x in f.read().splitlines()]
QuickSort(a, 0, len(a))
print(a)

