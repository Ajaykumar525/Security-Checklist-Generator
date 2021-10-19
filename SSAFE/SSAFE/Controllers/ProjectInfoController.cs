using Newtonsoft.Json;
using SSAFE.Infrastructure;
using SSAFE.Infrastructure.Attributes;
using SSAFE.Models;
using SSAFE.Models.Entity;
using SSAFE.Models.ViewModel;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SSAFE.Controllers
{
    public class ProjectInfoController : Controller
    {
        // GET: ProjectInfo
        [SessionAuthorize]
        public async System.Threading.Tasks.Task<ActionResult> ProjectInfo(string id)
        {
            ServiceResponse response = new ServiceResponse();
            Projects ProInfo = new Projects();
            if (id != null)
            {
                Project ProjectData = new Project
                {
                    Project_ID = Guid.Parse(id)
                };
                var client = new HttpClient();
                client.BaseAddress = new Uri(SessionHelper.BaseApiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(ProjectData), Encoding.UTF8, "application/json");

                HttpResponseMessage webResponse = await client.PostAsync("fetch_project", content);
                if (webResponse.IsSuccessStatusCode == true)
                {
                    var jsonResponse = webResponse.Content.ReadAsStringAsync();
                    var js = new JavaScriptSerializer();
                    Projects UP = js.Deserialize<Projects>(jsonResponse.Result);
                    //response.Url = "/Dashboard/Dashboard";
                    response.Data = UP;
                    SessionHelper.Project_ID = UP.Project_ID;
                    Session["PlanningPhaseChecklist"] = UP.Planningvm;
                    Session["AnalysisPhaseChecklist"] = UP.Analysisvm;
                    Session["DesignPhaseChecklist"] = UP.Designvm;
                    Session["DevelopmentPhaseChecklist"] = UP.Developmentvm;
                    Session["Testing_IntegrationPhaseChecklist"] = UP.Testing_Integrationvm;
                    Session["PlanningPhaseChecklist"] = UP.Planningvm;
                    Session["DeploymentPhaseChecklist"] = UP.Deploymentvm;
                    response.IsSuccess = true;
                    return View(response.Data);
                }
                else
                {
                    response.IsSuccess = false;
                    return View();
                }
            }
            return View();
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult ProjectInfo(Project pid)
        {
            ServiceResponse response = new ServiceResponse();
            bool IsProjectSaved;

            if (SessionHelper.Project_ID == Guid.Empty)
            {
                SessionHelper.Project_Name = pid.Project_Name;
                SessionHelper.Project_Description = pid.Project_Description;
                SessionHelper.Project_IsActive = true;
                SessionHelper.Project_IsEdit = false;
                SessionHelper.Project_ID = Guid.NewGuid();
                IsProjectSaved = true;
            }

            else
            {
                SessionHelper.Project_Name = pid.Project_Name;
                SessionHelper.Project_Description = pid.Project_Description;
                SessionHelper.Project_IsActive = true;
                SessionHelper.Project_IsEdit = true;
                IsProjectSaved = true;
            }

            if (IsProjectSaved)
            {
                response.Message = "Project Saved Successfully";
                response.IsSuccess = true;
                response.Url = "/Phases/Phases";
            }
            else
            {
                response.Message = "Project Regisrtation Failed, Please Try Again";
                response.IsSuccess = false;
            }
            return Json(response);
        }

        [SessionAuthorize]
        public async System.Threading.Tasks.Task<ActionResult> ProjectList()
        {
            ServiceResponse response = new ServiceResponse();
            //UserProjects UP = new UserProjects();
            UserData ud = new UserData
            {
                userId = SessionHelper.UserId,
            };

            var client = new HttpClient
            {
                BaseAddress = new Uri(SessionHelper.BaseApiURL)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(ud), Encoding.UTF8, "application/json");

            HttpResponseMessage webResponse = await client.PostAsync("fetch_projects", content);

            if (webResponse.IsSuccessStatusCode == true)
            {
                var jsonResponse = webResponse.Content.ReadAsStringAsync();
                var js = new JavaScriptSerializer();
                Projects[] UP = js.Deserialize<Projects[]>(jsonResponse.Result);
                //UP.ProjectList = jsonResponse.Result;
                Projects[] Projectlist = new Projects[UP.Length];
                ViewBag.Checklist = UP;
                Projectlist = UP;
                response.IsSuccess = true;
                return View(Projectlist);
            }
            else
            {
                response.IsSuccess = false;
                return View();
            }
        }

        [SessionAuthorize]
        public async System.Threading.Tasks.Task<ActionResult> DeleteProject(string id)
        {
            ServiceResponse response = new ServiceResponse();
            Projects ProInfo = new Projects();
            if (id != null)
            {
                Project ProjectData = new Project
                {
                    Project_ID = Guid.Parse(id)
                };
                var client = new HttpClient();
                client.BaseAddress = new Uri(SessionHelper.BaseApiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(ProjectData), Encoding.UTF8, "application/json");

                HttpResponseMessage webResponse = await client.PostAsync("delete_project", content);

                if (webResponse.IsSuccessStatusCode == true)
                {
                    response.Message = "Project Saved Successfully";
                    response.Url = "/Dashboard/Dashboard";
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "Registration Failed, Please Try Again";
                    response.IsSuccess = false;
                }
            }
            return RedirectToAction("ProjectList");
        }
    }
}