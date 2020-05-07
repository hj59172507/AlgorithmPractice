import math

def DijkstrasSimple(graph, source, target, lengthG):
	while(len(target) != 0):
		minWeight = math.inf
		nextAddedNode = 0
		sourceNode = 0
		for node in source:
			for nodeWeightPair in graph[node]:
				if(nodeWeightPair[0] in target and nodeWeightPair[1] + lengthG[node] < minWeight):
					minWeight = nodeWeightPair[1] + lengthG[node]
					nextAddedNode = nodeWeightPair[0]
					sourceNode = node
		source.append(nextAddedNode)
		target.remove(nextAddedNode)
		lengthG[nextAddedNode] = lengthG[sourceNode] + minWeight



#process input and create a graph with weights
graph = {}
lengthG = {}
targetVector = []
f = open("dijkstraData.txt","r")
for line in f.read().splitlines():
	data = line.split()
	node = int(data[0])
	graph[node] = []
	targetVector.append(node)
	lengthG[node] = math.inf
	for i in range(1,len(data)):
		nodeWeightPair = data[i].split(",")
		graph[node].append([int(nodeWeightPair[0]),int(nodeWeightPair[1])])

#let node 1 be the source
sourceNode = 1
sourceVector = [sourceNode]
targetVector.remove(sourceNode)
lengthG[sourceNode] = 0

DijkstrasSimple(graph, sourceVector, targetVector, lengthG)

print(lengthG)

