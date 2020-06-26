"""
1310. XOR Queries of a Subarray
Medium

211

11

Add to List

Share
Given the array arr of positive integers and the array queries where queries[i] = [Li, Ri], for each query i compute the XOR of elements from Li to Ri (that is, arr[Li] xor arr[Li+1] xor ... xor arr[Ri] ). Return an array containing the result for the given queries.


Example 1:

Input: arr = [1,3,4,8], queries = [[0,1],[1,2],[0,3],[3,3]]
Output: [2,7,14,8]
Explanation:
The binary representation of the elements in the array are:
1 = 0001
3 = 0011
4 = 0100
8 = 1000
The XOR values for queries are:
[0,1] = 1 xor 3 = 2
[1,2] = 3 xor 4 = 7
[0,3] = 1 xor 3 xor 4 xor 8 = 14
[3,3] = 8
Example 2:

Input: arr = [4,8,2,10], queries = [[2,3],[1,3],[0,0],[0,3]]
Output: [8,0,4,4]


Constraints:

1 <= arr.length <= 3 * 10^4
1 <= arr[i] <= 10^9
1 <= queries.length <= 3 * 10^4
queries[i].length == 2
0 <= queries[i][0] <= queries[i][1] < arr.length

Sol:
Time O(n)
Space O(n)
Let xorSum[i] store the result of xor from 0 to i
Then for query of xor i to j, simply take xorSum[j] xor xorSum[i] since if k = x xor y xor z, k xor z = x xor y
"""
from typing import List


class Solution:
    def xorQueries(self, arr: List[int], queries: List[List[int]]) -> List[int]:
        xorSum = [0] * (len(arr) + 1)
        res = []
        for i in range(1, len(arr) + 1):
            xorSum[i] = xorSum[i-1] ^ arr[i-1]
        for q in queries:
            res.append(xorSum[q[0]]^xorSum[q[1]+1])
        return res
