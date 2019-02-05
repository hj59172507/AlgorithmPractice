'''
Problem: try to find all medians as integer are inserting into array 

Algorithm: keep a max heap for lower half of the array, and a min heap for higher half of the array
So the we can always retrive median in O(1), total cost should be nlog(n)
'''
def swap(heap, p1, p2):
	heap[p1] += heap[p2]
	heap[p2] = heap[p1] - heap[p2]
	heap[p1] -= heap[p2] 

def AddToHeapMax(heap, value):
	heap.append(value)
	size = len(heap)
	parentPos = size // 2
	childValue = value
	childPos = size
	parentValue = heap[parentPos - 1]
	if(parentPos >= 0):
		while(childValue > parentValue):
			swap(heap, childPos - 1, parentPos - 1)
			childPos = parentPos
			parentPos = parentPos // 2
			if(parentPos <= 0):
				break
			childValue = heap[childPos - 1]
			parentValue = heap[parentPos - 1]

def AddToHeapMin(heap, value):
	heap.append(value)
	size = len(heap)
	parentPos = size // 2
	childValue = value
	childPos = size
	parentValue = heap[parentPos - 1]
	if(parentPos >= 0):
		while(childValue < parentValue):
			swap(heap, childPos - 1, parentPos - 1)
			childPos = parentPos
			parentPos = parentPos // 2
			if(parentPos <= 0):
				break
			childValue = heap[childPos - 1]
			parentValue = heap[parentPos - 1]

def ExtractMax(heap):
	Max = heap[0]
	swap(heap, 0, len(heap)-1)
	del heap[len(heap)-1]
	sourcePos = 1
	sourceLeftChild = sourcePos*2
	sourceRightChild = sourceLeftChild + 1
	
	while(True):
		#check if there is left and right child
		if(len(heap) < sourceLeftChild):
			break
		elif(len(heap) < sourceRightChild):
			if(heap[sourcePos-1] < heap[sourceLeftChild-1]):
				swap(heap, sourcePos-1, sourceLeftChild-1)
				break
			else:
				break

		#check if we need to swap with children
		if(heap[sourcePos-1] < max(heap[sourceLeftChild-1], heap[sourceRightChild-1])):
			if(heap[sourceLeftChild-1] > heap[sourceRightChild-1]):
				swap(heap, sourcePos-1, sourceLeftChild-1)
				sourcePos = sourceLeftChild
			else:
				swap(heap, sourcePos-1, sourceRightChild-1)
				sourcePos = sourceRightChild
			sourceLeftChild = sourcePos*2
			sourceRightChild = sourceLeftChild + 1
		else:
			break
	return Max

def ExtractMin(heap):
	Min = heap[0]
	swap(heap, 0, len(heap)-1)
	del heap[len(heap)-1]
	sourcePos = 1
	sourceLeftChild = sourcePos*2
	sourceRightChild = sourceLeftChild + 1
	
	while(True):
		#check if there is left and right child
		if(len(heap) < sourceLeftChild):
			break
		elif(len(heap) < sourceRightChild):
			if(heap[sourcePos-1] > heap[sourceLeftChild-1]):
				swap(heap, sourcePos-1, sourceLeftChild-1)
				break
			else:
				break

		#check if we need to swap with children
		if(heap[sourcePos-1] > min(heap[sourceLeftChild-1], heap[sourceRightChild-1])):
			if(heap[sourceLeftChild-1] < heap[sourceRightChild-1]):
				swap(heap, sourcePos-1, sourceLeftChild-1)
				sourcePos = sourceLeftChild
			else:
				swap(heap, sourcePos-1, sourceRightChild-1)
				sourcePos = sourceRightChild
			sourceLeftChild = sourcePos*2
			sourceRightChild = sourceLeftChild + 1
		else:
			break
	return Min

f = open("median.txt","r")
heapLow = []
heapHigh = []
medians = []
for value in f.read().splitlines():
	insertValue = int(value)
	if(len(heapLow) == len(heapHigh)):
		if(len(heapHigh) >= 1 and insertValue > heapHigh[0]):
			higherMin = ExtractMin(heapHigh)
			AddToHeapMin(heapHigh, insertValue)
			AddToHeapMax(heapLow, higherMin)
		else:
			AddToHeapMax(heapLow, insertValue)
	else:
		if(len(heapLow) >= 1 and insertValue < heapLow[0]):
			lowerMax = ExtractMax(heapLow)
			AddToHeapMax(heapLow, insertValue)
			AddToHeapMin(heapHigh, lowerMax)
		else:
			AddToHeapMin(heapHigh, insertValue)
	medians.append(heapLow[0])

print(sum(medians) / len(medians))
