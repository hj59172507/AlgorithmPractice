/*
Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
An input string is valid if:
Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Note that an empty string is also considered valid.
*/
    public boolean isValid(String s) {
        char[] stack = new char[s.length()];
        int count = 0;
        for(char c : s.toCharArray()){
            if(c == '(' || c == '{' || c == '[')
                stack[count++] = c;
            else{
                if(count == 0)
                    return false;
                char temp = stack[--count];
                if( (c == ')' && temp != '(') || (c == ']' && temp != '[') || (c == '}' && temp != '{'))
                    return false;
            }
        }
        return count == 0;
    }