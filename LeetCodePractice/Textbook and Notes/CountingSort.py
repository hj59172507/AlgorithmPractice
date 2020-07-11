import random

# for integer arr with values in range of 0 to k and size n, where k < n, we can use counting sort to sort in O(n)
def counting_sort(arr):
    k = max(arr)
    c = [0 for _ in range(k + 1)]
    b = [0 for _ in range(len(arr))]
    for i in range(len(arr)):
        # c store number of elements equal to i
        c[arr[i]] = c[arr[i]] + 1
    for i in range(1, k + 1):
        # now c store number of elements less than or equal to i
        c[i] = c[i] + c[i-1]
    for i in range(len(arr)-1, -1, -1):
        b[c[arr[i]] - 1] = arr[i]
        c[arr[i]] -= 1
    return b


arr = []
for i in range(20):
    arr.append(random.randint(0, 10))
print(arr)
print(counting_sort(arr))
