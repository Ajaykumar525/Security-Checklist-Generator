using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SSAFE.Infrastructure
{
    public class FastWebApi
    {
        public static HttpResponseMessage CallWebApi(string ApiUrl)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(ApiUrl).Result;
            return (response);
        }
    }
}