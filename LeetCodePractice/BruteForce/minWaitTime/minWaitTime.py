'''
Tieu owns a pizza restaurant and he manages it in his own way. While in a normal restaurant, a customer is served by following the first-come, first-served rule, Tieu simply minimizes the average waiting time of his customers. So he gets to decide who is served first, regardless of how sooner or later a person comes.

Different kinds of pizzas take different amounts of time to cook. Also, once he starts cooking a pizza, he cannot cook another pizza until the first pizza is completely cooked. Let's say we have three customers who come at time t=0, t=1, & t=2 respectively, and the time needed to cook their pizzas is 3, 9, & 6 respectively. If Tieu applies first-come, first-served rule, then the waiting time of three customers is 3, 11, & 16 respectively. The average waiting time in this case is (3 + 11 + 16) / 3 = 10. This is not an optimized solution. After serving the first customer at time t=3, Tieu can choose to serve the third customer. In that case, the waiting time will be 3, 7, & 17 respectively. Hence the average waiting time is (3 + 7 + 17) / 3 = 9.

Help Tieu achieve the minimum average waiting time. For the sake of simplicity, just find the integer part of the minimum average waiting time.

In the N lines, the ith line contains two space separated numbers Ti and Li. Ti is the time when ith customer order a pizza, and Li is the
time required to cook that pizza.

Display the integer part of the minimum average waiting time.
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

    def size(self):
        return len(self.heap)

#move customers from customers to heap if they arrive before or on arriveTime
def addArrivedCustomer(nextServeCandidates, customers, arriveTime):
	while(len(customers) > 0 and customers[0][0] <= arriveTime):
		nextServeCandidates.insert(customers[0])
		del customers[0]

def minimumAverage(customers):
	#sort by arrive time
	customers = sorted(customers, key = lambda x:x[0])
	firstArriveTime, customersCount, servedCustomerCount = customers[0][0], len(customers), 0
	nextServeCandidates = MinHeap()
	addArrivedCustomer(nextServeCandidates, customers, firstArriveTime)

	totalWaitTime = 0
	currentTime = firstArriveTime

	#loop to handle one customer at a time
	while(servedCustomerCount != customersCount):
		#there is at least one customer in line, pop the one with least pizza cooking time
		if(nextServeCandidates.size()>0):
			customer = nextServeCandidates.pop()
			#cook the order of above customer
			currentTime += customer[1]
			#add his/her wait time to totalWaitTime, which is define by currentTime - time he/she arrived
			totalWaitTime += currentTime - customer[0]
			servedCustomerCount += 1
			#add more arrived customer according to currentTime
			if(len(customers) > 0):
				addArrivedCustomer(nextServeCandidates, customers, currentTime)
		#skip to the time next customer arrives if there are more customers in future
		elif(len(customers) > 0):
			currentTime = customers[0][0]
			addArrivedCustomer(nextServeCandidates, customers, currentTime)
	return int(totalWaitTime/customersCount)


customers = []
with open('input.txt') as file:
	for data in file.readlines():
		customers.append([int(x) for x in data.split()])


print(minimumAverage(customers))
