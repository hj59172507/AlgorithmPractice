'''
The edges.txt describes an undirected graph with integer edge costs. It has the format

[one_node_of_edge_1] [other_node_of_edge_1] [edge_1_cost]

[one_node_of_edge_2] [other_node_of_edge_2] [edge_2_cost]

For example, the third line of the file is "2 3 -8874", indicating that there is an edge connecting vertex #2 and vertex #3 that has cost -8874.

edge costs are not necessary positive, nor distinct.
'''
import heapq

#process input data
remainV, processedV, edges, edgesInMST, edgeCosts = set(), set(), {}, {}, {}
inputFile = 'edges.txt'
with open(inputFile) as edgesFile:
	edgesAndCosts = edgesFile.readlines()
	for edgeAndCost in edgesAndCosts:
		v1, v2, cost = edgeAndCost.split()
		remainV.update([v1,v2])
		if(v1 in edges):
			edges[v1].append(v2)
		else:
			edges[v1] = [v2]
		if(v2 in edges):
			edges[v2].append(v1)
		else:
			edges[v2] = [v1]
		edgeCosts[v1+'-'+v2] = int(cost)
		edgeCosts[v2+'-'+v1] = int(cost)

#small example to test
remainV = {'1','2','3','4'}
edges = {'1':['2','3','4'],'2':['1','3'],'3':['2','1','4'],'4':['1','3']}
edgeCosts = {'1-2':5,'2-1':5,'1-3':1,'3-1':1,'1-4':4,'4-1':4,'3-2':2,'2-3':2,'3-4':3,'4-3':1}

#set up intial state for Prims algorithm
initialNode = remainV.pop()
processedV.add(initialNode)
#set up intial heap using only the initial node
heap = []
for node in processedV:
	#get all edge containing node 
	for node2 in edges[node]:
		key = node+'-'+node2
		cost = edgeCosts[key]
		heap.append((key,cost))


#perform Prims algorithm 
while(len(remainV) != 0):
	#pop the heap, that is our next node n in MST
	minItem = heapq.nsmallest(1,heap,key=lambda x:x[1])
	heap.remove(minItem[0])
	nodes, cost = minItem[0][0], minItem[0][1]
	edgesInMST[nodes] = cost
	node1, node2 = nodes.split('-')
	#add n to processedV, remove it from remainV
	if(node1 in remainV):
		processedV.add(node1)
		remainV.remove(node1)
	else:
		processedV.add(node2)
		remainV.remove(node2)
	#for any node w in remainV that is connected to n, if w is in heap, pop, revaluate, and push back to the heap
	for node3 in edges[node2]:
		if(node3 in remainV):
			key = node2+'-'+node3
			cost = edgeCosts[key]
			heapq.heappush(heap,(key,cost))

print(processedV)
print(edgesInMST)
			
