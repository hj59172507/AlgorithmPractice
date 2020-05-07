#find all region in a grid and store in the list L
def getRegions(L, grid):
	visited = []
	for i in range(len(grid)):
		visited.append([])
		for j in range(len(grid[i])):
			visited[i].append(0)
	for i in range(len(grid)):
		for j in range(len(grid[i])):
			region = set()
			if(visited[i][j] != 1 and grid[i][j] == '1'):
				region = getRegion(grid, i, j, visited)  
			if(region != set() and region not in L):
				L.append([region])

#explore a region given starting point x, y 
def getRegion(grid, x, y, visited):
	if(visited[x][y] == 1 or grid[x][y] == '0'):
		return None
	visited[x][y] = 1;
	result = set()
	if(grid[x][y] == '1'):
		result.add((x,y))
	top, right, left, bot = None, None, None, None
	#visit all adj cells if within bound and not visited before
	if(x-1 >= 0 and visited[x-1][y] != 1):
		top = getRegion(grid, x-1, y, visited)
	if(y-1 >= 0 and visited[x][y-1] != 1):
		left = getRegion(grid, x, y-1, visited)
	if(x+1 < len(grid) and visited[x+1][y] != 1):
		bot = getRegion(grid, x+1, y, visited)
	if(y+1 < len(grid[x]) and visited[x][y+1] != 1):
		right = getRegion(grid, x, y+1, visited)
	if(top != None):
		for value in top:
			result.add(value)
	if(right != None):
		for value in right:
			result.add(value)
	if(left != None):
		for value in left:
			result.add(value)
	if(bot != None):
		for value in bot:
			result.add(value)
	return result

def countMatches(grid1, grid2):
    # Write your code here
    grid1Regions, grid2Regions = [], []
    getRegions(grid1Regions, grid1)
    getRegions(grid2Regions, grid2)
    result = 0
    for r in grid1Regions:
        if r in grid2Regions:
            result += 1
    return result

with open('matchGridInput.txt') as file:
	grid1, grid2 = [], []
	firstGirdRow = int(file.readline())
	for i in range(firstGirdRow):
		grid1.append(file.readline().rstrip())
	secondGridRow = int(file.readline());
	for i in range(secondGridRow):
		grid2.append(file.readline().rstrip())
	print(countMatches(grid1, grid2))