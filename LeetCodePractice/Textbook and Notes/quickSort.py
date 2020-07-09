import random


# sort arr using quick sort with left tail recursion to save stack memory space
# expected time is O(nlogn) with O(logn) recursion stack
def quick_sort(arr, l, r):
    while l < r:
        p = random_partition(arr, l, r)
        if r - p > p - l:
            quick_sort(arr, l, p - 1)
            l = p + 1
        else:
            quick_sort(arr, p + 1, r)
            r = p - 1


# choose a random pivot, and partition arr by arrange anything less than pivot be left of it
def random_partition(arr, l, r):
    p = random.randint(l, r)
    arr[p], arr[r] = arr[r], arr[p]
    j = l
    for i in range(l, r):
        if arr[i] < arr[r]:
            arr[i], arr[j] = arr[j], arr[i]
            j += 1
    arr[r], arr[j] = arr[j], arr[r]
    return j


arr = []
for i in range(50):
    arr.append(random.randint(0, 10))
print(arr)
quick_sort(arr, 0, len(arr) - 1)
print(arr)

# variation:
# 3 median pivot: randomly pick 3 indexes, and use median as pivot, it improves performance by constant factor
# Use insertion for small enough partition size k, run time is O(nk + nlog(n/k))
# since we stop if size of subarray is smaller than k, there are expected log(n/k) recursion
# to minimize O(nk + nlog(n/k)), we take derivative with respect to k and set to 0, we get n - n/k = 0
# hence when k = 1/n^2, we get minimum run time
