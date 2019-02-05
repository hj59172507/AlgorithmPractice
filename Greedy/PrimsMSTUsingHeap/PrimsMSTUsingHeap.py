'''
The edges.txt describes an undirected graph with integer edge costs. It has the format

[one_node_of_edge_1] [other_node_of_edge_1] [edge_1_cost]

[one_node_of_edge_2] [other_node_of_edge_2] [edge_2_cost]

For example, the third line of the file is "2 3 -8874", indicating that there is an edge connecting vertex #2 and vertex #3 that has cost -8874.

edge costs are not necessary positive, nor distinct.
'''

#process input data
remainV, processedV, edges, edgesInMST, edgeCosts = set(), set(), {}, {}, []
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
		edgeCosts.append((v1+'-'+v2,int(cost)))
		edgeCosts.append((v2+'-'+v1,int(cost)))

#set up intial state for Prims algorithm
initialNode = remainV.pop()
processedV.add(initialNode)
#set up intial heap using only the initial node

#perform Prims algorithm 
while(len(remainV) != 0):
	#pop the heap, that is our next node n in MST
	
	#add n to processedV, remove it from remainV

	#for any node w in remainV that is connected to n, if w is in heap, pop, revaluate, and push back to the heap
