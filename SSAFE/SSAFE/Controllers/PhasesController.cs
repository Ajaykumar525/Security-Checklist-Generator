using SSAFE.Infrastructure;
using SSAFE.Infrastructure.Attributes;
using SSAFE.Models;
using SSAFE.Models.Entity;
using SSAFE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSAFE.Controllers
{
    public class PhasesController : Controller
    {
        // GET: Phases
        [SessionAuthorize]
        public ActionResult Phases()
        {
            return View();
        }

        [SessionAuthorize]
        public ActionResult Planning()
        {
            if(Session["PlanningPhaseChecklist"] == null)
            {
                List<Planning> Checklist = new List<Planning>();
                Checklist = ResetChecklist.ResetPlanning();
                ViewBag.Checklist = Checklist;
                Session["PlanningPhaseChecklist"] = Checklist;
            }
            else
            {
                List<Planning> Checklist = new List<Planning>();
                Checklist = (List<Planning>)Session["PlanningPhaseChecklist"];
                ViewBag.Checklist = Checklist;
            }
            return View();
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult Planning(string ItemList)
        {            
            ServiceResponse response = new ServiceResponse();
            string[] arr = ItemList.Split(',');
            List<Planning> Checklist = new List<Planning>();
            Checklist = ResetChecklist.ResetPlanning();
            try
            {
                if (ItemList != "")
                {
                    foreach (var id in arr)
                    {
                        var currentId = Int16.Parse(id);
                        foreach (var uc in Checklist.Where(w => w.Planning_ID == currentId))
                        {
                            uc.Planning_IsChecked = true;
                        }
                    }
                    Session["PlanningPhaseChecklist"] = Checklist;

                    if (Session["PlanningPhaseChecklist"] != null)
                    {
                        response.Message = "Checks Added";
                        response.IsSuccess = true;
                        response.Url = "/Phases/Phases";
                    }
                    else
                    {
                        response.Message = "Checks Adding Failed, Please Try Again";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    Session["PlanningPhaseChecklist"] = Checklist;
                    response.Message = "Checks Added";
                    response.IsSuccess = true;
                    response.Url = "/Phases/Phases";
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        [SessionAuthorize]
        public ActionResult Analysis()
        {
            if (Session["AnalysisPhaseChecklist"] == null)
            {
                List<Analysis> Checklist = new List<Analysis>();
                Checklist = ResetChecklist.ResetAnalysis();
                ViewBag.Checklist = Checklist;
                Session["AnalysisPhaseChecklist"] = Checklist;                
            }
            else
            {
                List<Analysis> Checklist = new List<Analysis>();
                Checklist = (List<Analysis>)Session["AnalysisPhaseChecklist"];
                ViewBag.Checklist = Checklist;
            }
            return View();
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult Analysis(string ItemList)
        {
            ServiceResponse response = new ServiceResponse();
            string[] arr = ItemList.Split(',');
            List<Analysis> Checklist = new List<Analysis>();
            Checklist = ResetChecklist.ResetAnalysis();
            try
            {
                if (ItemList != "")
                {
                    foreach (var id in arr)
                    {
                        var currentId = Int16.Parse(id);
                        foreach (var uc in Checklist.Where(w => w.Analysis_ID == currentId))
                        {
                            uc.Analysis_IsChecked = true;
                        }
                    }
                    Session["AnalysisPhaseChecklist"] = Checklist;

                    if (Session["AnalysisPhaseChecklist"] != null)
                    {
                        response.Message = "Checks Added";
                        response.IsSuccess = true;
                        response.Url = "/Phases/Phases";
                    }
                    else
                    {
                        response.Message = "Checks Adding Failed, Please Try Again";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    Session["AnalysisPhaseChecklist"] = Checklist;
                    response.Message = "Checks Added";
                    response.IsSuccess = true;
                    response.Url = "/Phases/Phases";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        [SessionAuthorize]
        public ActionResult Design()
        {
            if (Session["DesignPhaseChecklist"] == null)
            {
                List<Design> Checklist = new List<Design>();
                Checklist = ResetChecklist.ResetDesign();
                ViewBag.Checklist = Checklist;
                Session["DesignPhaseChecklist"] = Checklist;
            }
            else
            {
                List<Design> Checklist = new List<Design>();
                Checklist = (List<Design>)Session["DesignPhaseChecklist"];
                ViewBag.Checklist = Checklist;
            }
            return View();
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult Design(string ItemList)
        {
            ServiceResponse response = new ServiceResponse();
            string[] arr = ItemList.Split(',');
            List<Design> Checklist = new List<Design>();
            Checklist = ResetChecklist.ResetDesign();
            try
            {
                if (ItemList != "")
                {
                    foreach (var id in arr)
                    {
                        var currentId = Int16.Parse(id);
                        foreach (var uc in Checklist.Where(w => w.Design_ID == currentId))
                        {
                            uc.Design_IsChecked = true;
                        }
                    }
                    Session["DesignPhaseChecklist"] = Checklist;

                    if (Session["DesignPhaseChecklist"] != null)
                    {
                        response.Message = "Checks Added";
                        response.IsSuccess = true;
                        response.Url = "/Phases/Phases";
                    }
                    else
                    {
                        response.Message = "Checks Adding Failed, Please Try Again";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    Session["DesignPhaseChecklist"] = Checklist;
                    response.Message = "Checks Added";
                    response.IsSuccess = true;
                    response.Url = "/Phases/Phases";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        [SessionAuthorize]
        public ActionResult Development()
        {
            if (Session["DevelopmentPhaseChecklist"] == null)
            {
                List<Development> Checklist = new List<Development>();
                Checklist = ResetChecklist.ResetDevelopment();
                ViewBag.Checklist = Checklist;
                Session["DevelopmentPhaseChecklist"] = Checklist;
            }
            else
            {
                List<Development> Checklist = new List<Development>();
                Checklist = (List<Development>)Session["DevelopmentPhaseChecklist"];
                ViewBag.Checklist = Checklist;
            }
            return View();
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult Development(string ItemList)
        {
            ServiceResponse response = new ServiceResponse();
            string[] arr = ItemList.Split(',');
            List<Development> Checklist = new List<Development>();
            Checklist = ResetChecklist.ResetDevelopment();
            try
            {
                if (ItemList != "")
                {
                    foreach (var id in arr)
                    {
                        var currentId = Int16.Parse(id);
                        foreach (var uc in Checklist.Where(w => w.Development_ID == currentId))
                        {
                            uc.Development_IsChecked = true;
                        }
                    }
                    Session["DevelopmentPhaseChecklist"] = Checklist;

                    if (Session["DevelopmentPhaseChecklist"] != null)
                    {
                        response.Message = "Checks Added";
                        response.IsSuccess = true;
                        response.Url = "/Phases/Phases";
                    }
                    else
                    {
                        response.Message = "Checks Adding Failed, Please Try Again";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    Session["DevelopmentPhaseChecklist"] = Checklist;
                    response.Message = "Checks Added";
                    response.IsSuccess = true;
                    response.Url = "/Phases/Phases";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        [SessionAuthorize]
        public ActionResult Testing_Integration()
        {
            if (Session["Testing_IntegrationPhaseChecklist"] == null)
            {
                List<Testing_Integration> Checklist = new List<Testing_Integration>();
                Checklist = ResetChecklist.ResetTesting_Integration();
                ViewBag.Checklist = Checklist;
                Session["Testing_IntegrationPhaseChecklist"] = Checklist;
            }
            else
            {
                List<Testing_Integration> Checklist = new List<Testing_Integration>();
                Checklist = (List<Testing_Integration>)Session["Testing_IntegrationPhaseChecklist"];
                ViewBag.Checklist = Checklist;
            }
            return View();
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult Testing_Integration(string ItemList)
        {
            ServiceResponse response = new ServiceResponse();
            string[] arr = ItemList.Split(',');
            List<Testing_Integration> Checklist = new List<Testing_Integration>();
            Checklist = ResetChecklist.ResetTesting_Integration();
            try
            {
                if (ItemList != "")
                {
                    foreach (var id in arr)
                    {
                        var currentId = Int16.Parse(id);
                        foreach (var uc in Checklist.Where(w => w.Testing_Integration_ID == currentId))
                        {
                            uc.Testing_Integration_IsChecked = true;
                        }
                    }
                    Session["Testing_IntegrationPhaseChecklist"] = Checklist;

                    if (Session["Testing_IntegrationPhaseChecklist"] != null)
                    {
                        response.Message = "Checks Added";
                        response.IsSuccess = true;
                        response.Url = "/Phases/Phases";
                    }
                    else
                    {
                        response.Message = "Checks Adding Failed, Please Try Again";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    Session["Testing_IntegrationPhaseChecklist"] = Checklist;
                    response.Message = "Checks Added";
                    response.IsSuccess = true;
                    response.Url = "/Phases/Phases";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        [SessionAuthorize]
        public ActionResult Deployment()
        {
            if (Session["DeploymentPhaseChecklist"] == null)
            {
                List<Deployment> Checklist = new List<Deployment>();
                Checklist = ResetChecklist.ResetDeployment();
                ViewBag.Checklist = Checklist;
                Session["DeploymentPhaseChecklist"] = Checklist;
            }
            else
            {
                List<Deployment> Checklist = new List<Deployment>();
                Checklist = (List<Deployment>)Session["DeploymentPhaseChecklist"];
                ViewBag.Checklist = Checklist;
            }
            return View();
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult Deployment(string ItemList)
        {
            ServiceResponse response = new ServiceResponse();
            string[] arr = ItemList.Split(',');
            List<Deployment> Checklist = new List<Deployment>();
            Checklist = ResetChecklist.ResetDeployment();
            try
            {
                if (ItemList != "")
                {
                    foreach (var id in arr)
                    {
                        var currentId = Int16.Parse(id);
                        foreach (var uc in Checklist.Where(w => w.Deployment_ID == currentId))
                        {
                            uc.Deployment_IsChecked = true;
                        }
                    }
                    Session["DeploymentPhaseChecklist"] = Checklist;

                    if (Session["DeploymentPhaseChecklist"] != null)
                    {
                        response.Message = "Checks Added";
                        response.IsSuccess = true;
                        response.Url = "/Phases/Phases";
                    }
                    else
                    {
                        response.Message = "Checks Adding Failed, Please Try Again";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    Session["DeploymentPhaseChecklist"] = Checklist;
                    response.Message = "Checks Added";
                    response.IsSuccess = true;
                    response.Url = "/Phases/Phases";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }
    }
}