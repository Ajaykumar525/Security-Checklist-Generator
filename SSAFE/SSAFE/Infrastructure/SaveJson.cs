using Newtonsoft.Json;
using SSAFE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace SSAFE.Infrastructure
{
    public class SaveJson
    {
        public async System.Threading.Tasks.Task<bool> SaveProject(Project pid)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(SessionHelper.BaseApiURL)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(pid), Encoding.UTF8, "application/json");

            HttpResponseMessage webResponse = await client.PostAsync("add_projectinfo", content);

            bool IsProjectSaved = webResponse.IsSuccessStatusCode;
            return IsProjectSaved;
        }
    }
}