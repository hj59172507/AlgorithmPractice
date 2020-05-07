class MinHeap:
	'''MinHeap class for numeric list'''
	def __init__(self, arr = []):
		self.heap = arr
	
	#get parent index from childIndex
	def parent(self, childIndex):
		if(childIndex == 0):
			return 0
		return (childIndex+1)//2-1

	#get left child index from parentIndex
	def left(self, parentIndex):
		return (parentIndex*2)+1

	#get right child index from parentIndex
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
		while(i >= 0):
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

#some sample test
heap = MinHeap()

heap.insert(286789035)
heap.insert(255653921)
heap.insert(274310529)
heap.insert(494521015)
print(heap.peek())
heap.deleteEle(255653921)
heap.deleteEle(286789035)
print(heap.peek())
heap.insert(236295092)
heap.insert(254828111)
heap.deleteEle(254828111)
heap.insert(85886315)
heap.insert(7959587)
heap.insert(20842598)
heap.insert(494521015)
heap.deleteEle(7959587)		
print(heap.peek())