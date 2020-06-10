class MinHeap:
    '''MinHeap class for numeric list'''
    def __init__(self, arr = []):
        self.heap = arr
    
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
        if(left < len(self.heap) and self.heap[left][1] < self.heap[i][1]):
            smallest = left
        if(right < len(self.heap) and self.heap[right][1] < self.heap[smallest][1]):
            smallest = right
        if(smallest != i):
            self.swap(smallest, i)
            self.heapifyDown(smallest)

    #move element at index i up to proper place so heap properity is maintained
    def heapifyUp(self, i):
        parent = self.parent(i)
        if(i != parent and self.heap[i][1] < self.heap[parent][1]):
            self.swap(i, parent)
            self.heapifyUp(parent)

    #swap values of elements at heap index x and y
    def swap(self, x, y):
        self.heap[x], self.heap[y] = self.heap[y], self.heap[x]

    #heapity an unordered array, assuming arr is integer array
    def heapifyArray(self, arr):
        self.heap = arr
        i = len(self.heap)//2 + 1
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

	#return size of internal heap
    def size(self):
        return len(self.heap)

# Complete the electionWinner function below.
def electionWinner(votes):
    #use a dictionary to count the votes in negative sign, which can be used later for a minimum heap
    nameToVoteCount = {}
    for vote in votes:
        if(vote in nameToVoteCount):
            nameToVoteCount[vote] -= 1
        else:
            nameToVoteCount[vote] = -1
    #use a minimum heap to find candidate(s) with highest vote
    heap = MinHeap()
    candidateArray = [(x,nameToVoteCount[x]) for x in nameToVoteCount.keys()]
    heap.heapifyArray(candidateArray)

    #extract the all the max vote candidate
    maxVoteCandidate = []
    maxVote = heap.peek()[1]
    while(heap.size() > 1 and heap.peek()[1] == maxVote):
        maxVoteCandidate.append(heap.pop()[0])
    
    electedCandidate = sorted(maxVoteCandidate)[len(maxVoteCandidate)-1]
    return electedCandidate

with open('candidateInput.txt') as file:
	votes = []
	for line in file.readlines():
		votes.append(line.rstrip())
	print(electionWinner(votes))

votes = ['alex', 'michael', 'harry', 'dave', 'michael','victor','harry','alex','mary','mary']
