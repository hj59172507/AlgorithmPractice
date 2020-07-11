"""
find the length of longest monotonically increasing subsequence of n numbers

Sol
Time O(nlogn)
Space O(n)
Let b[i] be the last element of longest increasing subsequence of length i, which init to infinity
Let loop arr, each time use binary search to find the index largest j such that b[j] < arr[current_iteration]
We update b[j+1] to arr[current_iteration] and update our solution if j+1 > max
"""


def longestMonoSubsequence(arr):
    b = [float('inf')] * len(arr)
    l = 1
    for i in range(len(arr)):
        if arr[i] < b[0]:
            b[0] = arr[i]
        else:
            j = binarySearch(arr[i], b, 0, i)
            if j != -1:
                b[j + 1] = arr[i]
                l = max(l, j + 2)
    print(l)
    print(b)


# find the largest index i in arr such that arr[i] < target
def binarySearch(target, arr, left, right):
    while left <= right:
        mid = (left + right + 1) // 2
        if arr[mid] < target:
            if mid + 1 < len(arr) and target < arr[mid + 1]:
                # if current index i satisfy arr[i] < target, and next index arr[i+1] > target, i must be answer
                return mid
            left = mid + 1
        else:
            right = mid - 1
    return -1


a = [1, 3, 6, 8, 2, 4, 6, 89, 111]
longestMonoSubsequence(a)
