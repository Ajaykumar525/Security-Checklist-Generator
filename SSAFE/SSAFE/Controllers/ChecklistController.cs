using Newtonsoft.Json;
using SSAFE.Infrastructure;
using SSAFE.Infrastructure.Attributes;
using SSAFE.Models;
using SSAFE.Models.Entity;
using SSAFE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;

namespace SSAFE.Controllers
{
    public class ChecklistController : Controller
    {
        // GET: Checklist
        [SessionAuthorize]
        public ActionResult New_Checklist()
        {
            ChecklistViewModel Checklistvm = new ChecklistViewModel();

            if (Session["PlanningPhaseChecklist"] == null)
            {
                List<Planning> PlanningChecklist = new List<Planning>();
                PlanningChecklist = ResetChecklist.ResetPlanning();
                ViewBag.PlanningChecklist = PlanningChecklist;
                Session["PlanningPhaseChecklist"] = PlanningChecklist;
                Checklistvm.Planningvm = PlanningChecklist;
            }
            else
            {
                List<Planning> PlanningChecklist = new List<Planning>();
                PlanningChecklist = (List<Planning>)Session["PlanningPhaseChecklist"];
                ViewBag.PlanningChecklist = PlanningChecklist;
                Checklistvm.Planningvm = PlanningChecklist;
            }

            if (Session["AnalysisPhaseChecklist"] == null)
            {
                List<Analysis> AnalysisChecklist = new List<Analysis>();
                AnalysisChecklist = ResetChecklist.ResetAnalysis();
                ViewBag.PlanningChecklist = AnalysisChecklist;
                Session["AnalysisPhaseChecklist"] = AnalysisChecklist;
                Checklistvm.Analysisvm = AnalysisChecklist;
            }
            else
            {
                List<Analysis> AnalysisChecklist = new List<Analysis>();
                AnalysisChecklist = (List<Analysis>)Session["AnalysisPhaseChecklist"];
                ViewBag.AnalysisChecklist = AnalysisChecklist;
                Checklistvm.Analysisvm = AnalysisChecklist;
            }

            if (Session["DesignPhaseChecklist"] == null)
            {
                List<Design> DesignChecklist = new List<Design>();
                DesignChecklist = ResetChecklist.ResetDesign();
                ViewBag.DesignChecklist = DesignChecklist;
                Session["DesignPhaseChecklist"] = DesignChecklist;
                Checklistvm.Designvm = DesignChecklist;
            }
            else
            {
                List<Design> DesignChecklist = new List<Design>();
                DesignChecklist = (List<Design>)Session["DesignPhaseChecklist"];
                ViewBag.DesignChecklist = DesignChecklist;
                Checklistvm.Designvm = DesignChecklist;
            }

            if (Session["DevelopmentPhaseChecklist"] == null)
            {
                List<Development> DevelopmentChecklist = new List<Development>();
                DevelopmentChecklist = ResetChecklist.ResetDevelopment();
                ViewBag.DevelopmentChecklist = DevelopmentChecklist;
                Session["DevelopmentPhaseChecklist"] = DevelopmentChecklist;
                Checklistvm.Developmentvm = DevelopmentChecklist;
            }
            else
            {
                List<Development> DevelopmentChecklist = new List<Development>();
                DevelopmentChecklist = (List<Development>)Session["DevelopmentPhaseChecklist"];
                ViewBag.DevelopmentChecklist = DevelopmentChecklist;
                Checklistvm.Developmentvm = DevelopmentChecklist;
            }

            if (Session["Testing_IntegrationPhaseChecklist"] == null)
            {
                List<Testing_Integration> Testing_IntegrationChecklist = new List<Testing_Integration>();
                Testing_IntegrationChecklist = ResetChecklist.ResetTesting_Integration();
                ViewBag.Testing_IntegrationChecklist = Testing_IntegrationChecklist;
                Session["Testing_IntegrationPhaseChecklist"] = Testing_IntegrationChecklist;
                Checklistvm.Testing_Integrationvm = Testing_IntegrationChecklist;
            }
            else
            {
                List<Testing_Integration> Testing_IntegrationChecklist = new List<Testing_Integration>();
                Testing_IntegrationChecklist = (List<Testing_Integration>)Session["Testing_IntegrationPhaseChecklist"];
                ViewBag.Testing_IntegrationChecklist = Testing_IntegrationChecklist;
                Checklistvm.Testing_Integrationvm = Testing_IntegrationChecklist;
            }
           
            if (Session["DeploymentPhaseChecklist"] == null)
            {
                List<Deployment> DeploymentChecklist = new List<Deployment>();
                DeploymentChecklist = ResetChecklist.ResetDeployment();
                ViewBag.DeploymentChecklist = DeploymentChecklist;
                Session["DeploymentPhaseChecklist"] = DeploymentChecklist;
                Checklistvm.Deploymentvm = DeploymentChecklist;
            }
            else
            {
                List<Deployment> DeploymentChecklist = new List<Deployment>();
                DeploymentChecklist = (List<Deployment>)Session["DeploymentPhaseChecklist"];
                ViewBag.DeploymentChecklist = DeploymentChecklist;
                Checklistvm.Deploymentvm = DeploymentChecklist;
            }            

            return View(Checklistvm);
        }

        [SessionAuthorize]
        public ActionResult Manage_Checklist()
        {            
            return View();
        }

        [SessionAuthorize]
        public ActionResult Test()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"D:\Projects\SSAFE\SSAFE\SSAFE\lib\Checks.json");
            var checks = JsonConvert.DeserializeObject<Checks>(json);
            return View(checks);
        }

        [SessionAuthorize]
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> SaveProject_Checklist()
        {
            ServiceResponse response = new ServiceResponse();            
            PCViewModel Checklists = new PCViewModel();
            response.IsSuccess = false;

            Checklists.Planningvm = (List<Planning>)Session["PlanningPhaseChecklist"];          
            Checklists.Analysisvm = (List<Analysis>)Session["AnalysisPhaseChecklist"];
            Checklists.Designvm = (List<Design>)Session["DesignPhaseChecklist"];
            Checklists.Developmentvm = (List<Development>)Session["DevelopmentPhaseChecklist"];
            Checklists.Testing_Integrationvm = (List<Testing_Integration>)Session["Testing_IntegrationPhaseChecklist"];            
            Checklists.Deploymentvm = (List<Deployment>)Session["DeploymentPhaseChecklist"];

            Checklists.Project_ID = SessionHelper.Project_ID;
            Checklists.Project_Name = SessionHelper.Project_Name;
            Checklists.Project_Description = SessionHelper.Project_Description;
            Checklists.Project_IsActive = SessionHelper.Project_IsActive;

            Checklists.userId = SessionHelper.UserId;

            var client = new HttpClient
            {
                BaseAddress = new Uri(SessionHelper.BaseApiURL)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(Checklists), Encoding.UTF8, "application/json");

            if (SessionHelper.Project_IsEdit)
            {
                HttpResponseMessage webResponse = await client.PostAsync("modify_project", content);
                response = FillResponse(webResponse);
            }
            else
            {
                HttpResponseMessage webResponse = await client.PostAsync("add_project", content);
                response = FillResponse(webResponse);
            }            
            return Json(response);
        }

        public ServiceResponse FillResponse (HttpResponseMessage webResponse)
        {
            ServiceResponse response = new ServiceResponse();

            if (webResponse.IsSuccessStatusCode == true)
            {
                response.Message = SessionHelper.Project_IsEdit ? "Project Modified Successfully" : "Project Created Successfully";                
                response.Url = "/Dashboard/Dashboard";
                response.IsSuccess = true;
                ClearChecklistSession();                                
            }
            else
            {
                response.Message = "Failed to Save Project, Please Try Again";
                response.IsSuccess = false;
            }

            return response;
        }

        public void ClearChecklistSession ()
        {
            Session["PlanningPhaseChecklist"] = null;
            Session["AnalysisPhaseChecklist"] = null;
            Session["DesignPhaseChecklist"] = null;
            Session["DevelopmentPhaseChecklist"] = null;
            Session["Testing_IntegrationPhaseChecklist"] = null;
            Session["DeploymentPhaseChecklist"] = null;

            SessionHelper.Project_ID = Guid.Empty;
            SessionHelper.Project_Name = null;
            SessionHelper.Project_Description = null;
            SessionHelper.Project_IsEdit = false;
        }
    }
}