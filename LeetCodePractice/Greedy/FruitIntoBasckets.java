/*
In a row of trees, the i-th tree produces fruit with type tree[i].
You start at any tree of your choice, then repeatedly perform the following steps:
Add one piece of fruit from this tree to your baskets.  If you cannot, stop.
Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.
Note that you do not have any choice after the initial choice of starting tree: you must perform step 1, then step 2, then back to step 1, then step 2, and so on until you stop.
You have two baskets, and each basket can carry any quantity of fruit, but you want each basket to only carry one type of fruit each.
What is the total amount of fruit you can collect with this procedure?
*/

    public int totalFruit(int[] tree) {
        //base case
        if(tree.length < 3)
            return tree.length;
        //create arrayLists, one for each bascket, and one to keep track of last type of fruit
        ArrayList<Integer> bascket1 = new ArrayList();
        ArrayList<Integer> bascket2 = new ArrayList();
        ArrayList<Integer> lastFruit = new ArrayList();
        
        int total = 0, temp = 0;
        //loop the row of tree 
        for(int i=0;i<tree.length;i++){
            int fruit = tree[i];
            //put the fruit into empty bascket, or bascket of same type is possible
            if(bascket1.isEmpty() || fruit == bascket1.get(0)){
                bascket1.add(fruit);
                temp++;
                updateLastFruit(lastFruit, fruit);
            }else if(bascket2.isEmpty() || fruit == bascket2.get(0)){
                bascket2.add(fruit);
                temp++;
                updateLastFruit(lastFruit, fruit);
            }else{
            //if we are here, two basckets are not empty and fruit is a new type
            //we update the total count
            //we empty one backset and copy fruit of lastFruit to another one, update temp and continue collecting
                if(temp > total)
                    total = temp;
                bascket1.clear();
                bascket1.add(fruit);
                bascket2.clear();
                for(Integer j : lastFruit){
                    bascket2.add(new Integer(j));
                }
                temp = bascket2.size() + 1;
                updateLastFruit(lastFruit,fruit);
            }
            if(temp > total)
                total = temp;
        }
        return total; 
    }
    
    public void updateLastFruit(ArrayList<Integer> lastFruit, int fruit){
        //update lastFruit
        if(lastFruit.isEmpty() || fruit == lastFruit.get(0)){
            lastFruit.add(fruit);
        }else{
            lastFruit.clear();
            lastFruit.add(fruit);
        }
    }