#import libraries
import uvicorn
from fastapi import FastAPI, Form
from typing import Optional, List
from pydantic import BaseModel
import json

#create FastAPI object
app = FastAPI()

#loading json files
with open('User.json') as user:
    user_json = json.load(user)
    
with open('project.json') as project:
    project_json = json.load(project)


class User(BaseModel):
    userId: Optional[str] = None
    userName: Optional[str] = None
    password: Optional[str] = None
    
    
class Project(BaseModel):
    userId: Optional[str] = None
    Project_ID: Optional[str] = None
    Project_Name: Optional[str] = None
    Project_Description: Optional[str] = None
    Project_IsActive: Optional[bool] = None
    Analysisvm: List[dict] = []
    Developmentvm: List[dict] = []
    Designvm: List[dict] = []
    Deploymentvm: List[dict] = []
    Planningvm: List[dict] = []
    Testing_Integrationvm: List[dict] = []
    
    
@app.get("/")
def index():
    return {"message": "Cheklist APIs"}


@app.post("/add_user")
async def add_user(user: Optional[User] = None):
    """[This function will store new user to database.]

    Args:
        user.userId (str): unique user ID of user
        user.userName (str): username of user
        user.password (str): password of user

    Returns:
        Response: 
        bool: returns status whether user added or not.        
    """
    if user.userId and user.userName and user.password:
        user_json['users'].append({
        "User_ID": user.userId,
        "User_Name": user.userName,
        "User_Password": user.password
        })
        
        with open('User.json', 'w') as user:
            json.dump(user_json, user)

        return True
    
    else:
        return False
    
    
@app.post("/autheticate_user")
async def autheticate_user(user: Optional[User] = None):
    """[This function will authenticate user credentials for login.]

    Args:
        user.userName (str): username of user
        user.password (str): password of user 

    Returns:
        Response: 
        str: returns user ID if user exists else error message.
    """
    global user_json

    
    for users in user_json['users']:
        
        if users['User_Name'] == user.userName and users['User_Password'] == user.password:
            return users['User_ID']
        
    return 'no user found'

    
    

@app.post("/add_project")
async def add_project(project: Optional[Project] = None):
    """[This function will store the checklists selected by the user to the database.]

    Args:
        project.userId (str): unique user ID of user
        project.projectId (str): unique project ID
        project.projectName (str): name of the projct
        project.projectDescription (str): description of the project.
        project.projectIsActive (bool): whether project is active or not.
        project.analysis (list): analysis checklist.
        project.deployment (list): deployment checklist.
        project.design (list): design checklist.
        project.development (list): development checklist.
        project.planning (list): planning checklist.
        project.testing_integration (list): testing integration checklist.
    
    Returns:
        Response: 
        bool: returns status whether checklist added or not.
    """
    if project.userId in project_json['projects'].keys():    
        project_json['projects'][project.userId].append({
                "Project_ID": project.Project_ID,
                "Project_Name": project.Project_Name,
                "Project_Description": project.Project_Description,
                "Project_IsActive": project.Project_IsActive,
                "Analysisvm": project.Analysisvm,
                "Developmentvm": project.Developmentvm,
                "Designvm": project.Designvm,
                "Deploymentvm": project.Deploymentvm,
                "Planningvm": project.Planningvm,
                "Testing_Integrationvm": project.Testing_Integrationvm
            }
        ) 
        with open('project.json', 'w') as project:
            json.dump(project_json, project)  
        return True
    
    else:
        return False
    
    
@app.post("/fetch_projects")
async def fetch_projects(project: Optional[Project] = None):
    """[This function will fetch all the checklists associated to the user.]

    Args:
        project.userId: unique user ID of user
        
    Returns:
        Response: 
        list: returns list of projects created by user else returns empty list.
    """
    if project.userId in project_json['projects'].keys():
        return project_json['projects'][project.userId]
    
    else:
        return []

@app.post("/fetch_project")
async def fetch_project(project: Optional[Project] = None):
    """[This function will fetch all the checklists associated to the user.]

    Args:
        project.Project_ID: unique Project ID of Project
        
    Returns:
        Response: 
        list: returns details of whole project else returns empty list.
    """
    for uid in project_json['projects'].keys():
        for pid in project_json['projects'][uid]:
            if project.Project_ID == pid['Project_ID']:
                return pid
    else:
        return []        

@app.post("/modify_project")
async def fetch_project(project: Optional[Project] = None):
    """[This function will fetch all the checklists associated to the user.]

    Args:
        project.userId (str): unique user ID of user
        project.projectId (str): unique project ID
        project.projectName (str): name of the projct
        project.projectDescription (str): description of the project.
        project.projectIsActive (bool): whether project is active or not.
        project.analysis (list): analysis checklist.
        project.deployment (list): deployment checklist.
        project.design (list): design checklist.
        project.development (list): development checklist.
        project.planning (list): planning checklist.
        project.testing_integration (list): testing integration checklist.
        
    Returns:
        Response: 
        list: returns details of whole project else returns empty list.
    """

    # for uid in project_json['projects']:
    #     for pid in project_json['projects'][uid]:
    #         if pid['Project_ID'] == project.Project_ID: 
    #             pid["Project_Name"] = project.Project_Name,
    #             pid["Project_Description"] = project.Project_Description,
    #             pid["Project_IsActive"] = project.Project_IsActive,
    #             pid["Analysisvm"] = project.Analysisvm,
    #             pid["Developmentvm"] = project.Developmentvm,
    #             pid["Designvm"] = project.Designvm,
    #             pid["Deploymentvm"] = project.Deploymentvm,
    #             pid["Planningvm"] = project.Planningvm,
    #             pid["Testing_Integrationvm"] = project.Testing_Integrationvm
    #             print(pid)
    
    for uid in project_json['projects'].keys():
        for pid in range(len(project_json['projects'][uid])):
            if project_json['projects'][uid][pid]['Project_ID'] == project.Project_ID: 
                project_json['projects'][uid].pop(pid)

    project_json['projects'][project.userId].append({
                "Project_ID": project.Project_ID,
                "Project_Name": project.Project_Name,
                "Project_Description": project.Project_Description,
                "Project_IsActive": project.Project_IsActive,
                "Analysisvm": project.Analysisvm,
                "Developmentvm": project.Developmentvm,
                "Designvm": project.Designvm,
                "Deploymentvm": project.Deploymentvm,
                "Planningvm": project.Planningvm,
                "Testing_Integrationvm": project.Testing_Integrationvm
            }
        )

    with open('project.json', 'w') as project:
        json.dump(project_json, project)  
        
    return True  

@app.post("/delete_project")
async def fetch_project(project: Optional[Project] = None):
    """[This function will fetch all the checklists associated to the user.]

    Args:
        project.Project_ID: unique Project ID of Project
        project.userId (str): unique user ID of user
        
    Returns:
        Response: 
        list: returns details of whole project else returns empty list.
    """
    for uid in project_json['projects']:
        for pid in project_json['projects'][uid]:
            if pid['Project_ID'] == project.Project_ID: 
                pid['Project_IsActive'] = False

    with open('project.json', 'w') as project:
        json.dump(project_json, project)  
        
    return True

if __name__ == '__main__':
    uvicorn.run(app, host="0.0.0.0", port=1234)