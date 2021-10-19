using SSAFE.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSAFE.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [SessionAuthorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}