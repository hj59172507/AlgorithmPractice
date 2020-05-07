import random, copy

def MinCutByRandomContraction(oriAdjList):
	
	#create a seprate copy of original graph data
	adjList = copy.deepcopy(oriAdjList)

	#iterate n-2 times, each time randomly pick an edge, merge the nodes connecting the edge. 
	for i in range(0,len(oriAdjList)-2):
		#get two random nodes
		nodeA = random.choice(list(adjList.keys()))
		nodeB = random.choice(adjList[nodeA])
		#remove nodeB from A and NodeA from B
		adjList[nodeA] = list(filter(lambda x: x != nodeB, adjList[nodeA]))
		adjList[nodeB] = list(filter(lambda x: x != nodeA, adjList[nodeB]))
		#add rest of node in B to A, and update other nodes connect to B to connect to A
		for node in adjList[nodeB]:
			adjList[nodeA].append(node)
			adjList[node] = [nodeA if x == nodeB else x for x in adjList[node]]
		#remove node B
		del adjList[nodeB]
	return len(adjList[random.choice(list(adjList.keys()))])



#preprocess the input, store data into a dictionary where key is the node id and value is a list of edges node connected to. 
#This is a undirected graph, if there is an edge from node a to b, then there must also be an edge from node b to a.
f = open("minCut.txt","r")
adjList = {}
n = 0
for x in f.read().splitlines():
	n += 1
	nums = x.split()
	key = int(nums[0])
	value = []
	for num in nums[1:len(nums)]:
		value.append(int(num))
	adjList[key] = value

#smaller data for demostration
#n = 5
#adjList = {1:[2,3,4],2:[1,3,4],3:[1,2,4,5],4:[1,2,3],5:[3]}
for i in adjList:
	print(len(adjList[i]))


#call contraction n times and record the minimum edges crossing
minCross = pow(n,2)//2
for i in range(0,n):
	temp = MinCutByRandomContraction(adjList)
	if(temp < minCross):
		minCross = temp
	print(f'iteration {i} temp {temp} min {minCross}')
print(minCross)