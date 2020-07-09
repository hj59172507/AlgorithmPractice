import random


# sort arr using quick sort with left tail recursion to save stack memory space
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
