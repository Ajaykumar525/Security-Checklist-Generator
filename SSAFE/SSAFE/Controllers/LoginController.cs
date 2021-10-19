using Newtonsoft.Json;
using SSAFE.Infrastructure;
using SSAFE.Models;
using SSAFE.Models.Entity;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SSAFE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Login(UserData uld)
        {
            ServiceResponse response = new ServiceResponse();
            response.Message = "Incorrect Username or Password";
            response.IsSuccess = false;
            
            UserData loginData = new UserData
            {
                userName = uld.userName,
                password = uld.password
            };         

            var client = new HttpClient();
            client.BaseAddress = new Uri(SessionHelper.BaseApiURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            HttpResponseMessage webResponse = await client.PostAsync("autheticate_user", content);
            if(webResponse.IsSuccessStatusCode==true)
            {            
                var jsonResponse = webResponse.Content.ReadAsStringAsync();
                string userid = Trim(jsonResponse.Result);           
                SessionHelper.UserId = Guid.Parse(userid);
                SessionHelper.UserName = Capitalize(uld.userName);
                Session["UserName"] = SessionHelper.UserName;
                response.Url = "/Dashboard/Dashboard";
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            //string apiUrl = "http://localhost:1234/autheticate_user?userId=d23c53d7-326b-42e4-a1b4-74f6f9a888ba&userName=ajay&password=ajay";            
            //HttpResponseMessage ApiResponse = GlobalVariables.WebApiClient.GetAsync("http://localhost:1234/autheticate_user?userId=d23c53d7-326b-42e4-a1b4-74f6f9a888ba&userName=ajay&password=ajay").Result;
            //string jsonData = client.PostAsync("autheticate_user", content).ToString();
            //string jsonData = JsonConvert.SerializeObject(loginData, Formatting.Indented); 
            //var webClient = new WebClient();
            //var json = webClient.DownloadString(@"D:\Projects\SSAFE\SSAFE\SSAFE\lib\User.json");
            //var users = JsonConvert.DeserializeObject<User>(json);
            //for (int i = 0; i < users.users.Count; i++)
            //{
            //    if (users.users[i].userName == uld.userName && users.users[i].password == uld.password)
            //    {
            //        Session["UserName"] = uld.userName;
            //        SessionHelper.UserName = uld.userName;
            //        //SessionHelper.UserName = Capitalize(uld.User_Name);
            //        SessionHelper.UserId = users.users[i].userId;
            //        response.Url = "/Dashboard/Dashboard";
            //        response.IsSuccess = true;
            //        break;
            //    }
            //};
            return Json(response);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session["UserName"] = null;
            HttpCookie CookieName = Request.Cookies["CMUserName"];
            HttpCookie cookiepassword = Request.Cookies["CMPassword"];

            if (cookiepassword != null && CookieName != null)
            {
                CookieName.Expires = DateTime.Now.AddDays(-1);
                CookieName.Value = null;
                Response.Cookies.Add(CookieName);

                cookiepassword.Expires = DateTime.Now.AddDays(-1);
                cookiepassword.Value = null;
                Response.Cookies.Add(cookiepassword);
            }
            return RedirectToAction("Index", "Home");
        }

        public String Capitalize(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(username[0]) + username.Substring(1);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Register(UserData uld)
        {
            ServiceResponse response = new ServiceResponse();
            response.IsSuccess = false;
            UserData ud = new UserData
            {
                userName = uld.userName,
                password = uld.password,
                userId = Guid.NewGuid()
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri(SessionHelper.BaseApiURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(ud), Encoding.UTF8, "application/json");

            HttpResponseMessage webResponse = await client.PostAsync("add_user", content);
            if (webResponse.IsSuccessStatusCode == true)
            {
                response.Message = "Registration Successfull";
                response.IsSuccess = true;
            }
            else
            {
                response.Message = "Registration Failed, Please Try Again";
                response.IsSuccess = false;
            }
            return Json(response);
        }

        public string Trim(string userid)
        {
            userid = userid.Remove(0, 1);
            userid = userid.Remove(userid.Length - 1);
            return userid;
        }
    }
}