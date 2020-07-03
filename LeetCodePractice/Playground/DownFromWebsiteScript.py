from bs4 import BeautifulSoup
import requests
from pathlib import Path

data_folder = Path("source_data/text_files/")

# url to grab all links
url = 'https://sites.math.rutgers.edu/~ajl213/CLRS/CLRS.html'
# base url to append links to
baseUrl = 'https://sites.math.rutgers.edu/~ajl213/CLRS/'
# where to save file
baseSaveTo = Path(r'C:\Users\lin\Google Drive\EDU\AlgorithmPractice\LeetCodePractice\Textbook and Notes')

# get html page so we have get all links
html_page = requests.get(url)
soup = BeautifulSoup(html_page.text, "html.parser")

for link in soup.findAll('a'):
    # download file for each link
    href = link.get('href')
    response = requests.get(baseUrl + href)
    with open(baseSaveTo/href, 'wb') as f:
        f.write(response.content)