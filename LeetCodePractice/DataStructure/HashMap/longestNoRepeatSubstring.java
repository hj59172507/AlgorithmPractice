/*
Given a string, find the length of the longest substring without repeating characters.
*/

public int lengthOfLongestSubstring(String s) {
    //base case
    if(s.length() < 2)
        return s.length();
    //use hashMap to keep track of the index of each appeared character
    HashMap<Character, Integer> charFirstAppear = new HashMap();
    int max = 0, temp = 0, lastRep = 0;
    //loop each character to check if it is part of longest substring
    for(int i=0;i<s.length();i++){
        char c = s.charAt(i);
        //if appeared before, update temp length
        if(charFirstAppear.containsKey(c) && charFirstAppear.get(c) >= lastRep){
            temp = i - charFirstAppear.get(c);
            last = charFirstAppear.get(c);
            charFirstAppear.put(c,i);
        }
        //never seem before, increment length and store into hashmap
        else{
            temp++;
            if(temp > max)
                max = temp;
            charFirstAppear.put(c,i);
        }
    }
    return max;
}
