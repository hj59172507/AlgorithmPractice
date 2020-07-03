n = 35
p = 1
c = 365
for i in range(n):
    p *= c / 365
    c -= 1
print(1 - p)