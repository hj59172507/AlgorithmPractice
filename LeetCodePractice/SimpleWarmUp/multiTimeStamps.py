'''
Given a filename, and parse the timeStamp in each line, return timeStamps that appear more than once in req_filename file
'''

import os

#parse timeStamp in the format DD/mmm/YYYY:HH:MM:SS from a line at index i
def parseTimeStamp(string, i):
    #first split entire line and get timeStamp, and only take the portion before '-'
    timeStamp = string.split()[i].split('-')[0]
    #ignore the first '[' and last space ' '
    return timeStamp[1:len(timeStamp)]


# read the string filename
filename = input()

timeStampIndex = 3
timeStamps = set()
multiTimeStamps = set()

#loop all input lines and add timeStamps to multiTimeStamps only if we see it in timesStamps before
with open(filename) as file:
    for line in file:
        timeStamp = parseTimeStamp(line, timeStampIndex)
        if(timeStamp in timeStamps):
            multiTimeStamps.add(timeStamp)
        timeStamps.add(timeStamp)


#loop to write everything in multiTimeStamps to outFile, line ending depends on current os
outFileHeader = 'req_'
with open(outFileHeader+filename, 'w') as outFile:
    for timeStamp in multiTimeStamps:
        outFile.write(timeStamp+os.linesep)