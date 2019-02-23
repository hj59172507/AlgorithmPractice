/*
Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.
*/

//Solution 1 using DFS
    public int numIslands(char[][] grid) {
        //base case 
        if(grid.length == 0 || grid[0].length == 0)
            return 0;
        int row = grid.length;
        int col = grid[0].length;
        int islands = 0;
        //set up 2d boolean grid to store position visited
        boolean [][] visited = new boolean[row][col];
        for(int i=0;i<row;i++){
            for(int j=0;j<col;j++){
                //explore the position if it is not visited and not water
                if(!visited[i][j] && grid[i][j] == '1'){
                    islands++;
                    visit(visited, grid, i, j);
                }
            }
        }
        return islands;
    }
    
    //explore all direction of given point by calling visit
    public void explore(boolean[][] visited, char[][] grid, int x, int y){
        int maxX = visited.length;
        int maxY = visited[0].length;
        //visit up if new position is within bound and not visited
        if(checkLowerBound(y-1, 0) && !visited[x][y-1]){
            visit(visited, grid, x, y-1);
        }
        //visit down recursively if new position is within bound and not visited
        if(checkUpperBound(y+1, maxY) && !visited[x][y+1]){
            visit(visited, grid, x, y+1);
        }
        //visit left recursively if new position is within bound and not visited
        if(checkLowerBound(x-1, 0) && !visited[x-1][y]){
            visit(visited, grid, x-1, y);
        }
        //visit right recursively if new position is within bound and not visited
        if(checkUpperBound(x+1, maxX) && !visited[x+1][y]){
            visit(visited, grid, x+1, y);
        }
        
    }
    
    //visit this position, and call explore to search other directions of given position
    public void visit(boolean[][] visited, char[][] grid, int x, int y){
        visited[x][y] = true;
        //continue to explore if this position is island
        if(grid[x][y] == '0')
            return;
        explore(visited, grid, x, y);
    }
    
    //check upper bound 
    public boolean checkUpperBound(int d, int maxD){
        return d < maxD;
    }
    
    //check lower bound
    public boolean checkLowerBound(int d, int minD){
        return d >= 0 ;
    }

//solution 2: using DFS
    public int numIslands(char[][] grid) {
        if (grid == null || grid.length == 0) {
          return 0;
        }

        int nr = grid.length;
        int nc = grid[0].length;
        int num_islands = 0;

        for (int r = 0; r < nr; ++r) {
          for (int c = 0; c < nc; ++c) {
            if (grid[r][c] == '1') {
              ++num_islands;
              grid[r][c] = '0'; // mark as visited
              Queue<Integer> neighbors = new LinkedList<>();
              neighbors.add(r * nc + c);
              while (!neighbors.isEmpty()) {
                int id = neighbors.remove();
                int row = id / nc;
                int col = id % nc;
                //visit up
                if (row - 1 >= 0 && grid[row-1][col] == '1') {
                  neighbors.add((row-1) * nc + col);
                  grid[row-1][col] = '0';
                }
                //visit down
                if (row + 1 < nr && grid[row+1][col] == '1') {
                  neighbors.add((row+1) * nc + col);
                  grid[row+1][col] = '0';
                }
                //visit left
                if (col - 1 >= 0 && grid[row][col-1] == '1') {
                  neighbors.add(row * nc + col-1);
                  grid[row][col-1] = '0';
                }
                //visit right
                if (col + 1 < nc && grid[row][col+1] == '1') {
                  neighbors.add(row * nc + col+1);
                  grid[row][col+1] = '0';
                }
              }
            }
          }
        }

        return num_islands;
    }