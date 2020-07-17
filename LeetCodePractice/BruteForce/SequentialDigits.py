"""
1291. Sequential Digits

An integer has sequential digits if and only if each digit in the number is one more than the previous digit.

Return a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.

Example 1:

Input: low = 100, high = 300
Output: [123,234]
Example 2:

Input: low = 1000, high = 13000
Output: [1234,2345,3456,4567,5678,6789,12345]

Constraints:

10 <= low <= high <= 10^9

Sol
Time O(len(high) - len(low))
Space O(len(high) - len(low))
while candidate < high, we define a max number for any number with length l, so for l = 4, max = 6789
We get all candidate with by increment of 1 repeated l time, and check if < high and >= low
"""
from typing import List


class Solution:
    def sequentialDigits(self, low: int, high: int) -> List[int]:
        res = []
        startL = len(str(low))
        start = 1
        cMax = 9
        increment = 1
        for i in range(2, startL+1):
            start = start*10 + i
            cMax = cMax + (cMax//(10**(i-2))-1)*(10**(i-1))
            increment = increment*10 + 1
        candidate = start
        while candidate <= high:
            if candidate >= low:
                res.append(candidate)
            candidate += increment
            if candidate > cMax:
                start = start * 10 + start % 10 + 1
                candidate = start
                cMax = cMax + (cMax // (10 ** (i - 1)) - 1) * (10 ** (i))
                i += 1
                increment = increment*10 + 1
        return res


s = Solution()
l , h = 10, 1000
print(s.sequentialDigits(l, h))

