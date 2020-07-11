"""
1505. Minimum Possible Integer After at Most K Adjacent Swaps On Digits

Given a string num representing the digits of a very large integer and an integer k.

You are allowed to swap any two adjacent digits of the integer at most k times.

Return the minimum integer you can obtain also as a string.

Example 1:

Input: num = "4321", k = 4
Output: "1342"
Explanation: The steps to obtain the minimum integer from 4321 with 4 adjacent swaps are shown.
Example 2:

Input: num = "100", k = 1
Output: "010"
Explanation: It's ok for the output to have leading zeros, but the input is guaranteed not to have any leading zeros.
Example 3:

Input: num = "36789", k = 1000
Output: "36789"
Explanation: We can keep the number without any swaps.
Example 4:

Input: num = "22", k = 22
Output: "22"
Example 5:

Input: num = "9438957234785635408", k = 23
Output: "0345989723478563548"

Constraints:

1 <= num.length <= 30000
num contains digits only and doesn't have leading zeros.
1 <= k <= 10^9

Sol
Time O(nlogn)
Space O(n)
Observe that we are trying to find the smallest integer to right of current digit in a window of size k,
a brute force of n^2 would solve it but using Fenwick tree, we can achieve nlogn
Fenwick tree:https://en.wikipedia.org/wiki/Fenwick_tree
"""


class FenWick(object):
    def __init__(self, n):
        self.nums = [0] * (1 + n)

    def update(self, i, delta):
        while i < len(self.nums):
            self.nums[i] += delta
            i += i & -i

    def query(self, i):
        ans = 0
        while i > 0:
            ans += self.nums[i]
            i -= i & -i
        return ans


class Solution:
    def minInteger(self, num: str, k: int) -> str:
        n = len(num)
        pos = [[] for _ in range(10)]
        for i in range(n - 1, -1, -1):
            pos[ord(num[i]) - ord('0')].append(i)

        def find_best():
            for d in range(10):
                if not pos[d]: continue
                i = pos[d][-1]
                cost = i - tree.query(i)
                if cost <= k: return d, cost
            return None, None

        tree = FenWick(n)
        res = []
        removed = [False] * n

        while k:
            d, cost = find_best()
            if d is None: break
            k -= cost
            res.append(d)
            i = pos[d].pop()
            tree.update(i + 1, 1)
            removed[i] = True

        lhs = ''.join(str(d) for d in res)
        rhs = ''.join(num[i] for i in range(n) if not removed[i])
        return lhs + rhs


s = Solution()
num = '4321'
k = 4
print(s.minInteger(num, k))

