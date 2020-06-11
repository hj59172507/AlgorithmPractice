"""
1354. Construct Target Array With Multiple Sums

Given an array of integers target. From a starting array, A consisting of all 1's, you may perform the following procedure :

let x be the sum of all elements currently in your array.
choose index i, such that 0 <= i < target.size and set the value of A at index i to x.
You may repeat this procedure as many times as needed.
Return True if it is possible to construct the target array from A otherwise return False.

Example 1:

Input: target = [9,3,5]
Output: true
Explanation: Start with [1, 1, 1]
[1, 1, 1], sum = 3 choose index 1
[1, 3, 1], sum = 5 choose index 2
[1, 3, 5], sum = 9 choose index 0
[9, 3, 5] Done
Example 2:

Input: target = [1,1,1,2]
Output: false
Explanation: Impossible to create target array from [1,1,1,1].
Example 3:

Input: target = [8,5]
Output: true

Constraints:

N == target.length
1 <= target.length <= 5 * 10^4
1 <= target[i] <= 10^9

Sol
Time O
Space O(n)
Note that in target array, the max value is form by its previous value + rest.
1.We put all values into a max heap, and each time we take out max value in current heap.
2.Find the previous value of max: sum of rest = sum - max, previousMax = max - sum of rest
3.Put the previous max back into heap, and update sum
4.Repeat this step until sum = n, which we return true, or previousMax < 0, which we return false
Use of % to speed up the process for extreme cases like [1, 10000000]:
Assume we have [max, i], and max is way bigger than i,
by above backtracking algorithm, in each iteration, we would get [max - i, i],
and at n iteration, we have [max - n*i, i], until max - n*i < i.
But it is the same as max % i.
"""
from typing import List
import heapq


def isPossible(target: List[int]) -> bool:
    maxHeap = [-x for x in target]
    heapq.heapify(maxHeap)
    total = sum(target)
    while True:
        currentMax = -heapq.heappop(maxHeap)
        total -= currentMax
        if total == 1 or currentMax == 1:
            return True
        if currentMax < total or total == 0 or currentMax % total == 0:
            return False
        currentMax %= total
        total += currentMax
        heapq.heappush(maxHeap, -currentMax)
    return True


print(isPossible([9, 3, 5]))
print(isPossible([1, 1, 1, 2]))
print(isPossible([1,1000000000]))
