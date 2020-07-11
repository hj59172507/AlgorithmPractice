"""
1299. Replace Elements with Greatest Element on Right Side

Given an array arr, replace every element in that array with the greatest element among the elements to its right, and replace the last element with -1.

After doing so, return the array.

Example 1:

Input: arr = [17,18,5,4,6,1]
Output: [18,6,6,6,1,-1]

Constraints:

1 <= arr.length <= 10^4
1 <= arr[i] <= 10^5

Sol
Time O(n)
Space O(1)
set last element to variable Max, and last element in arr to -1
Then loop arr from second to last to first, set it to max, and update max
"""
from typing import List


class Solution:
    def replaceElements(self, arr: List[int]) -> List[int]:
        Max, arr[-1] = arr[-1], -1
        for i in range(len(arr)-2, -1, -1):
            t, arr[i] = arr[i], Max
            if t > Max:
                Max = t
        return arr
