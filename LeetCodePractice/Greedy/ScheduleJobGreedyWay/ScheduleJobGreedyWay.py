'''
The jobs.txt file describes a set of jobs with positive and integral weights and lengths. It has the format

[job_1_weight] [job_1_length]

[job_2_weight] [job_2_length]

For example, the third line of the file is "74 59", indicating that the second job has weight 74 and length 59.

You should NOT assume that edge weights or lengths are distinct.
'''
#esay sample to check correctness jobsTuple  =[(1/2,1,2),(3/5,3,5)]
#jobTuple will store the ratio of weight and length, weight, and length. The higher the ratio, the higher priority of the job
inputFile, jobsTuple = "jobs.txt", []
with open(inputFile) as jobsFile:
	jobs = jobsFile.readlines()
	for job in jobs:
		weight, length = int(job.split()[0]), int(job.split()[1])
		jobsTuple.append((weight/length, weight, length))


#sort the tuple base on weight/length
sortedJobsTuple = sorted(jobsTuple, key = lambda x:x[0], reverse = True)

#compute total cost, which is definte by time a job finsih multiple by its weight
timeFinish = 0
totalCost = 0
for jobTuple in sortedJobsTuple:
	timeFinish += jobTuple[2]
	totalCost += jobTuple[1]*timeFinish

print(totalCost)


