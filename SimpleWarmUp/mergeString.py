'''
append two string a,b together alternatively
'''

def  mergeStrings(a, b):
    #swap a, b if b is a longer string
    shorterStringLen, longerString, mergeString = 0, '', ''
    if(len(a)<len(b)):
        shorterStringLen = len(a)
        longerString = b
    else:
        shorterStringLen = len(b)
        longerString = a

	#loop to append character from a and b alternatively until shorterStringLen
    for i in range(shorterStringLen):
        mergeString += a[i]+b[i]

    #add the rest of longer string to mergeString
    mergeString += longerString[shorterStringLen:len(longerString)]

    return mergeString

print(mergeStrings("ads","adsf"))
