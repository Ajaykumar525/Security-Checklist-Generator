using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSAFE.Infrastructure.Attributes
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SessionHelper.UserId == Guid.Empty)
            {
                SessionHelper.ReturnPageURL = httpContext.Request.CurrentExecutionFilePath;
            }
            //if (Equals(httpContext.Request.CurrentExecutionFilePath, Constants.LockScreenURL))
            //{
            //    SessionHelper.LockScreenReturnPageURL = httpContext.Request.CurrentExecutionFilePath;
            //}
            return httpContext.Session["UserName"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            SessionHelper.BaseApiURL = "http://localhost:1234/";
            filterContext.Result = new RedirectResult("/Login/Login");            
        }
    }
}