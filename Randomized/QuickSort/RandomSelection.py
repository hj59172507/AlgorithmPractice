import random

def RSelect(arr, startIndex, targetIndex):
	
	#base case, return if there is only one element
	if(len(arr) == 1):
		return arr[0]

	#get a random pivot
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
		return RSelect(arr[startIndex:correctStartIndex], startIndex, targetIndex)
	else:
		return RSelect(arr[correctStartIndex + 1:], 0, targetIndex - correctStartIndex - 1)

def swap(arr,i,j):
	if(i != j):
		arr[i] += arr[j]
		arr[j] = arr[i] - arr[j]
		arr[i] -= arr[j]
	

f = open("input.txt","r")
a = [int(x) for x in f.read().splitlines()]
startIndex = 0
targetIndex = 1234

print(RSelect(a, startIndex, targetIndex))


