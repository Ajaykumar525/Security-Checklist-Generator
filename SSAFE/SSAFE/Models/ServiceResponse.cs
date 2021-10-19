using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSAFE.Models
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {
            IsSuccess = false;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public int ErrorCode { get; set; }
    }
}