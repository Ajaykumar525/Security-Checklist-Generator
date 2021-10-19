from __future__ import print_function
import requests
import json
headers = {'content-type': 'application/json'}

test_url =  'http://localhost:1234/add_checklist'
data = {
  "userId": "c38a5579-a7ec-4e02-9edc-b00e4f5d233e",
  "checklistID": "test",
  "checklistName": "asd",
  "selectedChecklist": [1,2,3]
}

response = requests.post(test_url, json=data)
print(json.loads(response.text))
