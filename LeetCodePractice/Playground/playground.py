def cellCompete(states, days):
    # WRITE YOUR CODE HERE
    prevStates = [0] + states + [0]
    newStates = [i for i in prevStates]
    print(len(states), len(prevStates), len(newStates))
    for i in range(days):
        for j in range(1, len(states)+1):
            newStates[j] = 1 if prevStates[j-1] != prevStates[j+1] else 0
        prevStates = [i for i in newStates]
    return newStates[1:len(newStates)]

s = [1,0,0,0,0,1,0,0]
d = 1
print(cellCompete(s, d))