'''
Jesse loves cookies. He wants the sweetness of all his cookies to be greater than value . To do this, Jesse repeatedly mixes two cookies with the least sweetness. He creates a special combined cookie with:

sweetness = Least sweet cookie  + 2* 2nd least sweet cookie

He repeats this procedure until all the cookies in his collection have a sweetness >= k
You are given Jesse's cookies. Print the number of operations required to give the cookies a sweetness >= k

The first line contains the minimum required sweetness k
The next line contains integers describing the array

Output the number of operations that are needed to increase the cookie's sweetness . 
Output -1 if this isn't possible.
'''

import heapq
#k is minimum sweetness, A is the array of cookies unordered
def cookies(k, A):
    #base case
    if(k == 0):
        return 0
    if(len(A)==0):
        return -1
    if(len(A)==1 and A[0] < k):
        return -1
    if(len(A)==1 and A[0] >= k):
        return 0

    #handle case there k != 0, and there is at least two elements in A
    heapq.heapify(A)
    operation = 0
    if(A[0] >= k):
        return operation
    while(A[0] < k and len(A) > 1):
        operation += 1
        least = heapq.heappop(A)
        secLeast = heapq.heappop(A)
        heapq.heappush(A,least+secLeast*2)
        if(A[0] >= k):
            return operation
    return -1