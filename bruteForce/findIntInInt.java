/*
Give two int A and B, find the index of left most occurance of A in B
*/
    public int solution(int A, int B) {
        //base case 
        if(B<A)
            return -1;
        if(B==A)
            return 0;
        ArrayList<Integer> blist = new ArrayList();
        ArrayList<Integer> alist = new ArrayList();
        
        //prevent the case A is 0
        alist.add(A%10);
        A = A/10;
        
        while(B != 0){
            blist.add(B%10);
            B = B/10;
        }
        while(A != 0){
            alist.add(A%10);
            A = A/10;
        }
        int result = -1;
        for(int i=blist.size()-1;i>=alist.size()-1;i--){
            int matchCount = 0;
            for(int j=0;j<alist.size();j++){
                if(blist.get(i-j) == alist.get(alist.size()-j-1))
                    matchCount++;
            }
            if(matchCount == alist.size())
                result = blist.size()-i-1;             
        }
        return result;
    }