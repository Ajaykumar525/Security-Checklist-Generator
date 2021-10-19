import json

with open('project.json') as checklist:
    project_json = json.load(checklist)

# for uid in project_json['projects'].keys():
#     for pid in project_json['projects'][uid]:
#         print(pid['Project_ID'])

for uid in project_json['projects'].keys():
    for pid in range(len(project_json['projects'][uid])):
        print(project_json['projects'][uid][pid])