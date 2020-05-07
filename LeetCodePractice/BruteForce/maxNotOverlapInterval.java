/*
Given an array of int represent number of apple in each tree, and two length K and L.
Find the maximum number of apple can be picked by choosing not overlapping K and L
*/
public static void main(String[] args) {
        // TODO code application logic here
        int[] A = {6,1,4,6,3,2,7,4};
        int K = 3, L = 2;
        
        //base case
        if(K+L > A.length)
            return -1;
        int large = 0, small = 0, max = 0;
        large = K > L ? K : L;
        small = K <= L ? K : L;
        //fix the large consective 
        for(int i=0;i<A.length-large;i++){
            //fix the small consective and find their sum, save the sum if greater than max
            if(i>=small){
                //fix the small consective of the left of large
                for(int j=0;j<i-small;j++){
                    int temp = totalAppleIn(A, i, i+large) + totalAppleIn(A, j, j+small);
                    if(temp > max)
                        max = temp;
                }
            }
            if(i+large+small <= A.length){
                //fix the small consective of the right of large
                for(int j=i+large;j<=A.length-small;j++){
                    int temp = totalAppleIn(A, i, i+large) + totalAppleIn(A, j, j+small);
                    if(temp > max)
                        max = temp;
                }
            }
        }
        System.out.println(max);
    }
    
    public static int totalAppleIn(int[] A, int start, int end){
        int result = 0;
        for(int i=start;i<end;i++){
            result += A[i];
        }
        return result;
    }