"""
1481. Least Number of Unique Integers after K Removals

Given an array of integers arr and an integer k. Find the least number of unique integers after removing exactly k elements.

Example 1:

Input: arr = [5,5,4], k = 1
Output: 1
Explanation: Remove the single 4, only 5 is left.
Example 2:
Input: arr = [4,3,1,1,3,3,2], k = 3
Output: 2
Explanation: Remove 4, 2 and either one of the two 1s or three 3s. 1 and 3 will be left.

Constraints:

1 <= arr.length <= 10^5
1 <= arr[i] <= 10^9
0 <= k <= arr.length

Sol
Time O(n)
Space O(n)
Map each value with its frequency
Use bucket sort to remove least frequent element
"""
from typing import  List
from collections import Counter

class Solution:
    def findLeastNumOfUniqueInts(self, arr: List[int], k: int) -> int:
        c = Counter(arr)
        bucket = [[] for i in range(len(arr)+1)]
        for key, count in c.items():
            bucket[count].append(key)
        for i in range(1, len(arr)+1):
            if k == 0:
                break
            while bucket[i] and k >= i:
                del c[bucket[i].pop()]
                k -= i
        return len(c)