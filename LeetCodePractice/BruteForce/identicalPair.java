/*
find the total number of identical pair which have different index but same value, not counting dulicate pair
*/
    public int solution(int[] A) {
    //if number a occur N times in A, then the fisrt occurance of a must have of N-1 identical pair.
    //and second occurance of a must have N-2 identical pairs and so on.
    //thus, for the kth occurance of a must have N-k-1 identical pair.
    //and the total identical pair for all a is N-1 + N-2 + .... 1
    //or simply summaries as (N-1+1)*(N-1-1+1)/2 = N*(N-1)/2
    //using this information, we can map the each value with its number of occurance
    //then calculate the identiacal pair for each value and sum it up
        //base case
        if(A.length < 2)
            return 0;
            
        HashMap<Integer, Integer> valueToCount = new HashMap();
        //loop once to set up the map
        for(int i : A){
            if(valueToCount.containsKey(i))
                valueToCount.put(i, valueToCount.get(i)+1);
            else
                valueToCount.put(i,1);
        }
        int total = 0;
        //loop to accumulate number of identical pair
        for(Integer i : valueToCount.keySet()){
            int count = valueToCount.get(i);
            total += count*(count-1)/2;
        }
        return total;
    }