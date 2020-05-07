#change system setting to avoid recursion limit
import sys
sys.setrecursionlimit(65536)

#global variables
time = 0 
visited = {}
times = {}

#perform a depth fisrt search on graph starting from node, with all node visited marked as True and time add to it
def FirstDFS(graph, node):
	global visited
	global time 
	global times
	visited[node] = True
	for otherNode in graph[node]:
		if(not visited[otherNode]):
			FirstDFS(graph, otherNode)
	time += 1
	times[time] = node

#second DFS discover all SCC base on discover time found on first DFS
def SecondDFS(graph, node, scc):
	global visited
	visited[node] = True
	scc.append(node)
	for otherNode in graph[node]:
		if(not visited[otherNode]):
			SecondDFS(graph, otherNode, scc)

f = open("sccSmall.txt","r")

#contruct both regular graph, and graphRev which has edge reversed
graph = {}
graphRev = {}

for x in f.read().splitlines():
	node = int(x.split()[0])
	node2 = int(x.split()[1])
	if(node in graph):
		graph[node].append(node2)
	else:
		graph[node] = [node2]
	if(node2 in graphRev):
		graphRev[node2].append(node)
	else:
		graphRev[node2] = [node]



maxNode = max(graph.keys())
#give node with empty outgoing edge a placeholder
for i in range(1,maxNode+1):
	if(i not in graph.keys()):
		graph[i] = []
	if(i not in graphRev.keys()):
		graphRev[i] = []

#set up time and visited boolean for each node
keys = sorted(graph.keys())
for k in keys:
	times[k] = 0
	visited[k] = False

#call FirstDFS to set up times
maxNode = max(keys)
while(maxNode != 0):
	if(not visited[maxNode]):
		FirstDFS(graphRev, maxNode)
	maxNode -= 1

for k in keys:
	visited[k] = False

#call SecondDFS to report all scc base on time
scc = []
maxTime = max(times.keys())
while(maxTime != 0):
	tempScc = []
	if(not visited[times[maxTime]]):
		SecondDFS(graph, times[maxTime], tempScc)
	maxTime -= 1
	if(tempScc != []):
		scc.append(len(tempScc))

print(sorted(scc, reverse = True))



