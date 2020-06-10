'''
Problem: try to find all medians as integer are inserting into array 

Algorithm: keep a max heap for lower half of the array, and a min heap for higher half of the array
So the we can always retrive median in O(1), total cost should be nlog(n)
'''
class MinHeap:
	'''MinHeap class for numeric list'''
	def __init__(self):
		self.heap = []
	
	#get parent index from child_index
	def parent(self, childIndex):
		if(childIndex == 0):
			return 0
		return (childIndex+1)//2-1

	#get left child index from parent_index
	def left(self, parentIndex):
		return (parentIndex*2)+1

	#get right child index from parent_index
	def right(self, parentIndex):
		return (parentIndex*2)+2

	#move element at index i down to proper place so heap properity is maintained
	def heapifyDown(self, i):
		left, right, smallest = self.left(i), self.right(i), i
		if(left < len(self.heap) and self.heap[left] < self.heap[i]):
			smallest = left
		if(right < len(self.heap) and self.heap[right] < self.heap[smallest]):
			smallest = right
		if(smallest != i):
			self.swap(smallest, i)
			self.heapifyDown(smallest)

	#move element at index i up to proper place so heap properity is maintained
	def heapifyUp(self, i):
		parent = self.parent(i)
		if(i != parent and self.heap[i] < self.heap[parent]):
			self.swap(i, parent)
			self.heapifyUp(parent)

	#swap values of elements at heap index x and y
	def swap(self, x, y):
		self.heap[x], self.heap[y] = self.heap[y], self.heap[x]

	#heapity an unordered array, assuming arr is integer array
	def heapifyArray(self, arr):
		self.heap = arr
		i = len(self.heap)//2
		while(i > 0):
			self.heapifyDown(i)
			i -= 1

	#insert an element to heap, and maintain heap property
	def insert(self, element):
		self.heap.append(element)
		self.heapifyUp(len(self.heap)-1)

	#return the minimum element in the heap without removing it
	def peek(self):
		if(len(self.heap) > 0):
			return self.heap[0]
		else:
			return None

	#delete an element in index i from heap
	def deleteAt(self, i):
		if(i != len(self.heap)-1):
			self.swap(i, len(self.heap)-1)
			del self.heap[len(self.heap)-1]
			self.heapifyDown(i)
		else:
			del self.heap[i]

	#delete an element in heap, return  -1 if not found
	def deleteEle(self, element):
		elementIndex = self.heap.index(element)
		self.deleteAt(elementIndex)

	#return the minimum element in the heap and remove it
	def pop(self):
		if(len(self.heap) > 0):
			result = self.heap[0]
			self.deleteAt(0)
			return result
		else:
			return None

	#print the heap
	def __str__(self):
		s = ''
		for ele in self.heap:
			s += str(ele) + " "
		return s

	def size(self):
		return len(self.heap)


f = open("median.txt","r")

#heapLow and heapHigh store the lower half of the elements and higher half the elements respectively
#assuming all input are postivei, heapLow store the negative of real value so we have use minHeap for both heap
heapLow = MinHeap()
heapHigh = MinHeap()
medians = []

for value in f.read().splitlines():
	insertValue = int(value)
	#if leapLow and heapHigh have same size
	if(heapLow.size() == heapHigh.size()):
		#if first element of heapHigh is less than insertValue, pop the min from heapHigh and insert it to heapLow
		#and insert insertValue into heapHigh
		if(heapHigh.size() >= 1 and insertValue > heapHigh.peek()):
			higherMin = heapHigh.pop()
			heapHigh.insert(insertValue)
			heapLow.insert(-higherMin)
		else:
			heapLow.insert(-insertValue)
	else:
		#if max element in heapLow is higher than insertValue, then pop the max from heapLow and
		#insert it to heapHigh, and then insert the insertValue to heapLow
		if(heapLow.size() >= 1 and insertValue < -heapLow.peek()):
			lowerMax = -heapLow.pop()
			heapHigh.insert(lowerMax)
			heapLow.insert(-insertValue)
		else:
			heapHigh.insert(insertValue)
	medians.append(-heapLow.peek())

print(sum(medians) / len(medians))
