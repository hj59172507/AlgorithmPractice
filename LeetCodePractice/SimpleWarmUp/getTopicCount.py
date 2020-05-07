#find the occurrence of a topic from html

import requests

def  getTopicCount(topic):
    #base case
    if(topic == None):
        return 0
    
    #fetch data using get and save html text into variable data
    URL = 'https://en.wikipedia.org/w/api.php?action=parse&section=0&prop=text&format=json&page=' + topic
    response = requests.get(url = URL);
    data = response.json()['parse']['text']['*']

    #loop to find each topic occurrence, +1 to count if found
    count = 0
    index = data.find(topic)
    while(index != -1):
        count += 1
        data = data[index+1:len(data)]
        index = data.find(topic)
    
    return count