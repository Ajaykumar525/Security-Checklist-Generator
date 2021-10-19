using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSAFE.Models.Entity
{
    public class Deployment
    {
        public int Deployment_ID { get; set; }

        public string Deployment_Value { get; set; }

        public bool Deployment_IsChecked { get; set; }
    }
}