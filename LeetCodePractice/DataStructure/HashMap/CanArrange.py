"""
1497. Check If Array Pairs Are Divisible by k

Given an array of integers arr of even length n and an integer k.

We want to divide the array into exactly n / 2 pairs such that the sum of each pair is divisible by k.

Return True If you can find a way to do that or False otherwise.

Example 1:

Input: arr = [1,2,3,4,5,10,6,7,8,9], k = 5
Output: true
Explanation: Pairs are (1,9),(2,8),(3,7),(4,6) and (5,10).
Example 2:

Input: arr = [1,2,3,4,5,6], k = 7
Output: true
Explanation: Pairs are (1,6),(2,5) and(3,4).
Example 3:

Input: arr = [1,2,3,4,5,6], k = 10
Output: false
Explanation: You can try all possible pairs to see that there is no way to divide arr into 3 pairs each with sum divisible by 10.
Example 4:

Input: arr = [-10,10], k = 2
Output: true
Example 5:

Input: arr = [-1,1,-2,2,-3,3,-4,4], k = 3
Output: true

Constraints:

arr.length == n
1 <= n <= 10^5
n is even.
-10^9 <= arr[i] <= 10^9
1 <= k <= 10^5

Sol
Time O(n)
Space O(k)
We can keep a count of freq of a % k, check that f[a%k] == f[k-a%k]
If a % k == a, check that f[a%k] is even. also check f[0] is even
*note that different language handle module differently when it comes to negative number:
https://torstencurdt.com/tech/posts/modulo-of-negative-numbers/#:~:text=The%20modulo%20operator%20returns%20the,negative%20numbers%20into%20the%20mix.&text=Doing%20an%20integer%20division%20and,by%20n%20without%20a%20remainder.
For java, we can use ((a % k) + k ) % k to handle negative number
"""
from typing import List


class Solution:
    def canArrange(self, arr: List[int], k: int) -> bool:
        f = [0 for i in range(k)]
        for i in arr:
            f[i % k] += 1
        if f[0] % 2 != 0:
            return False
        if k % 2 == 0 and f[k//2] % 2 != 0:
            return False
        for i in range(1, k//2 + 1):
            if f[i] != f[k-i]:
                return False
        return True

