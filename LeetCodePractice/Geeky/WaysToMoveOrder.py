import math

'''
1359. Count All Valid Pickup and Delivery Options

Given n orders, each order consist in pickup and delivery services. 

Count all valid pickup/delivery possible sequences such that delivery(i) is always after of pickup(i). 

Since the answer may be too large, return it modulo 10^9 + 7.

Example 1:

Input: n = 1
Output: 1
Explanation: Unique order (P1, D1), Delivery 1 always is after of Pickup 1.
Example 2:

Input: n = 2
Output: 6
Explanation: All possible orders: 
(P1,P2,D1,D2), (P1,P2,D2,D1), (P1,D1,P2,D2), (P2,P1,D1,D2), (P2,P1,D2,D1) and (P2,D2,P1,D1).
This is an invalid order (P1,D2,P2,D1) because Pickup 2 is after of Delivery 2.
Example 3:

Input: n = 3
Output: 90

Constraints:

1 <= n <= 500

Sol
Time O(n)
Space O(1)
For n orders, there is 2n - 1 way to pick up the order, and if pick up at position i, then will be 2n - i way to deliver
the order. e.g. We have 3 orders, we can pick up at time 1, 2, 3, 4, or 5, each associated with 5, 4, 3, 2, or 1 ways to
delivery it. So, number of way to pick up and deliver first order if we have n orders is given by 2n^2 - n. We multiple 
from n to 1, and arrive at final answer.
'''


class Solution:
    def countOrders(self, n: int) -> int:
        return int(self.comb(n) % 1000000007)
        # shortcut: return int((math.factorial(n * 2) >> n) % (10**9 + 7))

    def comb(self, n: int) -> int:
        if n == 1:
            return 1
        else:
            t = 2 * n
            return (self.comb(n - 1) * (t * (t - 1)) / 2) % 1000000007


s = Solution()
print(s.countOrders(18))
